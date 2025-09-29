//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品MAX入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 陳艶丹
// 作 成 日  2016/01/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockArrivalWork
    /// <summary>
    ///                      部品MAX入荷予約データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品MAX入荷予約データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/01/21</br>
    /// <br>Genarated Date   :   2016/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockArrivalWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>出荷日</summary>
        private DateTime _shipDate;

        /// <summary>伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>伝票行番号</summary>
        private Int32 _stockMoveSlipRowNo;

        /// <summary>品名</summary>
        private string _goodsName = "";

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>1以上</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名</summary>
        private string _goodsMakerNm = "";

        /// <summary>BLコード</summary>
        /// <remarks>1以上</remarks>
        private Int32 _bLGoodsCod;

        /// <summary>出荷数</summary>
        /// <remarks>小数点第2位まで保持(000.00)。0.00～99.99の範囲</remarks>
        private Double _shipmentCount;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>販売単価</summary>
        /// <remarks>0～9,999,999</remarks>
        private Int64 _salesPrice;

        /// <summary>売価率</summary>
        /// <remarks>小数点第2位まで保持(000.00)。0.00～999.99の範囲</remarks>
        private Double _salesRate;

        /// <summary>出庫拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>出庫拠点名</summary>
        private string _bfSectionName = "";

        /// <summary>出庫倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>出庫倉庫名</summary>
        private string _bfEnterWarehName = "";

        /// <summary>入庫拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>入庫拠点名</summary>
        private string _afSectionName = "";

        /// <summary>入庫倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>入庫倉庫名</summary>
        private string _afEnterWarehName = "";

        /// <summary>入荷予約日</summary>
        /// <remarks>"yyyy/MM/dd"形式の文字列</remarks>
        private string _stockArrivalDate = "";

        /// <summary>警告理由</summary>
        private string _alertReason = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>得意先の売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>得意先の売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>中分類</summary>
        private Int32 _goodsMGroup;

        /// <summary>価格マスタの原価単価</summary>
        private Double _gpuSalesUnitCost;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>定価</summary>
        private Double _listPrice;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>単価</summary>
        private Double _salesUnitCost;


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>"yyyy/MM/dd"形式の文字列</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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

        /// public propaty name  :  ShipDate
        /// <summary>出荷日プロパティ</summary>
        /// <value>"yyyy/MM/dd"形式の文字列</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipDate
        {
            get { return _shipDate; }
            set { _shipDate = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveSlipRowNo
        /// <summary>伝票行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveSlipRowNo
        {
            get { return _stockMoveSlipRowNo; }
            set { _stockMoveSlipRowNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  BLGoodsCod
        /// <summary>BLコードプロパティ</summary>
        /// <value>1以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCod
        {
            get { return _bLGoodsCod; }
            set { _bLGoodsCod = value; }
        }

        /// public propaty name  :  ShipmentCount
        /// <summary>出荷数プロパティ</summary>
        /// <value>小数点第2位まで保持(000.00)。0.00～99.99の範囲</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCount
        {
            get { return _shipmentCount; }
            set { _shipmentCount = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesPrice
        /// <summary>販売単価プロパティ</summary>
        /// <value>0～9,999,999</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>売価率プロパティ</summary>
        /// <value>小数点第2位まで保持(000.00)。0.00～999.99の範囲</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>出庫拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>出庫拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>出庫倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>出庫倉庫名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫倉庫名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>入庫拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>入庫拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>入庫倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>入庫倉庫名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫倉庫名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  StockArrivalDate
        /// <summary>入荷予約日プロパティ</summary>
        /// <value>"yyyy/MM/dd"形式の文字列</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷予約日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockArrivalDate
        {
            get { return _stockArrivalDate; }
            set { _stockArrivalDate = value; }
        }

        /// public propaty name  :  AlertReason
        /// <summary>警告理由プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告理由プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AlertReason
        {
            get { return _alertReason; }
            set { _alertReason = value; }
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>※中分類をセットする</value>
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

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
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

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>得意先の売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先の売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>得意先の売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先の売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GpuSalesUnitCost
        /// <summary>価格マスタの原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格マスタの原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GpuSalesUnitCost
        {
            get { return _gpuSalesUnitCost; }
            set { _gpuSalesUnitCost = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
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

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }


        /// <summary>
        /// 部品MAX出荷予定ワークコンストラクタ
        /// </summary>
        /// <returns>PartsMaxStockArrivalWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsMaxStockArrivalWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsMaxStockArrivalWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsMaxStockArrivalWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsMaxStockArrivalWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsMaxStockArrivalWork || graph is ArrayList || graph is PartsMaxStockArrivalWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsMaxStockArrivalWork).FullName));

            if (graph != null && graph is PartsMaxStockArrivalWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockArrivalWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsMaxStockArrivalWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsMaxStockArrivalWork[])graph).Length;
            }
            else if (graph is PartsMaxStockArrivalWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //出荷日
            serInfo.MemberInfo.Add(typeof(DateTime)); //ShipDate
            //伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //伝票行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipRowNo
            //品名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCod
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCount
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //販売単価
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPrice
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //出庫拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //出庫拠点名
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionName
            //出庫倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //出庫倉庫名
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //入庫拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //入庫拠点名
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionName
            //入庫倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //入庫倉庫名
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //入荷予約日
            serInfo.MemberInfo.Add(typeof(string)); //StockArrivalDate
            //警告理由
            serInfo.MemberInfo.Add(typeof(string)); //AlertReason
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //商品掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //得意先の売上単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //得意先の売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            // 商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //単価
            serInfo.MemberInfo.Add(typeof(Double)); //GpuSalesUnitCost
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //定価
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsMaxStockArrivalWork)
            {
                PartsMaxStockArrivalWork temp = (PartsMaxStockArrivalWork)graph;

                SetPartsMaxStockArrivalWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsMaxStockArrivalWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsMaxStockArrivalWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsMaxStockArrivalWork temp in lst)
                {
                    SetPartsMaxStockArrivalWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsMaxStockArrivalWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  PartsMaxStockArrivalWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsMaxStockArrivalWork(System.IO.BinaryWriter writer, PartsMaxStockArrivalWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //出荷日
            writer.Write((Int64)temp.ShipDate.Ticks);
            //伝票番号
            writer.Write(temp.StockMoveSlipNo);
            //伝票行番号
            writer.Write(temp.StockMoveSlipRowNo);
            //品名
            writer.Write(temp.GoodsName);
            //品番
            writer.Write(temp.GoodsNo);
            //メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名
            writer.Write(temp.GoodsMakerNm);
            //BLコード
            writer.Write(temp.BLGoodsCod);
            //出荷数
            writer.Write(temp.ShipmentCount);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //販売単価
            writer.Write(temp.SalesPrice);
            //売価率
            writer.Write(temp.SalesRate);
            //出庫拠点コード
            writer.Write(temp.BfSectionCode);
            //出庫拠点名
            writer.Write(temp.BfSectionName);
            //出庫倉庫コード
            writer.Write(temp.BfEnterWarehCode);
            //出庫倉庫名
            writer.Write(temp.BfEnterWarehName);
            //入庫拠点コード
            writer.Write(temp.AfSectionCode);
            //入庫拠点名
            writer.Write(temp.AfSectionName);
            //入庫倉庫コード
            writer.Write(temp.AfEnterWarehCode);
            //入庫倉庫名
            writer.Write(temp.AfEnterWarehName);
            //入荷予約日
            writer.Write(temp.StockArrivalDate);
            //警告理由
            writer.Write(temp.AlertReason);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //商品掛率グループコード
            writer.Write(temp.GoodsRateGrpCode);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //得意先の売上単価端数処理コード
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //得意先の売上消費税端数処理コード
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //単価
            writer.Write(temp.GpuSalesUnitCost);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //定価
            writer.Write(temp.ListPrice);
            //仕入率
            writer.Write(temp.StockRate);
            //提供日付
            writer.Write(temp.OfferDate);
            //更新年月日
            writer.Write(temp.UpdateDate);
            //単価
            writer.Write(temp.SalesUnitCost);

        }

        /// <summary>
        ///  PartsMaxStockArrivalWorkインスタンス取得
        /// </summary>
        /// <returns>PartsMaxStockArrivalWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsMaxStockArrivalWork GetPartsMaxStockArrivalWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsMaxStockArrivalWork temp = new PartsMaxStockArrivalWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //出荷日
            temp.ShipDate = new DateTime(reader.ReadInt64());
            //伝票番号
            temp.StockMoveSlipNo = reader.ReadInt32();
            //伝票行番号
            temp.StockMoveSlipRowNo = reader.ReadInt32();
            //品名
            temp.GoodsName = reader.ReadString();
            //品番
            temp.GoodsNo = reader.ReadString();
            //メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名
            temp.GoodsMakerNm = reader.ReadString();
            //BLコード
            temp.BLGoodsCod = reader.ReadInt32();
            //出荷数
            temp.ShipmentCount = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //販売単価
            temp.SalesPrice = reader.ReadInt64();
            //売価率
            temp.SalesRate = reader.ReadDouble();
            //出庫拠点コード
            temp.BfSectionCode = reader.ReadString();
            //出庫拠点名
            temp.BfSectionName = reader.ReadString();
            //出庫倉庫コード
            temp.BfEnterWarehCode = reader.ReadString();
            //出庫倉庫名
            temp.BfEnterWarehName = reader.ReadString();
            //入庫拠点コード
            temp.AfSectionCode = reader.ReadString();
            //入庫拠点名
            temp.AfSectionName = reader.ReadString();
            //入庫倉庫コード
            temp.AfEnterWarehCode = reader.ReadString();
            //入庫倉庫名
            temp.AfEnterWarehName = reader.ReadString();
            //入荷予約日
            temp.StockArrivalDate = reader.ReadString();
            //警告理由
            temp.AlertReason = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //商品掛率グループコード
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //得意先の売上単価端数処理コード
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //得意先の売上消費税端数処理コード
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //単価
            temp.GpuSalesUnitCost = reader.ReadDouble();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //定価
            temp.ListPrice = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //更新年月日
            temp.UpdateDate = reader.ReadInt32();
            //単価
            temp.SalesUnitCost = reader.ReadDouble();


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
        /// <returns>PartsMaxStockArrivalWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsMaxStockArrivalWork temp = GetPartsMaxStockArrivalWork(reader, serInfo);
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
                    retValue = (PartsMaxStockArrivalWork[])lst.ToArray(typeof(PartsMaxStockArrivalWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprStcTblRsltWork
    ///// <summary>
    /////                      仕入先電子元帳抽出結果(伝票・明細)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   仕入先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/20  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprStcTblRsltWork
    //{
    //    /// <summary>データ区分</summary>
    //    /// <remarks>0:仕入データ 1:支払データ</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>伝票日付</summary>
    //    /// <remarks>仕入日(YYYYMMDD)/支払日付</remarks>
    //    private DateTime _stockDate;

    //    /// <summary>伝票番号</summary>
    //    /// <remarks>相手先伝票番号</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>行№(明細表示)</summary>
    //    /// <remarks>仕入行番号/入金行番号</remarks>
    //    private Int32 _stockRowNo;

    //    /// <summary>仕入形式</summary>
    //    /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
    //    private Int32 _supplierFormal;

    //    /// <summary>仕入伝票区分</summary>
    //    /// <remarks>10:仕入,20:返品</remarks>
    //    private Int32 _supplierSlipCd;

    //    /// <summary>担当者名</summary>
    //    /// <remarks>仕入担当者名称/支払担当者名</remarks>
    //    private string _stockAgentName = "";

    //    /// <summary>金額</summary>
    //    /// <remarks>仕入金額計（税抜き）/支払金額</remarks>
    //    private Int64 _stockTtlPricTaxExc;

    //    /// <summary>品名(明細表示)</summary>
    //    /// <remarks>商品名称/金種名称</remarks>
    //    private string _goodsName = "";

    //    /// <summary>品番(明細表示)</summary>
    //    /// <remarks>商品番号</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>メーカーコード(明細表示)</summary>
    //    /// <remarks>商品メーカーコード</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>メーカー名称</summary>
    //    /// <remarks>メーカー名称</remarks>
    //    private string _makerName = "";

    //    /// <summary>BLコード(明細表示)</summary>
    //    /// <remarks>BL商品コード</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BLグループ(明細表示)</summary>
    //    /// <remarks>BLグループコード</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>数量(明細表示)</summary>
    //    /// <remarks>仕入数</remarks>
    //    private Double _stockCount;

    //    /// <summary>標準価格(明細表示)</summary>
    //    /// <remarks>定価（税抜，浮動）</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>オープン価格区分(明細表示)</summary>
    //    /// <remarks>0:通常／1:オープン価格</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>仕入先消費税転嫁方式コード</summary>
    //    /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
    //    private Int32 _suppCTaxLayCd;

    //    /// <summary>仕入金額計（税込み）</summary>
    //    /// <remarks>※支払金額のこと</remarks>
    //    private Int64 _stockTtlPricTaxInc;

    //    /// <summary>仕入金額消費税額</summary>
    //    private Int64 _stockPriceConsTax;

    //    /// <summary>備考１</summary>
    //    /// <remarks>仕入伝票備考1/伝票摘要</remarks>
    //    private string _supplierSlipNote1 = "";

    //    /// <summary>備考２</summary>
    //    /// <remarks>仕入伝票備考2/有効期限</remarks>
    //    private string _supplierSlipNote2 = "";

    //    /// <summary>拠点</summary>
    //    /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>発行者</summary>
    //    /// <remarks>仕入入力者名称/支払入力者名称</remarks>
    //    private string _stockInputName = "";

    //    /// <summary>仕入先コード</summary>
    //    /// <remarks>仕入先コード/仕入先コード</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>仕入先名</summary>
    //    /// <remarks>仕入先略称/仕入先略称</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>在取(明細表示)</summary>
    //    /// <remarks>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
    //    private Int32 _stockOrderDivCd;

    //    /// <summary>倉庫(明細表示)</summary>
    //    /// <remarks>倉庫名称</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>棚番(明細表示)</summary>
    //    /// <remarks>倉庫棚番</remarks>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>ＵＯＥリマーク１</summary>
    //    /// <remarks>ＵＯＥリマーク１</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>ＵＯＥリマーク２</summary>
    //    /// <remarks>ＵＯＥリマーク２</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>仕入SEQ/支払№</summary>
    //    /// <remarks>仕入伝票番号/支払伝票番号</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>計上日</summary>
    //    /// <remarks>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
    //    private DateTime _stockAddUpADate;

    //    /// <summary>買掛区分</summary>
    //    /// <remarks>買掛区分(0:買掛なし,1:買掛)</remarks>
    //    private Int32 _accPayDivCd;

    //    /// <summary>赤伝区分</summary>
    //    /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>同時売上伝票番号(明細表示)</summary>
    //    /// <remarks>売上伝票番号</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>同時売上日付(明細表示)</summary>
    //    /// <remarks>売上日付</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>得意先コード(明細表示)</summary>
    //    /// <remarks>得意先コード</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>得意先名(明細表示)</summary>
    //    /// <remarks>得意先略称</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>拠点コード</summary>
    //    /// <remarks>拠点コード</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>倉庫コード</summary>
    //    /// <remarks>倉庫コード</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>仕入先総額表示方法区分</summary>
    //    /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
    //    private Int32 _suppTtlAmntDspWayCd;

    //    /// <summary>課税区分</summary>
    //    /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
    //    private Int32 _taxationCode;

    //    /// <summary>仕入金額消費税額（内税）[伝票]</summary>
    //    /// <remarks>値引前の内税商品の消費税</remarks>
    //    private Int64 _stckPrcConsTaxInclu;

    //    /// <summary>仕入値引消費税額（内税）[伝票]</summary>
    //    /// <remarks>内税商品値引の消費税額</remarks>
    //    private Int64 _stckDisTtlTaxInclu;


    //    /// public propaty name  :  DataDiv
    //    /// <summary>データ区分プロパティ</summary>
    //    /// <value>0:仕入データ 1:支払データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   データ区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DataDiv
    //    {
    //        get { return _dataDiv; }
    //        set { _dataDiv = value; }
    //    }

    //    /// public propaty name  :  StockDate
    //    /// <summary>伝票日付プロパティ</summary>
    //    /// <value>仕入日(YYYYMMDD)/支払日付</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime StockDate
    //    {
    //        get { return _stockDate; }
    //        set { _stockDate = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>伝票番号プロパティ</summary>
    //    /// <value>相手先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  StockRowNo
    //    /// <summary>行№(明細表示)プロパティ</summary>
    //    /// <value>仕入行番号/入金行番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   行№(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockRowNo
    //    {
    //        get { return _stockRowNo; }
    //        set { _stockRowNo = value; }
    //    }

    //    /// public propaty name  :  SupplierFormal
    //    /// <summary>仕入形式プロパティ</summary>
    //    /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入形式プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierFormal
    //    {
    //        get { return _supplierFormal; }
    //        set { _supplierFormal = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipCd
    //    /// <summary>仕入伝票区分プロパティ</summary>
    //    /// <value>10:仕入,20:返品</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipCd
    //    {
    //        get { return _supplierSlipCd; }
    //        set { _supplierSlipCd = value; }
    //    }

    //    /// public propaty name  :  StockAgentName
    //    /// <summary>担当者名プロパティ</summary>
    //    /// <value>仕入担当者名称/支払担当者名</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   担当者名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string StockAgentName
    //    {
    //        get { return _stockAgentName; }
    //        set { _stockAgentName = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxExc
    //    /// <summary>金額プロパティ</summary>
    //    /// <value>仕入金額計（税抜き）/支払金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxExc
    //    {
    //        get { return _stockTtlPricTaxExc; }
    //        set { _stockTtlPricTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>品名(明細表示)プロパティ</summary>
    //    /// <value>商品名称/金種名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品名(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>品番(明細表示)プロパティ</summary>
    //    /// <value>商品番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品番(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>メーカーコード(明細表示)プロパティ</summary>
    //    /// <value>商品メーカーコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカーコード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get { return _goodsMakerCd; }
    //        set { _goodsMakerCd = value; }
    //    }

    //    /// public propaty name  :  MakerName
    //    /// <summary>メーカー名称プロパティ</summary>
    //    /// <value>メーカー名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカー名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string MakerName
    //    {
    //        get { return _makerName; }
    //        set { _makerName = value; }
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BLコード(明細表示)プロパティ</summary>
    //    /// <value>BL商品コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BLコード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BLグループ(明細表示)プロパティ</summary>
    //    /// <value>BLグループコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BLグループ(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  StockCount
    //    /// <summary>数量(明細表示)プロパティ</summary>
    //    /// <value>仕入数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   数量(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StockCount
    //    {
    //        get { return _stockCount; }
    //        set { _stockCount = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>標準価格(明細表示)プロパティ</summary>
    //    /// <value>定価（税抜，浮動）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   標準価格(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>オープン価格区分(明細表示)プロパティ</summary>
    //    /// <value>0:通常／1:オープン価格</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   オープン価格区分(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SuppCTaxLayCd
    //    /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
    //    /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SuppCTaxLayCd
    //    {
    //        get { return _suppCTaxLayCd; }
    //        set { _suppCTaxLayCd = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxInc
    //    /// <summary>仕入金額計（税込み）プロパティ</summary>
    //    /// <value>※支払金額のこと</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxInc
    //    {
    //        get { return _stockTtlPricTaxInc; }
    //        set { _stockTtlPricTaxInc = value; }
    //    }

    //    /// public propaty name  :  StockPriceConsTax
    //    /// <summary>仕入金額消費税額プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額消費税額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockPriceConsTax
    //    {
    //        get { return _stockPriceConsTax; }
    //        set { _stockPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote1
    //    /// <summary>備考１プロパティ</summary>
    //    /// <value>仕入伝票備考1/伝票摘要</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSlipNote1
    //    {
    //        get { return _supplierSlipNote1; }
    //        set { _supplierSlipNote1 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote2
    //    /// <summary>備考２プロパティ</summary>
    //    /// <value>仕入伝票備考2/有効期限</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSlipNote2
    //    {
    //        get { return _supplierSlipNote2; }
    //        set { _supplierSlipNote2 = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>拠点プロパティ</summary>
    //    /// <value>拠点ガイド名称/計上拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  StockInputName
    //    /// <summary>発行者プロパティ</summary>
    //    /// <value>仕入入力者名称/支払入力者名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発行者プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string StockInputName
    //    {
    //        get { return _stockInputName; }
    //        set { _stockInputName = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>仕入先コードプロパティ</summary>
    //    /// <value>仕入先コード/仕入先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get { return _supplierCd; }
    //        set { _supplierCd = value; }
    //    }

    //    /// public propaty name  :  SupplierSnm
    //    /// <summary>仕入先名プロパティ</summary>
    //    /// <value>仕入先略称/仕入先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  StockOrderDivCd
    //    /// <summary>在取(明細表示)プロパティ</summary>
    //    /// <value>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   在取(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockOrderDivCd
    //    {
    //        get { return _stockOrderDivCd; }
    //        set { _stockOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>倉庫(明細表示)プロパティ</summary>
    //    /// <value>倉庫名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>棚番(明細表示)プロパティ</summary>
    //    /// <value>倉庫棚番</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   棚番(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>ＵＯＥリマーク１プロパティ</summary>
    //    /// <value>ＵＯＥリマーク１</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>ＵＯＥリマーク２プロパティ</summary>
    //    /// <value>ＵＯＥリマーク２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>仕入SEQ/支払№プロパティ</summary>
    //    /// <value>仕入伝票番号/支払伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入SEQ/支払№プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  StockAddUpADate
    //    /// <summary>計上日プロパティ</summary>
    //    /// <value>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime StockAddUpADate
    //    {
    //        get { return _stockAddUpADate; }
    //        set { _stockAddUpADate = value; }
    //    }

    //    /// public propaty name  :  AccPayDivCd
    //    /// <summary>買掛区分プロパティ</summary>
    //    /// <value>買掛区分(0:買掛なし,1:買掛)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   買掛区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AccPayDivCd
    //    {
    //        get { return _accPayDivCd; }
    //        set { _accPayDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>赤伝区分プロパティ</summary>
    //    /// <value>0:黒伝,1:赤伝,2:元黒</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   赤伝区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>同時売上伝票番号(明細表示)プロパティ</summary>
    //    /// <value>売上伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   同時売上伝票番号(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>同時売上日付(明細表示)プロパティ</summary>
    //    /// <value>売上日付</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   同時売上日付(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コード(明細表示)プロパティ</summary>
    //    /// <value>得意先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>得意先名(明細表示)プロパティ</summary>
    //    /// <value>得意先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先名(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// <value>拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  WarehouseCode
    //    /// <summary>倉庫コードプロパティ</summary>
    //    /// <value>倉庫コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseCode
    //    {
    //        get { return _warehouseCode; }
    //        set { _warehouseCode = value; }
    //    }

    //    /// public propaty name  :  SuppTtlAmntDspWayCd
    //    /// <summary>仕入先総額表示方法区分プロパティ</summary>
    //    /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SuppTtlAmntDspWayCd
    //    {
    //        get { return _suppTtlAmntDspWayCd; }
    //        set { _suppTtlAmntDspWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationCode
    //    /// <summary>課税区分プロパティ</summary>
    //    /// <value>0:課税,1:非課税,2:課税（内税）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   課税区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TaxationCode
    //    {
    //        get { return _taxationCode; }
    //        set { _taxationCode = value; }
    //    }

    //    /// public propaty name  :  StckPrcConsTaxInclu
    //    /// <summary>仕入金額消費税額（内税）[伝票]プロパティ</summary>
    //    /// <value>値引前の内税商品の消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額消費税額（内税）[伝票]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckPrcConsTaxInclu
    //    {
    //        get { return _stckPrcConsTaxInclu; }
    //        set { _stckPrcConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StckDisTtlTaxInclu
    //    /// <summary>仕入値引消費税額（内税）[伝票]プロパティ</summary>
    //    /// <value>内税商品値引の消費税額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入値引消費税額（内税）[伝票]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckDisTtlTaxInclu
    //    {
    //        get { return _stckDisTtlTaxInclu; }
    //        set { _stckDisTtlTaxInclu = value; }
    //    }


    //    /// <summary>
    //    /// 仕入先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SuppPrtPprStcTblRsltWork()
    //    {
    //    }
    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SuppPrtPprStcTblRsltWork).FullName));

    //        if (graph != null && graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork");

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is SuppPrtPprStcTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //データ区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //DataDiv
    //        //伝票日付
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
    //        //伝票番号
    //        serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
    //        //行№(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
    //        //仕入形式
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
    //        //仕入伝票区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
    //        //担当者名
    //        serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
    //        //金額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
    //        //品名(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //GoodsName
    //        //品番(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
    //        //メーカーコード(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
    //        //メーカー名称
    //        serInfo.MemberInfo.Add(typeof(string)); //MakerName
    //        //BLコード(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
    //        //BLグループ(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
    //        //数量(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Double)); //StockCount
    //        //標準価格(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
    //        //オープン価格区分(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
    //        //仕入先消費税転嫁方式コード
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
    //        //仕入金額計（税込み）
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
    //        //仕入金額消費税額
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
    //        //備考１
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
    //        //備考２
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
    //        //拠点
    //        serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
    //        //発行者
    //        serInfo.MemberInfo.Add(typeof(string)); //StockInputName
    //        //仕入先コード
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
    //        //仕入先名
    //        serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
    //        //在取(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
    //        //倉庫(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
    //        //棚番(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
    //        //ＵＯＥリマーク１
    //        serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
    //        //ＵＯＥリマーク２
    //        serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
    //        //仕入SEQ/支払№
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
    //        //計上日
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
    //        //買掛区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
    //        //赤伝区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
    //        //同時売上伝票番号(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
    //        //同時売上日付(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
    //        //得意先コード(明細表示)
    //        serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
    //        //得意先名(明細表示)
    //        serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
    //        //拠点コード
    //        serInfo.MemberInfo.Add(typeof(string)); //SectionCode
    //        //倉庫コード
    //        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
    //        //仕入先総額表示方法区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
    //        //課税区分
    //        serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
    //        //仕入金額消費税額（内税）[伝票]
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
    //        //仕入値引消費税額（内税）[伝票]
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is SuppPrtPprStcTblRsltWork)
    //        {
    //            SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

    //            SetSuppPrtPprStcTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is SuppPrtPprStcTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((SuppPrtPprStcTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (SuppPrtPprStcTblRsltWork temp in lst)
    //            {
    //                SetSuppPrtPprStcTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprStcTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 45;

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprStcTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp)
    //    {
    //        //データ区分
    //        writer.Write(temp.DataDiv);
    //        //伝票日付
    //        writer.Write((Int64)temp.StockDate.Ticks);
    //        //伝票番号
    //        writer.Write(temp.PartySaleSlipNum);
    //        //行№(明細表示)
    //        writer.Write(temp.StockRowNo);
    //        //仕入形式
    //        writer.Write(temp.SupplierFormal);
    //        //仕入伝票区分
    //        writer.Write(temp.SupplierSlipCd);
    //        //担当者名
    //        writer.Write(temp.StockAgentName);
    //        //金額
    //        writer.Write(temp.StockTtlPricTaxExc);
    //        //品名(明細表示)
    //        writer.Write(temp.GoodsName);
    //        //品番(明細表示)
    //        writer.Write(temp.GoodsNo);
    //        //メーカーコード(明細表示)
    //        writer.Write(temp.GoodsMakerCd);
    //        //メーカー名称
    //        writer.Write(temp.MakerName);
    //        //BLコード(明細表示)
    //        writer.Write(temp.BLGoodsCode);
    //        //BLグループ(明細表示)
    //        writer.Write(temp.BLGroupCode);
    //        //数量(明細表示)
    //        writer.Write(temp.StockCount);
    //        //標準価格(明細表示)
    //        writer.Write(temp.ListPriceTaxExcFl);
    //        //オープン価格区分(明細表示)
    //        writer.Write(temp.OpenPriceDiv);
    //        //仕入先消費税転嫁方式コード
    //        writer.Write(temp.SuppCTaxLayCd);
    //        //仕入金額計（税込み）
    //        writer.Write(temp.StockTtlPricTaxInc);
    //        //仕入金額消費税額
    //        writer.Write(temp.StockPriceConsTax);
    //        //備考１
    //        writer.Write(temp.SupplierSlipNote1);
    //        //備考２
    //        writer.Write(temp.SupplierSlipNote2);
    //        //拠点
    //        writer.Write(temp.SectionGuideNm);
    //        //発行者
    //        writer.Write(temp.StockInputName);
    //        //仕入先コード
    //        writer.Write(temp.SupplierCd);
    //        //仕入先名
    //        writer.Write(temp.SupplierSnm);
    //        //在取(明細表示)
    //        writer.Write(temp.StockOrderDivCd);
    //        //倉庫(明細表示)
    //        writer.Write(temp.WarehouseName);
    //        //棚番(明細表示)
    //        writer.Write(temp.WarehouseShelfNo);
    //        //ＵＯＥリマーク１
    //        writer.Write(temp.UoeRemark1);
    //        //ＵＯＥリマーク２
    //        writer.Write(temp.UoeRemark2);
    //        //仕入SEQ/支払№
    //        writer.Write(temp.SupplierSlipNo);
    //        //計上日
    //        writer.Write((Int64)temp.StockAddUpADate.Ticks);
    //        //買掛区分
    //        writer.Write(temp.AccPayDivCd);
    //        //赤伝区分
    //        writer.Write(temp.DebitNoteDiv);
    //        //同時売上伝票番号(明細表示)
    //        writer.Write(temp.SalesSlipNum);
    //        //同時売上日付(明細表示)
    //        writer.Write((Int64)temp.SalesDate.Ticks);
    //        //得意先コード(明細表示)
    //        writer.Write(temp.CustomerCode);
    //        //得意先名(明細表示)
    //        writer.Write(temp.CustomerSnm);
    //        //拠点コード
    //        writer.Write(temp.SectionCode);
    //        //倉庫コード
    //        writer.Write(temp.WarehouseCode);
    //        //仕入先総額表示方法区分
    //        writer.Write(temp.SuppTtlAmntDspWayCd);
    //        //課税区分
    //        writer.Write(temp.TaxationCode);
    //        //仕入金額消費税額（内税）[伝票]
    //        writer.Write(temp.StckPrcConsTaxInclu);
    //        //仕入値引消費税額（内税）[伝票]
    //        writer.Write(temp.StckDisTtlTaxInclu);

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

    //        //データ区分
    //        temp.DataDiv = reader.ReadInt32();
    //        //伝票日付
    //        temp.StockDate = new DateTime(reader.ReadInt64());
    //        //伝票番号
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //行№(明細表示)
    //        temp.StockRowNo = reader.ReadInt32();
    //        //仕入形式
    //        temp.SupplierFormal = reader.ReadInt32();
    //        //仕入伝票区分
    //        temp.SupplierSlipCd = reader.ReadInt32();
    //        //担当者名
    //        temp.StockAgentName = reader.ReadString();
    //        //金額
    //        temp.StockTtlPricTaxExc = reader.ReadInt64();
    //        //品名(明細表示)
    //        temp.GoodsName = reader.ReadString();
    //        //品番(明細表示)
    //        temp.GoodsNo = reader.ReadString();
    //        //メーカーコード(明細表示)
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //メーカー名称
    //        temp.MakerName = reader.ReadString();
    //        //BLコード(明細表示)
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BLグループ(明細表示)
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //数量(明細表示)
    //        temp.StockCount = reader.ReadDouble();
    //        //標準価格(明細表示)
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //オープン価格区分(明細表示)
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //仕入先消費税転嫁方式コード
    //        temp.SuppCTaxLayCd = reader.ReadInt32();
    //        //仕入金額計（税込み）
    //        temp.StockTtlPricTaxInc = reader.ReadInt64();
    //        //仕入金額消費税額
    //        temp.StockPriceConsTax = reader.ReadInt64();
    //        //備考１
    //        temp.SupplierSlipNote1 = reader.ReadString();
    //        //備考２
    //        temp.SupplierSlipNote2 = reader.ReadString();
    //        //拠点
    //        temp.SectionGuideNm = reader.ReadString();
    //        //発行者
    //        temp.StockInputName = reader.ReadString();
    //        //仕入先コード
    //        temp.SupplierCd = reader.ReadInt32();
    //        //仕入先名
    //        temp.SupplierSnm = reader.ReadString();
    //        //在取(明細表示)
    //        temp.StockOrderDivCd = reader.ReadInt32();
    //        //倉庫(明細表示)
    //        temp.WarehouseName = reader.ReadString();
    //        //棚番(明細表示)
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //ＵＯＥリマーク１
    //        temp.UoeRemark1 = reader.ReadString();
    //        //ＵＯＥリマーク２
    //        temp.UoeRemark2 = reader.ReadString();
    //        //仕入SEQ/支払№
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //計上日
    //        temp.StockAddUpADate = new DateTime(reader.ReadInt64());
    //        //買掛区分
    //        temp.AccPayDivCd = reader.ReadInt32();
    //        //赤伝区分
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //同時売上伝票番号(明細表示)
    //        temp.SalesSlipNum = reader.ReadString();
    //        //同時売上日付(明細表示)
    //        temp.SalesDate = new DateTime(reader.ReadInt64());
    //        //得意先コード(明細表示)
    //        temp.CustomerCode = reader.ReadInt32();
    //        //得意先名(明細表示)
    //        temp.CustomerSnm = reader.ReadString();
    //        //拠点コード
    //        temp.SectionCode = reader.ReadString();
    //        //倉庫コード
    //        temp.WarehouseCode = reader.ReadString();
    //        //仕入先総額表示方法区分
    //        temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
    //        //課税区分
    //        temp.TaxationCode = reader.ReadInt32();
    //        //仕入金額消費税額（内税）[伝票]
    //        temp.StckPrcConsTaxInclu = reader.ReadInt64();
    //        //仕入値引消費税額（内税）[伝票]
    //        temp.StckDisTtlTaxInclu = reader.ReadInt64();


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if (oMemberType is Type)
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
    //                if (t.Equals(typeof(int)))
    //                {
    //                    optCount = Convert.ToInt32(oData);
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if (oMemberType is string)
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
    //                object userData = formatter.Deserialize(reader);  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork(reader, serInfo);
    //            lst.Add(temp);
    //        }
    //        switch (serInfo.RetTypeInfo)
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray(typeof(SuppPrtPprStcTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprStcTblRsltWork
    ///// <summary>
    /////                      仕入先電子元帳抽出結果(伝票・明細)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   仕入先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/02/19  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprStcTblRsltWork
    //{
    //    /// <summary>データ区分</summary>
    //    /// <remarks>0:仕入データ 1:支払データ</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>伝票日付</summary>
    //    /// <remarks>仕入日(YYYYMMDD)/支払日付</remarks>
    //    private DateTime _stockDate;

    //    /// <summary>伝票番号</summary>
    //    /// <remarks>相手先伝票番号</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>行№(明細表示)</summary>
    //    /// <remarks>仕入行番号/入金行番号</remarks>
    //    private Int32 _stockRowNo;

    //    /// <summary>仕入形式</summary>
    //    /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
    //    private Int32 _supplierFormal;

    //    /// <summary>仕入伝票区分</summary>
    //    /// <remarks>10:仕入,20:返品</remarks>
    //    private Int32 _supplierSlipCd;

    //    /// <summary>担当者名</summary>
    //    /// <remarks>仕入担当者名称/支払担当者名</remarks>
    //    private string _stockAgentName = "";

    //    /// <summary>金額</summary>
    //    /// <remarks>仕入金額計（税抜き）/支払金額</remarks>
    //    private Int64 _stockTtlPricTaxExc;

    //    /// <summary>品名(明細表示)</summary>
    //    /// <remarks>商品名称/金種名称</remarks>
    //    private string _goodsName = "";

    //    /// <summary>品番(明細表示)</summary>
    //    /// <remarks>商品番号</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>メーカーコード(明細表示)</summary>
    //    /// <remarks>商品メーカーコード</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>メーカー名称</summary>
    //    /// <remarks>メーカー名称</remarks>
    //    private string _makerName = "";

    //    /// <summary>BLコード(明細表示)</summary>
    //    /// <remarks>BL商品コード</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BLグループ(明細表示)</summary>
    //    /// <remarks>BLグループコード</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>数量(明細表示)</summary>
    //    /// <remarks>仕入数</remarks>
    //    private Double _stockCount;

    //    /// <summary>標準価格(明細表示)</summary>
    //    /// <remarks>定価（税抜，浮動）</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>オープン価格区分(明細表示)</summary>
    //    /// <remarks>0:通常／1:オープン価格</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>仕入先消費税転嫁方式コード</summary>
    //    /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
    //    private Int32 _suppCTaxLayCd;

    //    /// <summary>仕入金額計（税込み）</summary>
    //    /// <remarks>※支払金額のこと</remarks>
    //    private Int64 _stockTtlPricTaxInc;

    //    /// <summary>仕入金額消費税額</summary>
    //    private Int64 _stockPriceConsTax;

    //    /// <summary>備考１</summary>
    //    /// <remarks>仕入伝票備考1/伝票摘要</remarks>
    //    private string _supplierSlipNote1 = "";

    //    /// <summary>備考２</summary>
    //    /// <remarks>仕入伝票備考2/有効期限</remarks>
    //    private string _supplierSlipNote2 = "";

    //    /// <summary>拠点</summary>
    //    /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>発行者</summary>
    //    /// <remarks>仕入入力者名称/支払入力者名称</remarks>
    //    private string _stockInputName = "";

    //    /// <summary>仕入先コード</summary>
    //    /// <remarks>仕入先コード/仕入先コード</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>仕入先名</summary>
    //    /// <remarks>仕入先略称/仕入先略称</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>在取(明細表示)</summary>
    //    /// <remarks>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
    //    private Int32 _stockOrderDivCd;

    //    /// <summary>倉庫(明細表示)</summary>
    //    /// <remarks>倉庫名称</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>棚番(明細表示)</summary>
    //    /// <remarks>倉庫棚番</remarks>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>ＵＯＥリマーク１</summary>
    //    /// <remarks>ＵＯＥリマーク１</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>ＵＯＥリマーク２</summary>
    //    /// <remarks>ＵＯＥリマーク２</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>仕入SEQ/支払№</summary>
    //    /// <remarks>仕入伝票番号/支払伝票番号</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>計上日</summary>
    //    /// <remarks>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
    //    private DateTime _stockAddUpADate;

    //    /// <summary>買掛区分</summary>
    //    /// <remarks>買掛区分(0:買掛なし,1:買掛)</remarks>
    //    private Int32 _accPayDivCd;

    //    /// <summary>赤伝区分</summary>
    //    /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>同時売上伝票番号(明細表示)</summary>
    //    /// <remarks>売上伝票番号</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>同時売上日付(明細表示)</summary>
    //    /// <remarks>売上日付</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>得意先コード(明細表示)</summary>
    //    /// <remarks>得意先コード</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>得意先名(明細表示)</summary>
    //    /// <remarks>得意先略称</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>拠点コード</summary>
    //    /// <remarks>拠点コード</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>倉庫コード</summary>
    //    /// <remarks>倉庫コード</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>仕入先総額表示方法区分</summary>
    //    /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
    //    private Int32 _suppTtlAmntDspWayCd;

    //    /// <summary>課税区分</summary>
    //    /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
    //    private Int32 _taxationCode;

    //    /// <summary>仕入金額消費税額（内税）[伝票]</summary>
    //    /// <remarks>値引前の内税商品の消費税</remarks>
    //    private Int64 _stckPrcConsTaxInclu;

    //    /// <summary>仕入値引消費税額（内税）[伝票]</summary>
    //    /// <remarks>内税商品値引の消費税額</remarks>
    //    private Int64 _stckDisTtlTaxInclu;

    //    /// <summary>仕入単価（税抜，浮動）[明細表示]</summary>
    //    /// <remarks>税抜き</remarks>
    //    private Double _stockUnitPriceFl;


    //    /// public propaty name  :  DataDiv
    //    /// <summary>データ区分プロパティ</summary>
    //    /// <value>0:仕入データ 1:支払データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   データ区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DataDiv
    //    {
    //        get { return _dataDiv; }
    //        set { _dataDiv = value; }
    //    }

    //    /// public propaty name  :  StockDate
    //    /// <summary>伝票日付プロパティ</summary>
    //    /// <value>仕入日(YYYYMMDD)/支払日付</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime StockDate
    //    {
    //        get { return _stockDate; }
    //        set { _stockDate = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>伝票番号プロパティ</summary>
    //    /// <value>相手先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  StockRowNo
    //    /// <summary>行№(明細表示)プロパティ</summary>
    //    /// <value>仕入行番号/入金行番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   行№(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockRowNo
    //    {
    //        get { return _stockRowNo; }
    //        set { _stockRowNo = value; }
    //    }

    //    /// public propaty name  :  SupplierFormal
    //    /// <summary>仕入形式プロパティ</summary>
    //    /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入形式プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierFormal
    //    {
    //        get { return _supplierFormal; }
    //        set { _supplierFormal = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipCd
    //    /// <summary>仕入伝票区分プロパティ</summary>
    //    /// <value>10:仕入,20:返品</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipCd
    //    {
    //        get { return _supplierSlipCd; }
    //        set { _supplierSlipCd = value; }
    //    }

    //    /// public propaty name  :  StockAgentName
    //    /// <summary>担当者名プロパティ</summary>
    //    /// <value>仕入担当者名称/支払担当者名</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   担当者名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string StockAgentName
    //    {
    //        get { return _stockAgentName; }
    //        set { _stockAgentName = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxExc
    //    /// <summary>金額プロパティ</summary>
    //    /// <value>仕入金額計（税抜き）/支払金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxExc
    //    {
    //        get { return _stockTtlPricTaxExc; }
    //        set { _stockTtlPricTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>品名(明細表示)プロパティ</summary>
    //    /// <value>商品名称/金種名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品名(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>品番(明細表示)プロパティ</summary>
    //    /// <value>商品番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品番(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>メーカーコード(明細表示)プロパティ</summary>
    //    /// <value>商品メーカーコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカーコード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get { return _goodsMakerCd; }
    //        set { _goodsMakerCd = value; }
    //    }

    //    /// public propaty name  :  MakerName
    //    /// <summary>メーカー名称プロパティ</summary>
    //    /// <value>メーカー名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカー名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string MakerName
    //    {
    //        get { return _makerName; }
    //        set { _makerName = value; }
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BLコード(明細表示)プロパティ</summary>
    //    /// <value>BL商品コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BLコード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BLグループ(明細表示)プロパティ</summary>
    //    /// <value>BLグループコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BLグループ(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  StockCount
    //    /// <summary>数量(明細表示)プロパティ</summary>
    //    /// <value>仕入数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   数量(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StockCount
    //    {
    //        get { return _stockCount; }
    //        set { _stockCount = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>標準価格(明細表示)プロパティ</summary>
    //    /// <value>定価（税抜，浮動）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   標準価格(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>オープン価格区分(明細表示)プロパティ</summary>
    //    /// <value>0:通常／1:オープン価格</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   オープン価格区分(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SuppCTaxLayCd
    //    /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
    //    /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先消費税転嫁方式コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SuppCTaxLayCd
    //    {
    //        get { return _suppCTaxLayCd; }
    //        set { _suppCTaxLayCd = value; }
    //    }

    //    /// public propaty name  :  StockTtlPricTaxInc
    //    /// <summary>仕入金額計（税込み）プロパティ</summary>
    //    /// <value>※支払金額のこと</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockTtlPricTaxInc
    //    {
    //        get { return _stockTtlPricTaxInc; }
    //        set { _stockTtlPricTaxInc = value; }
    //    }

    //    /// public propaty name  :  StockPriceConsTax
    //    /// <summary>仕入金額消費税額プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額消費税額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StockPriceConsTax
    //    {
    //        get { return _stockPriceConsTax; }
    //        set { _stockPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote1
    //    /// <summary>備考１プロパティ</summary>
    //    /// <value>仕入伝票備考1/伝票摘要</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSlipNote1
    //    {
    //        get { return _supplierSlipNote1; }
    //        set { _supplierSlipNote1 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNote2
    //    /// <summary>備考２プロパティ</summary>
    //    /// <value>仕入伝票備考2/有効期限</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSlipNote2
    //    {
    //        get { return _supplierSlipNote2; }
    //        set { _supplierSlipNote2 = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>拠点プロパティ</summary>
    //    /// <value>拠点ガイド名称/計上拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  StockInputName
    //    /// <summary>発行者プロパティ</summary>
    //    /// <value>仕入入力者名称/支払入力者名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発行者プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string StockInputName
    //    {
    //        get { return _stockInputName; }
    //        set { _stockInputName = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>仕入先コードプロパティ</summary>
    //    /// <value>仕入先コード/仕入先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get { return _supplierCd; }
    //        set { _supplierCd = value; }
    //    }

    //    /// public propaty name  :  SupplierSnm
    //    /// <summary>仕入先名プロパティ</summary>
    //    /// <value>仕入先略称/仕入先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  StockOrderDivCd
    //    /// <summary>在取(明細表示)プロパティ</summary>
    //    /// <value>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   在取(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 StockOrderDivCd
    //    {
    //        get { return _stockOrderDivCd; }
    //        set { _stockOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>倉庫(明細表示)プロパティ</summary>
    //    /// <value>倉庫名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>棚番(明細表示)プロパティ</summary>
    //    /// <value>倉庫棚番</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   棚番(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>ＵＯＥリマーク１プロパティ</summary>
    //    /// <value>ＵＯＥリマーク１</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>ＵＯＥリマーク２プロパティ</summary>
    //    /// <value>ＵＯＥリマーク２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>仕入SEQ/支払№プロパティ</summary>
    //    /// <value>仕入伝票番号/支払伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入SEQ/支払№プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  StockAddUpADate
    //    /// <summary>計上日プロパティ</summary>
    //    /// <value>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime StockAddUpADate
    //    {
    //        get { return _stockAddUpADate; }
    //        set { _stockAddUpADate = value; }
    //    }

    //    /// public propaty name  :  AccPayDivCd
    //    /// <summary>買掛区分プロパティ</summary>
    //    /// <value>買掛区分(0:買掛なし,1:買掛)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   買掛区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AccPayDivCd
    //    {
    //        get { return _accPayDivCd; }
    //        set { _accPayDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>赤伝区分プロパティ</summary>
    //    /// <value>0:黒伝,1:赤伝,2:元黒</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   赤伝区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>同時売上伝票番号(明細表示)プロパティ</summary>
    //    /// <value>売上伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   同時売上伝票番号(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>同時売上日付(明細表示)プロパティ</summary>
    //    /// <value>売上日付</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   同時売上日付(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コード(明細表示)プロパティ</summary>
    //    /// <value>得意先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コード(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>得意先名(明細表示)プロパティ</summary>
    //    /// <value>得意先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先名(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// <value>拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  WarehouseCode
    //    /// <summary>倉庫コードプロパティ</summary>
    //    /// <value>倉庫コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseCode
    //    {
    //        get { return _warehouseCode; }
    //        set { _warehouseCode = value; }
    //    }

    //    /// public propaty name  :  SuppTtlAmntDspWayCd
    //    /// <summary>仕入先総額表示方法区分プロパティ</summary>
    //    /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先総額表示方法区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SuppTtlAmntDspWayCd
    //    {
    //        get { return _suppTtlAmntDspWayCd; }
    //        set { _suppTtlAmntDspWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationCode
    //    /// <summary>課税区分プロパティ</summary>
    //    /// <value>0:課税,1:非課税,2:課税（内税）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   課税区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TaxationCode
    //    {
    //        get { return _taxationCode; }
    //        set { _taxationCode = value; }
    //    }

    //    /// public propaty name  :  StckPrcConsTaxInclu
    //    /// <summary>仕入金額消費税額（内税）[伝票]プロパティ</summary>
    //    /// <value>値引前の内税商品の消費税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入金額消費税額（内税）[伝票]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckPrcConsTaxInclu
    //    {
    //        get { return _stckPrcConsTaxInclu; }
    //        set { _stckPrcConsTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StckDisTtlTaxInclu
    //    /// <summary>仕入値引消費税額（内税）[伝票]プロパティ</summary>
    //    /// <value>内税商品値引の消費税額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入値引消費税額（内税）[伝票]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 StckDisTtlTaxInclu
    //    {
    //        get { return _stckDisTtlTaxInclu; }
    //        set { _stckDisTtlTaxInclu = value; }
    //    }

    //    /// public propaty name  :  StockUnitPriceFl
    //    /// <summary>仕入単価（税抜，浮動）[明細表示]プロパティ</summary>
    //    /// <value>税抜き</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入単価（税抜，浮動）[明細表示]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StockUnitPriceFl
    //    {
    //        get { return _stockUnitPriceFl; }
    //        set { _stockUnitPriceFl = value; }
    //    }


    //    /// <summary>
    //    /// 仕入先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public SuppPrtPprStcTblRsltWork()
    //    {
    //    }
    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( SuppPrtPprStcTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork" );

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is SuppPrtPprStcTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //データ区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
    //        //伝票日付
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockDate
    //        //伝票番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
    //        //行№(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockRowNo
    //        //仕入形式
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierFormal
    //        //仕入伝票区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipCd
    //        //担当者名
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentName
    //        //金額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxExc
    //        //品名(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
    //        //品番(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
    //        //メーカーコード(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
    //        //メーカー名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
    //        //BLコード(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
    //        //BLグループ(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
    //        //数量(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StockCount
    //        //標準価格(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
    //        //オープン価格区分(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
    //        //仕入先消費税転嫁方式コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppCTaxLayCd
    //        //仕入金額計（税込み）
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxInc
    //        //仕入金額消費税額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTax
    //        //備考１
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote1
    //        //備考２
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote2
    //        //拠点
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
    //        //発行者
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockInputName
    //        //仕入先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
    //        //仕入先名
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
    //        //在取(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockOrderDivCd
    //        //倉庫(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
    //        //棚番(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
    //        //ＵＯＥリマーク１
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
    //        //ＵＯＥリマーク２
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
    //        //仕入SEQ/支払№
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
    //        //計上日
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockAddUpADate
    //        //買掛区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccPayDivCd
    //        //赤伝区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
    //        //同時売上伝票番号(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
    //        //同時売上日付(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
    //        //得意先コード(明細表示)
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
    //        //得意先名(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
    //        //拠点コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
    //        //倉庫コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
    //        //仕入先総額表示方法区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppTtlAmntDspWayCd
    //        //課税区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationCode
    //        //仕入金額消費税額（内税）[伝票]
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckPrcConsTaxInclu
    //        //仕入値引消費税額（内税）[伝票]
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckDisTtlTaxInclu
    //        //仕入単価（税抜，浮動）[明細表示]
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StockUnitPriceFl


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is SuppPrtPprStcTblRsltWork )
    //        {
    //            SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

    //            SetSuppPrtPprStcTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is SuppPrtPprStcTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (SuppPrtPprStcTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( SuppPrtPprStcTblRsltWork temp in lst )
    //            {
    //                SetSuppPrtPprStcTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprStcTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 46;

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprStcTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp )
    //    {
    //        //データ区分
    //        writer.Write( temp.DataDiv );
    //        //伝票日付
    //        writer.Write( (Int64)temp.StockDate.Ticks );
    //        //伝票番号
    //        writer.Write( temp.PartySaleSlipNum );
    //        //行№(明細表示)
    //        writer.Write( temp.StockRowNo );
    //        //仕入形式
    //        writer.Write( temp.SupplierFormal );
    //        //仕入伝票区分
    //        writer.Write( temp.SupplierSlipCd );
    //        //担当者名
    //        writer.Write( temp.StockAgentName );
    //        //金額
    //        writer.Write( temp.StockTtlPricTaxExc );
    //        //品名(明細表示)
    //        writer.Write( temp.GoodsName );
    //        //品番(明細表示)
    //        writer.Write( temp.GoodsNo );
    //        //メーカーコード(明細表示)
    //        writer.Write( temp.GoodsMakerCd );
    //        //メーカー名称
    //        writer.Write( temp.MakerName );
    //        //BLコード(明細表示)
    //        writer.Write( temp.BLGoodsCode );
    //        //BLグループ(明細表示)
    //        writer.Write( temp.BLGroupCode );
    //        //数量(明細表示)
    //        writer.Write( temp.StockCount );
    //        //標準価格(明細表示)
    //        writer.Write( temp.ListPriceTaxExcFl );
    //        //オープン価格区分(明細表示)
    //        writer.Write( temp.OpenPriceDiv );
    //        //仕入先消費税転嫁方式コード
    //        writer.Write( temp.SuppCTaxLayCd );
    //        //仕入金額計（税込み）
    //        writer.Write( temp.StockTtlPricTaxInc );
    //        //仕入金額消費税額
    //        writer.Write( temp.StockPriceConsTax );
    //        //備考１
    //        writer.Write( temp.SupplierSlipNote1 );
    //        //備考２
    //        writer.Write( temp.SupplierSlipNote2 );
    //        //拠点
    //        writer.Write( temp.SectionGuideNm );
    //        //発行者
    //        writer.Write( temp.StockInputName );
    //        //仕入先コード
    //        writer.Write( temp.SupplierCd );
    //        //仕入先名
    //        writer.Write( temp.SupplierSnm );
    //        //在取(明細表示)
    //        writer.Write( temp.StockOrderDivCd );
    //        //倉庫(明細表示)
    //        writer.Write( temp.WarehouseName );
    //        //棚番(明細表示)
    //        writer.Write( temp.WarehouseShelfNo );
    //        //ＵＯＥリマーク１
    //        writer.Write( temp.UoeRemark1 );
    //        //ＵＯＥリマーク２
    //        writer.Write( temp.UoeRemark2 );
    //        //仕入SEQ/支払№
    //        writer.Write( temp.SupplierSlipNo );
    //        //計上日
    //        writer.Write( (Int64)temp.StockAddUpADate.Ticks );
    //        //買掛区分
    //        writer.Write( temp.AccPayDivCd );
    //        //赤伝区分
    //        writer.Write( temp.DebitNoteDiv );
    //        //同時売上伝票番号(明細表示)
    //        writer.Write( temp.SalesSlipNum );
    //        //同時売上日付(明細表示)
    //        writer.Write( (Int64)temp.SalesDate.Ticks );
    //        //得意先コード(明細表示)
    //        writer.Write( temp.CustomerCode );
    //        //得意先名(明細表示)
    //        writer.Write( temp.CustomerSnm );
    //        //拠点コード
    //        writer.Write( temp.SectionCode );
    //        //倉庫コード
    //        writer.Write( temp.WarehouseCode );
    //        //仕入先総額表示方法区分
    //        writer.Write( temp.SuppTtlAmntDspWayCd );
    //        //課税区分
    //        writer.Write( temp.TaxationCode );
    //        //仕入金額消費税額（内税）[伝票]
    //        writer.Write( temp.StckPrcConsTaxInclu );
    //        //仕入値引消費税額（内税）[伝票]
    //        writer.Write( temp.StckDisTtlTaxInclu );
    //        //仕入単価（税抜，浮動）[明細表示]
    //        writer.Write( temp.StockUnitPriceFl );

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprStcTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

    //        //データ区分
    //        temp.DataDiv = reader.ReadInt32();
    //        //伝票日付
    //        temp.StockDate = new DateTime( reader.ReadInt64() );
    //        //伝票番号
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //行№(明細表示)
    //        temp.StockRowNo = reader.ReadInt32();
    //        //仕入形式
    //        temp.SupplierFormal = reader.ReadInt32();
    //        //仕入伝票区分
    //        temp.SupplierSlipCd = reader.ReadInt32();
    //        //担当者名
    //        temp.StockAgentName = reader.ReadString();
    //        //金額
    //        temp.StockTtlPricTaxExc = reader.ReadInt64();
    //        //品名(明細表示)
    //        temp.GoodsName = reader.ReadString();
    //        //品番(明細表示)
    //        temp.GoodsNo = reader.ReadString();
    //        //メーカーコード(明細表示)
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //メーカー名称
    //        temp.MakerName = reader.ReadString();
    //        //BLコード(明細表示)
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BLグループ(明細表示)
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //数量(明細表示)
    //        temp.StockCount = reader.ReadDouble();
    //        //標準価格(明細表示)
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //オープン価格区分(明細表示)
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //仕入先消費税転嫁方式コード
    //        temp.SuppCTaxLayCd = reader.ReadInt32();
    //        //仕入金額計（税込み）
    //        temp.StockTtlPricTaxInc = reader.ReadInt64();
    //        //仕入金額消費税額
    //        temp.StockPriceConsTax = reader.ReadInt64();
    //        //備考１
    //        temp.SupplierSlipNote1 = reader.ReadString();
    //        //備考２
    //        temp.SupplierSlipNote2 = reader.ReadString();
    //        //拠点
    //        temp.SectionGuideNm = reader.ReadString();
    //        //発行者
    //        temp.StockInputName = reader.ReadString();
    //        //仕入先コード
    //        temp.SupplierCd = reader.ReadInt32();
    //        //仕入先名
    //        temp.SupplierSnm = reader.ReadString();
    //        //在取(明細表示)
    //        temp.StockOrderDivCd = reader.ReadInt32();
    //        //倉庫(明細表示)
    //        temp.WarehouseName = reader.ReadString();
    //        //棚番(明細表示)
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //ＵＯＥリマーク１
    //        temp.UoeRemark1 = reader.ReadString();
    //        //ＵＯＥリマーク２
    //        temp.UoeRemark2 = reader.ReadString();
    //        //仕入SEQ/支払№
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //計上日
    //        temp.StockAddUpADate = new DateTime( reader.ReadInt64() );
    //        //買掛区分
    //        temp.AccPayDivCd = reader.ReadInt32();
    //        //赤伝区分
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //同時売上伝票番号(明細表示)
    //        temp.SalesSlipNum = reader.ReadString();
    //        //同時売上日付(明細表示)
    //        temp.SalesDate = new DateTime( reader.ReadInt64() );
    //        //得意先コード(明細表示)
    //        temp.CustomerCode = reader.ReadInt32();
    //        //得意先名(明細表示)
    //        temp.CustomerSnm = reader.ReadString();
    //        //拠点コード
    //        temp.SectionCode = reader.ReadString();
    //        //倉庫コード
    //        temp.WarehouseCode = reader.ReadString();
    //        //仕入先総額表示方法区分
    //        temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
    //        //課税区分
    //        temp.TaxationCode = reader.ReadInt32();
    //        //仕入金額消費税額（内税）[伝票]
    //        temp.StckPrcConsTaxInclu = reader.ReadInt64();
    //        //仕入値引消費税額（内税）[伝票]
    //        temp.StckDisTtlTaxInclu = reader.ReadInt64();
    //        //仕入単価（税抜，浮動）[明細表示]
    //        temp.StockUnitPriceFl = reader.ReadDouble();


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray( typeof( SuppPrtPprStcTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}

    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL

    /// public class name:   SuppPrtPprStcTblRsltWork
    /// <summary>
    ///                      仕入先電子元帳抽出結果(伝票・明細)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/08 黄偉兵</br>
    /// <br>                 :   PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>                 :   過去分表示対応</br>
    /// <br>Update Note      :   2012/10/15 田建委</br>
    /// <br>管理番号         :   10801804-00、2012/11/14配信分</br>
    /// <br>                     Redmine#32862 価格変更した明細、色を変えるように修正</br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : FSI千田 晃久
    // 修 正 日  2013/01/21  修正内容 : 仕入返品予定機能対応
    //----------------------------------------------------------------------------//
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprStcTblRsltWork
    {
        /// <summary>データ区分</summary>
        /// <remarks>0:仕入データ 1:支払データ</remarks>
        private Int32 _dataDiv;

        /// <summary>伝票日付</summary>
        /// <remarks>仕入日(YYYYMMDD)/支払日付</remarks>
        private DateTime _stockDate;

        /// <summary>伝票番号</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>行№(明細表示)</summary>
        /// <remarks>仕入行番号/入金行番号</remarks>
        private Int32 _stockRowNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>担当者名</summary>
        /// <remarks>仕入担当者名称/支払担当者名</remarks>
        private string _stockAgentName = "";

        /// <summary>金額</summary>
        /// <remarks>仕入金額計（税抜き）/支払金額</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>品名(明細表示)</summary>
        /// <remarks>商品名称/金種名称</remarks>
        private string _goodsName = "";

        /// <summary>品番(明細表示)</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>メーカーコード(明細表示)</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>メーカー名称</remarks>
        private string _makerName = "";

        /// <summary>BLコード(明細表示)</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BLグループ(明細表示)</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>数量(明細表示)</summary>
        /// <remarks>仕入数</remarks>
        private Double _stockCount;

        /// <summary>標準価格(明細表示)</summary>
        /// <remarks>定価（税抜，浮動）</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>オープン価格区分(明細表示)</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>仕入先消費税転嫁方式コード</summary>
        /// <remarks>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>仕入金額計（税込み）</summary>
        /// <remarks>※支払金額のこと</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>仕入金額消費税額</summary>
        private Int64 _stockPriceConsTax;

        /// <summary>備考１</summary>
        /// <remarks>仕入伝票備考1/伝票摘要</remarks>
        private string _supplierSlipNote1 = "";

        /// <summary>備考２</summary>
        /// <remarks>仕入伝票備考2/有効期限</remarks>
        private string _supplierSlipNote2 = "";

        /// <summary>拠点</summary>
        /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
        private string _sectionGuideNm = "";

        // --- DEL 2009/09/08 -------------->>>>>
        // /// <summary>発行者</summary>
        // /// <remarks>仕入入力者名称/支払入力者名称</remarks>
        // private string _stockInputName = "";
        // --- DEL 2009/09/08 --------------<<<<<

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入先コード/仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名</summary>
        /// <remarks>仕入先略称/仕入先略称</remarks>
        private string _supplierSnm = "";

        /// <summary>在取(明細表示)</summary>
        /// <remarks>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>倉庫(明細表示)</summary>
        /// <remarks>倉庫名称</remarks>
        private string _warehouseName = "";

        /// <summary>棚番(明細表示)</summary>
        /// <remarks>倉庫棚番</remarks>
        private string _warehouseShelfNo = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>仕入SEQ/支払№</summary>
        /// <remarks>仕入伝票番号/支払伝票番号</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>計上日</summary>
        /// <remarks>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>買掛区分</summary>
        /// <remarks>買掛区分(0:買掛なし,1:買掛)</remarks>
        private Int32 _accPayDivCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>同時売上伝票番号(明細表示)</summary>
        /// <remarks>売上伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>同時売上日付(明細表示)</summary>
        /// <remarks>売上日付</remarks>
        private DateTime _salesDate;

        /// <summary>得意先コード(明細表示)</summary>
        /// <remarks>得意先コード</remarks>
        private Int32 _customerCode;

        /// <summary>得意先名(明細表示)</summary>
        /// <remarks>得意先略称</remarks>
        private string _customerSnm = "";

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コード</remarks>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>仕入先総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationCode;

        /// <summary>仕入金額消費税額（内税）[伝票]</summary>
        /// <remarks>値引前の内税商品の消費税</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>仕入値引消費税額（内税）[伝票]</summary>
        /// <remarks>内税商品値引の消費税額</remarks>
        private Int64 _stckDisTtlTaxInclu;

        /// <summary>仕入単価（税抜，浮動）[明細]</summary>
        /// <remarks>税抜き</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>仕入金額（税抜き）[明細]</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>仕入金額（税込み）[明細]</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>仕入商品区分[伝票]</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>仕入金額消費税額[明細]</summary>
        /// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
        private Int64 _stockPriceConsTaxDtl;

        /// <summary>仕入伝票区分（明細）[明細]</summary>
        /// <remarks>0:仕入,1:返品,2:値引</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>手数料支払額[支払]</summary>
        private Int64 _feePayment;

        /// <summary>値引支払額[支払]</summary>
        private Int64 _discountPayment;

        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
        /// <summary>変更前仕入単価（浮動）[明細]</summary>
        private Double _bfStockUnitPriceFl;

        /// <summary>変更前定価[明細]</summary>
        private Double _bfListPrice;
        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>論理削除区分[仕入]</summary>
        private Int32 _slpLogicalDeleteCode;

        /// <summary>論理削除区分[仕入詳細]</summary>
        private Int32 _dtlLogicalDeleteCode;

        /// <summary>部門コード[仕入]</summary>
        private Int32 _slpSubSectionCode;

        /// <summary>仕入拠点コード[仕入]</summary>
        private string _stockSectionCd;

        /// <summary>仕入先消費税税率[仕入]</summary>
        private Double _supplierConsTaxRate;

        /// <summary>入力日[仕入]</summary>
        private DateTime _inputDay;

        /// <summary>部門コード[仕入明細]</summary>
        private Int32 _dtlSubSectionCode;

        /// <summary>受注番号[仕入明細]</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>共通通番[仕入明細]</summary>
        private Int64 _commonSeqNo;

        /// <summary>仕入明細通番[仕入明細]</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>仕入形式（元）[仕入明細]</summary>
        private Int32 _supplierFormalSrc;

        /// <summary>仕入明細通番（元）[仕入明細]</summary>
        private Int64 _stockSlipDtlNumSrc;

        /// <summary>受注ステータス（同時）[仕入明細]</summary>
        private Int32 _acptAnOdrStatusSync;

        /// <summary>売上明細通番（同時）[仕入明細]</summary>
        private Int64 _salesSlipDtlNumSync;

        /// <summary>仕入入力者コード[仕入明細]</summary>
        private string _stockInputCode;

        /// <summary>仕入担当者コード[仕入明細]</summary>
        private string _stockAgentCode;

        /// <summary>商品属性[仕入明細]</summary>
        private Int32 _goodsKindCode;

        /// <summary>メーカーカナ名称[仕入明細]</summary>
        private string _makerKanaName;

        /// <summary>メーカーカナ名称（一式）[仕入明細]</summary>
        private string _cmpltMakerKanaName;

        /// <summary>商品名称カナ[仕入明細]</summary>
        private string _goodsNameKana;

        /// <summary>商品大分類コード[仕入明細]</summary>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類名称[仕入明細]</summary>
        private string _goodsLGroupName;

        /// <summary>商品中分類コード[仕入明細]</summary>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名称[仕入明細]</summary>
        private string _goodsMGroupName;

        /// <summary>BLグループコード名称[仕入明細]</summary>
        private string _bLGroupName;

        /// <summary>BL商品コード名称（全角）[仕入明細]</summary>
        private string _bLGoodsFullName;

        /// <summary>自社分類コード[仕入明細]</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>掛率設定拠点（仕入単価）[仕入明細]</summary>
        private string _rateSectStckUnPrc;

        /// <summary>掛率設定区分（仕入単価）[仕入明細]</summary>
        private string _rateDivStckUnPrc;

        /// <summary>単価算出区分（仕入単価）[仕入明細]</summary>
        private Int32 _unPrcCalcCdStckUnPrc;

        /// <summary>価格区分（仕入単価）[仕入明細]</summary>
        private Int32 _priceCdStckUnPrc;

        /// <summary>基準単価（仕入単価）[仕入明細]</summary>
        private Double _stdUnPrcStckUnPrc;

        /// <summary>端数処理単位（仕入単価）[仕入明細]</summary>
        private Double _fracProcUnitStcUnPrc;

        /// <summary>端数処理（仕入単価）[仕入明細]</summary>
        private Int32 _fracProcStckUnPrc;

        /// <summary>仕入単価（税込，浮動）[仕入明細]</summary>
        private Double _stockUnitTaxPriceFl;

        /// <summary>仕入単価変更区分[仕入明細]</summary>
        private Int32 _stockUnitChngDiv;

        /// <summary>BL商品コード（掛率）[仕入明細]</summary>
        private Int32 _rateBLGoodsCode;

        /// <summary>BL商品コード名称（掛率）[仕入明細]</summary>
        private string _rateBLGoodsName;

        /// <summary>商品掛率グループコード（掛率）[仕入明細]</summary>
        private Int32 _rateGoodsRateGrpCd;

        /// <summary>商品掛率グループ名称（掛率）[仕入明細]</summary>
        private string _rateGoodsRateGrpNm;

        /// <summary>BLグループコード（掛率）[仕入明細]</summary>
        private Int32 _rateBLGroupCode;

        /// <summary>BLグループ名称（掛率）[仕入明細]</summary>
        private string _rateBLGroupName;

        /// <summary>発注数量[仕入明細]</summary>
        private Double _orderCnt;

        /// <summary>発注調整数[仕入明細]</summary>
        private Double _orderAdjustCnt;

        /// <summary>発注残数[仕入明細]</summary>
        private Double _orderRemainCnt;

        /// <summary>残数更新日[仕入明細]</summary>
        private DateTime _remainCntUpdDate;

        /// <summary>仕入伝票明細備考1[仕入明細]</summary>
        private string _stockDtiSlipNote1;

        /// <summary>販売先コード[仕入明細]</summary>
        private Int32 _salesCustomerCode;

        /// <summary>販売先略称[仕入明細]</summary>
        private string _salesCustomerSnm;

        /// <summary>伝票メモ１[仕入明細]</summary>
        private string _slipMemo1;

        /// <summary>伝票メモ２[仕入明細]</summary>
        private string _slipMemo2;

        /// <summary>伝票メモ３[仕入明細]</summary>
        private string _slipMemo3;

        /// <summary>社内メモ１[仕入明細]</summary>
        private string _insideMemo1;

        /// <summary>社内メモ２[仕入明細]</summary>
        private string _insideMemo2;

        /// <summary>社内メモ３[仕入明細]</summary>
        private string _insideMemo3;

        /// <summary>納品先コード[仕入明細]</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称[仕入明細]</summary>
        private string _addresseeName;

        /// <summary>直送区分[仕入明細]</summary>
        private Int32 _directSendingCd;

        /// <summary>発注番号[仕入明細]</summary>
        private string _orderNumber;

        /// <summary>注文方法[仕入明細]</summary>
        private Int32 _wayToOrder;

        /// <summary>納品完了予定日[仕入明細]</summary>
        private DateTime _deliGdsCmpltDueDate;

        /// <summary>希望納期[仕入明細]</summary>
        private DateTime _expectDeliveryDate;

        /// <summary>発注データ作成区分[仕入明細]</summary>
        private Int32 _orderDataCreateDiv;

        /// <summary>発注データ作成日[仕入明細]</summary>
        private DateTime _orderDataCreateDate;

        /// <summary>発注書発行済区分[仕入明細]</summary>
        private Int32 _orderFormIssuedDiv;

        /// <summary>自社分類名称[仕入明細]</summary>
        private string _enterpriseGanreName; 

        /// <summary>商品掛率ランク[仕入明細]</summary>
        private string _goodsRateRank;

        /// <summary>得意先掛率グループコード[仕入明細]</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先掛率グループコード[仕入明細]</summary>
        private Int32 _suppRateGrpCode;

        /// <summary>定価（税込，浮動）[仕入明細]</summary>
        private Double _listPriceTaxIncFl;

        /// <summary>仕入率[仕入明細]</summary>
        private Double _stockRate;

        /// <summary>仕入計上拠点コード[仕入]</summary>
        private string _stockAddUpSectionCd;

        /// <summary>業種コード[仕入]</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称[仕入]</summary>
        private string _businessTypeName;

        /// <summary>販売エリアコード[仕入]</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称[仕入]</summary>
        private string _salesAreaName;

        /// <summary>総額表示掛率適用区分[仕入]</summary>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>仕入端数処理区分[仕入]</summary>
        private Int32 _stockFractionProcCd;
       
        /// <summary>伝票住所区分[仕入]</summary>
        private Int32 _slipAddressDiv;

        /// <summary>納品先コード[仕入]</summary>
        private Int32 _slpAddresseeCode;

        /// <summary>納品先名称[仕入]</summary>
        private string _slpAddresseeName;

        /// <summary>納品先名称2[仕入]</summary>
        private string _addresseeName2;

        /// <summary>納品先郵便番号[仕入]</summary>
        private string _addresseePostNo;

        /// <summary>納品先住所1_都道府県市区郡・町村・字[仕入]</summary>
        private string _addresseeAddr1;

        /// <summary>納品先住所3_番地[仕入]</summary>
        private string _addresseeAddr3;

        /// <summary>納品先住所4_アパート名称[仕入]</summary>
        private string _addresseeAddr4;

        /// <summary>納品先電話番号[仕入]</summary>
        private string _addresseeTelNo;

        /// <summary>納品先FAX番号[仕入]</summary>
        private string _addresseeFaxNo;

        /// <summary>直送区分[仕入]</summary>
        private Int32 _slpDirectSendingCd;
        // ----------ADD 2013/01/21-----------<<<<<

        /// public propaty name  :  DataDiv
        /// <summary>データ区分プロパティ</summary>
        /// <value>0:仕入データ 1:支払データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>伝票日付プロパティ</summary>
        /// <value>仕入日(YYYYMMDD)/支払日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>伝票番号プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>行№(明細表示)プロパティ</summary>
        /// <value>仕入行番号/入金行番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行№(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
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

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
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

        /// public propaty name  :  StockAgentName
        /// <summary>担当者名プロパティ</summary>
        /// <value>仕入担当者名称/支払担当者名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>金額プロパティ</summary>
        /// <value>仕入金額計（税抜き）/支払金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名(明細表示)プロパティ</summary>
        /// <value>商品名称/金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番(明細表示)プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコード(明細表示)プロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカー名称</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BLコード(明細表示)プロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループ(明細表示)プロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループ(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>数量(明細表示)プロパティ</summary>
        /// <value>仕入数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>標準価格(明細表示)プロパティ</summary>
        /// <value>定価（税抜，浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分(明細表示)プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>仕入先消費税転嫁方式コードプロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税</value>
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

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>仕入金額計（税込み）プロパティ</summary>
        /// <value>※支払金額のこと</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
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

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>備考１プロパティ</summary>
        /// <value>仕入伝票備考1/伝票摘要</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>備考２プロパティ</summary>
        /// <value>仕入伝票備考2/有効期限</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点プロパティ</summary>
        /// <value>拠点ガイド名称/計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        // --- DEL 2009/09/08 ---------->>>>>
        /// public propaty name  :  StockInputName
        /// <summary>発行者プロパティ</summary>
        /// <value>仕入入力者名称/支払入力者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public string StockInputName
        //{
        //    get { return _stockInputName; }
        //    set { _stockInputName = value; }
        //}
        //--- DEL 2009/09/08 ----------<<<<<

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入先コード/仕入先コード</value>
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
        /// <summary>仕入先名プロパティ</summary>
        /// <value>仕入先略称/仕入先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>在取(明細表示)プロパティ</summary>
        /// <value>仕入在庫取寄せ区分(0:取寄せ，1:在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在取(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫(明細表示)プロパティ</summary>
        /// <value>倉庫名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>棚番(明細表示)プロパティ</summary>
        /// <value>倉庫棚番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>ＵＯＥリマーク１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// <value>ＵＯＥリマーク２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入SEQ/支払№プロパティ</summary>
        /// <value>仕入伝票番号/支払伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入SEQ/支払№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>計上日プロパティ</summary>
        /// <value>仕入計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>買掛区分プロパティ</summary>
        /// <value>買掛区分(0:買掛なし,1:買掛)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>同時売上伝票番号(明細表示)プロパティ</summary>
        /// <value>売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同時売上伝票番号(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>同時売上日付(明細表示)プロパティ</summary>
        /// <value>売上日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同時売上日付(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コード(明細表示)プロパティ</summary>
        /// <value>得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先名(明細表示)プロパティ</summary>
        /// <value>得意先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点コード</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
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
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
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

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>仕入金額消費税額（内税）[伝票]プロパティ</summary>
        /// <value>値引前の内税商品の消費税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額（内税）[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>仕入値引消費税額（内税）[伝票]プロパティ</summary>
        /// <value>内税商品値引の消費税額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入値引消費税額（内税）[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）[明細]プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>仕入金額（税込み）[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税込み）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>仕入商品区分[伝票]プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入商品区分[伝票]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  StockPriceConsTaxDtl
        /// <summary>仕入金額消費税額[明細]プロパティ</summary>
        /// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額消費税額[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceConsTaxDtl
        {
            get { return _stockPriceConsTaxDtl; }
            set { _stockPriceConsTaxDtl = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>仕入伝票区分（明細）[明細]プロパティ</summary>
        /// <value>0:仕入,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分（明細）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>手数料支払額[支払]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料支払額[支払]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>値引支払額[支払]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引支払額[支払]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfListPrice
        /// <summary>変更前定価[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前定価[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }
        // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

        // ----------ADD 2013/01/21----------->>>>>
        /// public propaty name  :  SlpLogicalDeleteCode
        /// <summary>論理削除区分(仕入)プロパティ</summary>
        /// <value>論理削除区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分(仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlpLogicalDeleteCode
        {
            get { return _slpLogicalDeleteCode; }
            set { _slpLogicalDeleteCode = value; }
        }

        /// public propaty name  :  DtlLogicalDeleteCode
        /// <summary>論理削除区分(仕入詳細)プロパティ</summary>
        /// <value>論理削除区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分(仕入詳細)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlLogicalDeleteCode
        {
            get { return _dtlLogicalDeleteCode; }
            set { _dtlLogicalDeleteCode = value; }
        }

        /// public propaty name  :  SlpSubSectionCode
        /// <summary>部門コード[仕入]プロパティ</summary>
        /// <value>部門コード[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コード[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlpSubSectionCode
        {
            get { return _slpSubSectionCode; }
            set { _slpSubSectionCode = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コード[仕入]プロパティ</summary>
        /// <value>仕入拠点コード[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コード[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>仕入先消費税税率[仕入]プロパティ</summary>
        /// <value>仕入先消費税税率[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先消費税税率[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日[仕入]プロパティ</summary>
        /// <value>入力日[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  DtlSubSectionCode
        /// <summary>部門コード[仕入明細]プロパティ</summary>
        /// <value>部門コード[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コード[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlSubSectionCode
        {
            get { return _dtlSubSectionCode; }
            set { _dtlSubSectionCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号[仕入明細]プロパティ</summary>
        /// <value>受注番号[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番[仕入明細]プロパティ</summary>
        /// <value>共通通番[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番[仕入明細]プロパティ</summary>
        /// <value>仕入明細通番[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  SupplierFormalSrc
        /// <summary>仕入形式（元）[仕入明細]プロパティ</summary>
        /// <value>仕入形式（元）[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式（元）[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormalSrc
        {
            get { return _supplierFormalSrc; }
            set { _supplierFormalSrc = value; }
        }

        /// public propaty name  :  StockSlipDtlNumSrc
        /// <summary>仕入明細通番（元）[仕入明細]プロパティ</summary>
        /// <value>仕入明細通番（元）[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（元）[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNumSrc
        {
            get { return _stockSlipDtlNumSrc; }
            set { _stockSlipDtlNumSrc = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSync
        /// <summary>受注ステータス（同時）[仕入明細]プロパティ</summary>
        /// <value>受注ステータス（同時）[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス（同時）[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSync
        {
            get { return _acptAnOdrStatusSync; }
            set { _acptAnOdrStatusSync = value; }
        }

        /// public propaty name  :  SalesSlipDtlNumSync
        /// <summary>売上明細通番（同時）[仕入明細]プロパティ</summary>
        /// <value>売上明細通番（同時）[仕入明細]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番（同時）[仕入明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNumSync
        {
            get { return _salesSlipDtlNumSync; }
            set { _salesSlipDtlNumSync = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>仕入入力者コードプロパティ</summary>
        /// <value>仕入入力者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set {  _stockInputCode = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>仕入担当者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set {  _stockAgentCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>商品属性</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set {  _goodsKindCode = value; }
        }

        /// public propaty name  :  MakerKanaName
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// <value>メーカーカナ名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set {  _makerKanaName = value; }
        }

        /// public propaty name  :  CmpltMakerKanaName
        /// <summary>メーカーカナ名称（一式）プロパティ</summary>
        /// <value>メーカーカナ名称（一式）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CmpltMakerKanaName
        {
            get { return _cmpltMakerKanaName; }
            set {  _cmpltMakerKanaName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// <value>商品名称カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set {  _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>商品大分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set {  _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// <value>商品大分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set {  _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>商品中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set {  _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// <value>商品中分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set {  _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// <value>BLグループコード名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set {  _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// <value>BL商品コード名称（全角）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set {  _bLGoodsFullName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set {  _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  RateSectStckUnPrc
        /// <summary>掛率設定拠点（仕入単価）プロパティ</summary>
        /// <value>掛率設定拠点（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定拠点（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateSectStckUnPrc
        {
            get { return _rateSectStckUnPrc; }
            set {  _rateSectStckUnPrc = value; }
        }

        /// public propaty name  :  RateDivStckUnPrc
        /// <summary>掛率設定区分（仕入単価）プロパティ</summary>
        /// <value>掛率設定区分（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateDivStckUnPrc
        {
            get { return _rateDivStckUnPrc; }
            set {  _rateDivStckUnPrc = value; }
        }

        /// public propaty name  :  UnPrcCalcCdStckUnPrc
        /// <summary>単価算出区分（仕入単価）プロパティ</summary>
        /// <value>単価算出区分（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnPrcCalcCdStckUnPrc
        {
            get { return _unPrcCalcCdStckUnPrc; }
            set {  _unPrcCalcCdStckUnPrc = value; }
        }

        /// public propaty name  :  PriceCdStckUnPrc
        /// <summary>価格区分（仕入単価）プロパティ</summary>
        /// <value>価格区分（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格区分（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCdStckUnPrc
        {
            get { return _priceCdStckUnPrc; }
            set {  _priceCdStckUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcStckUnPrc
        /// <summary>基準単価（仕入単価）プロパティ</summary>
        /// <value>基準単価（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcStckUnPrc
        {
            get { return _stdUnPrcStckUnPrc; }
            set {  _stdUnPrcStckUnPrc = value; }
        }

        /// public propaty name  :  FracProcUnitStcUnPrc
        /// <summary>端数処理単位（仕入単価）プロパティ</summary>
        /// <value>端数処理単位（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FracProcUnitStcUnPrc
        {
            get { return _fracProcUnitStcUnPrc; }
            set {  _fracProcUnitStcUnPrc = value; }
        }

        /// public propaty name  :  FracProcStckUnPrc
        /// <summary>端数処理（仕入単価）プロパティ</summary>
        /// <value>端数処理（仕入単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理（仕入単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FracProcStckUnPrc
        {
            get { return _fracProcStckUnPrc; }
            set {  _fracProcStckUnPrc = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>仕入単価（税込，浮動）プロパティ</summary>
        /// <value>仕入単価（税込，浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set {  _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockUnitChngDiv
        /// <summary>仕入単価変更区分プロパティ</summary>
        /// <value>仕入単価変更区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnitChngDiv
        {
            get { return _stockUnitChngDiv; }
            set {  _stockUnitChngDiv = value; }
        }

        /// public propaty name  :  RateBLGoodsCode
        /// <summary>BL商品コード（掛率）プロパティ</summary>
        /// <value>BL商品コード（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateBLGoodsCode
        {
            get { return _rateBLGoodsCode; }
            set {  _rateBLGoodsCode = value; }
        }

        /// public propaty name  :  RateBLGoodsName
        /// <summary>BL商品コード名称（掛率）プロパティ</summary>
        /// <value>BL商品コード名称（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateBLGoodsName
        {
            get { return _rateBLGoodsName; }
            set {  _rateBLGoodsName = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpCd
        /// <summary>商品掛率グループコード（掛率）プロパティ</summary>
        /// <value>商品掛率グループコード（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateGoodsRateGrpCd
        {
            get { return _rateGoodsRateGrpCd; }
            set {  _rateGoodsRateGrpCd = value; }
        }

        /// public propaty name  :  RateGoodsRateGrpNm
        /// <summary>商品掛率グループ名称（掛率）プロパティ</summary>
        /// <value>商品掛率グループ名称（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループ名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateGoodsRateGrpNm
        {
            get { return _rateGoodsRateGrpNm; }
            set {  _rateGoodsRateGrpNm = value; }
        }

        /// public propaty name  :  RateBLGroupCode
        /// <summary>BLグループコード（掛率）プロパティ</summary>
        /// <value>BLグループコード（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateBLGroupCode
        {
            get { return _rateBLGroupCode; }
            set {  _rateBLGroupCode = value; }
        }

        /// public propaty name  :  RateBLGroupName
        /// <summary>BLグループ名称（掛率）プロパティ</summary>
        /// <value>BLグループ名称（掛率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループ名称（掛率）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateBLGroupName
        {
            get { return _rateBLGroupName; }
            set {  _rateBLGroupName = value; }
        }

        /// public propaty name  :  OrderCnt
        /// <summary>発注数量プロパティ</summary>
        /// <value>発注数量</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderCnt
        {
            get { return _orderCnt; }
            set {  _orderCnt = value; }
        }

        /// public propaty name  :  OrderAdjustCnt
        /// <summary>発注調整数プロパティ</summary>
        /// <value>発注調整数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderAdjustCnt
        {
            get { return _orderAdjustCnt; }
            set {  _orderAdjustCnt = value; }
        }

        /// public propaty name  :  OrderRemainCnt
        /// <summary>発注残数プロパティ</summary>
        /// <value>発注残数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double OrderRemainCnt
        {
            get { return _orderRemainCnt; }
            set {  _orderRemainCnt = value; }
        }

        /// public propaty name  :  RemainCntUpdDate
        /// <summary>残数更新日プロパティ</summary>
        /// <value>残数更新日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime RemainCntUpdDate
        {
            get { return _remainCntUpdDate; }
            set {  _remainCntUpdDate = value; }
        }

        /// public propaty name  :  StockDtiSlipNote1
        /// <summary>仕入伝票明細備考1プロパティ</summary>
        /// <value>仕入伝票明細備考1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票明細備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDtiSlipNote1
        {
            get { return _stockDtiSlipNote1; }
            set {  _stockDtiSlipNote1 = value; }
        }

        /// public propaty name  :  SalesCustomerCode
        /// <summary>販売先コードプロパティ</summary>
        /// <value>販売先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCustomerCode
        {
            get { return _salesCustomerCode; }
            set {  _salesCustomerCode = value; }
        }

        /// public propaty name  :  SalesCustomerSnm
        /// <summary>販売先略称プロパティ</summary>
        /// <value>販売先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCustomerSnm
        {
            get { return _salesCustomerSnm; }
            set {  _salesCustomerSnm = value; }
        }

        /// public propaty name  :  SlipMemo1
        /// <summary>伝票メモ１プロパティ</summary>
        /// <value>伝票メモ１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo1
        {
            get { return _slipMemo1; }
            set {  _slipMemo1 = value; }
        }

        /// public propaty name  :  SlipMemo2
        /// <summary>伝票メモ２プロパティ</summary>
        /// <value>伝票メモ２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo2
        {
            get { return _slipMemo2; }
            set {  _slipMemo2 = value; }
        }

        /// public propaty name  :  SlipMemo3
        /// <summary>伝票メモ３プロパティ</summary>
        /// <value>伝票メモ３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipMemo3
        {
            get { return _slipMemo3; }
            set {  _slipMemo3 = value; }
        }

        /// public propaty name  :  InsideMemo1
        /// <summary>社内メモ１プロパティ</summary>
        /// <value>社内メモ１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo1
        {
            get { return _insideMemo1; }
            set {  _insideMemo1 = value; }
        }

        /// public propaty name  :  InsideMemo2
        /// <summary>社内メモ２プロパティ</summary>
        /// <value>社内メモ２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo2
        {
            get { return _insideMemo2; }
            set {  _insideMemo2 = value; }
        }

        /// public propaty name  :  InsideMemo3
        /// <summary>社内メモ３プロパティ</summary>
        /// <value>社内メモ３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InsideMemo3
        {
            get { return _insideMemo3; }
            set {  _insideMemo3 = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// <value>納品先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set {  _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// <value>納品先名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set {  _addresseeName = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>直送区分プロパティ</summary>
        /// <value>直送区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set {  _directSendingCd = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
        /// <value>発注番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set {  _orderNumber = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>注文方法</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set {  _wayToOrder = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>納品完了予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set {  _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  ExpectDeliveryDate
        /// <summary>希望納期プロパティ</summary>
        /// <value>希望納期</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ExpectDeliveryDate
        {
            get { return _expectDeliveryDate; }
            set {  _expectDeliveryDate = value; }
        }

        /// public propaty name  :  OrderDataCreateDiv
        /// <summary>発注データ作成区分プロパティ</summary>
        /// <value>発注データ作成区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderDataCreateDiv
        {
            get { return _orderDataCreateDiv; }
            set {  _orderDataCreateDiv = value; }
        }

        /// public propaty name  :  OrderDataCreateDate
        /// <summary>発注データ作成日プロパティ</summary>
        /// <value>発注データ作成日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注データ作成日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OrderDataCreateDate
        {
            get { return _orderDataCreateDate; }
            set {  _orderDataCreateDate = value; }
        }

        /// public propaty name  :  OrderFormIssuedDiv
        /// <summary>発注書発行済区分プロパティ</summary>
        /// <value>発注書発行済区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderFormIssuedDiv
        {
            get { return _orderFormIssuedDiv; }
            set {  _orderFormIssuedDiv = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>自社分類名称プロパティ</summary>
        /// <value>自社分類名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>商品掛率ランク</value>
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

                /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// <value>得意先掛率グループコード</value>
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

        /// public propaty name  :  SuppRateGrpCode
        /// <summary>仕入先掛率グループコードプロパティ</summary>
        /// <value>仕入先掛率グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SuppRateGrpCode
        {
            get { return _suppRateGrpCode; }
            set { _suppRateGrpCode = value; }
        }

        /// public propaty name  :  ListPriceTaxIncFl
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>定価（税込，浮動）</value>
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

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
        /// <value>仕入率</value>
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

        /// public propaty name  :  StockAddUpSectionCd
        /// <summary>仕入計上拠点コードプロパティ</summary>
        /// <value>仕入計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAddUpSectionCd
        {
            get { return _stockAddUpSectionCd; }
            set { _stockAddUpSectionCd = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コード[仕入]プロパティ</summary>
        /// <value>業種コード[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称[仕入]プロパティ</summary>
        /// <value>業種名称[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコード[仕入]プロパティ</summary>
        /// <value>>販売エリアコード[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   >販売エリアコード[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称[仕入]プロパティ</summary>
        /// <value>販売エリア名称[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>総額表示掛率適用区分[仕入]プロパティ</summary>
        /// <value>総額表示掛率適用区分[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
        }

        /// public propaty name  :  StockFractionProcCd
        /// <summary>仕入端数処理区分[仕入]プロパティ</summary>
        /// <value>仕入端数処理区分[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入端数処理区分[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockFractionProcCd
        {
            get { return _stockFractionProcCd; }
            set { _stockFractionProcCd = value; }
        }

        /// public propaty name  :  SlipAddressDiv
        /// <summary>伝票住所区分[仕入]プロパティ</summary>
        /// <value>伝票住所区分[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票住所区分[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  SlpAddresseeCode
        /// <summary>納品先コード[仕入]プロパティ</summary>
        /// <value>納品先コード[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コード[仕入]</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlpAddresseeCode
        {
            get { return _slpAddresseeCode; }
            set { _slpAddresseeCode = value; }
        }

        /// public propaty name  :  SlpAddresseeName
        /// <summary>納品先名称[仕入]プロパティ</summary>
        /// <value>納品先名称[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlpAddresseeName
        {
            get { return _slpAddresseeName; }
            set { _slpAddresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2[仕入]プロパティ</summary>
        /// <value>納品先名称2[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  AddresseePostNo
        /// <summary>納品先郵便番号[仕入]プロパティ</summary>
        /// <value>納品先郵便番号[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先郵便番号[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>納品先住所1_都道府県市区郡・町村・字[仕入]プロパティ</summary>
        /// <value>>納品先住所1_都道府県市区郡・町村・字[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  >納品先住所1_都道府県市区郡・町村・字[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>納品先住所3_番地[仕入]プロパティ</summary>
        /// <value>>納品先住所3_番地[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所3_番地[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>納品先住所4_アパート名称[仕入]プロパティ</summary>
        /// <value>納品先住所4_アパート名称[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先住所4_アパート名称[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>納品先電話番号[仕入]プロパティ</summary>
        /// <value>納品先電話番号[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先電話番号[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>納品先FAX番号[仕入]プロパティ</summary>
        /// <value>納品先FAX番号[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先FAX番号[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  SlpDirectSendingCd
        /// <summary>直送区分[仕入]プロパティ</summary>
        /// <value>直送区分[仕入]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   直送区分[仕入]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlpDirectSendingCd
        {
            get { return _slpDirectSendingCd; }
            set { _slpDirectSendingCd = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<

        /// <summary>
        /// 仕入先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
        /// </summary>
        /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPprStcTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  SuppPrtPprStcTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is SuppPrtPprStcTblRsltWork || graph is ArrayList || graph is SuppPrtPprStcTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( SuppPrtPprStcTblRsltWork ).FullName ) );

            if ( graph != null && graph is SuppPrtPprStcTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprStcTblRsltWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is SuppPrtPprStcTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprStcTblRsltWork[])graph).Length;
            }
            else if ( graph is SuppPrtPprStcTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //データ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //伝票日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockDate
            //伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //行№(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockRowNo
            //仕入形式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierFormal
            //仕入伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipCd
            //担当者名
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentName
            //金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxExc
            //品名(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //品番(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //メーカーコード(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //BLコード(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BLグループ(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //数量(明細表示)
            serInfo.MemberInfo.Add( typeof( Double ) ); //StockCount
            //標準価格(明細表示)
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            //オープン価格区分(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //仕入先消費税転嫁方式コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppCTaxLayCd
            //仕入金額計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockTtlPricTaxInc
            //仕入金額消費税額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTax
            //備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote1
            //備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSlipNote2
            //拠点
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //発行者
            // serInfo.MemberInfo.Add( typeof( string ) ); //StockInputName // DEL 2009/09/08
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //仕入先名
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //在取(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockOrderDivCd
            //倉庫(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //棚番(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //仕入SEQ/支払№
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //計上日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockAddUpADate
            //買掛区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccPayDivCd
            //赤伝区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //同時売上伝票番号(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //同時売上日付(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //得意先コード(明細表示)
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //得意先名(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //仕入先総額表示方法区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SuppTtlAmntDspWayCd
            //課税区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationCode
            //仕入金額消費税額（内税）[伝票]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckPrcConsTaxInclu
            //仕入値引消費税額（内税）[伝票]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckDisTtlTaxInclu
            //仕入単価（税抜，浮動）[明細]
            serInfo.MemberInfo.Add( typeof( Double ) ); //StockUnitPriceFl
            //仕入金額（税抜き）[明細]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceTaxExc
            //仕入金額（税込み）[明細]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceTaxInc
            //仕入商品区分[伝票]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockGoodsCd
            //仕入金額消費税額[明細]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockPriceConsTaxDtl
            //仕入伝票区分（明細）[明細]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockSlipCdDtl
            //手数料支払額[支払]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeePayment
            //値引支払額[支払]
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountPayment
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
            //変更前仕入単価（浮動）[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //変更前定価[明細]
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //論理削除区分[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpLogicalDeleteCode
            //論理削除区分[仕入詳細]
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlLogicalDeleteCode
            //部門コード[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpSubSectionCode
            //仕入拠点コード[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //仕入先消費税税率[仕入]
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierConsTaxRate
            //入力日[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //部門コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlSubSectionCode
            //受注番号[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //共通通番[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //仕入明細通番[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //仕入形式（元）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //仕入明細通番（元）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //受注ステータス（同時）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //売上明細通番（同時）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync

            //仕入入力者コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //仕入担当者コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //商品属性[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //メーカーカナ名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //メーカーカナ名称（一式）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //商品名称カナ[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //商品大分類コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品大分類名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //商品中分類コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLグループコード名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL商品コード名称（全角）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //自社分類コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //掛率設定拠点（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //掛率設定区分（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //単価算出区分（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //価格区分（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //基準単価（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //端数処理単位（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //端数処理（仕入単価）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //仕入単価（税込，浮動）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //仕入単価変更区分[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //BL商品コード（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL商品コード名称（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //商品掛率グループコード（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateGoodsRateGrpCd
            //商品掛率グループ名称（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //RateGoodsRateGrpNm
            //BLグループコード（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGroupCode
            //BLグループ名称（掛率）[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGroupName
            //発注数量[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //発注調整数[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //発注残数[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //残数更新日[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //仕入伝票明細備考1[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //販売先コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //販売先略称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //伝票メモ１[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //社内メモ１[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //納品先コード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //納品先名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //直送区分[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //発注番号[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //注文方法[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //納品完了予定日[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //希望納期[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //発注データ作成区分[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDiv
            //発注データ作成日[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //発注書発行済区分[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv

            //自社分類名称[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //商品掛率ランク[仕入明細]
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先掛率グループコード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //仕入先掛率グループコード[仕入明細]
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //定価（税込，浮動）[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //仕入率[仕入明細]
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //仕入計上拠点コード[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //StockAddUpSectionCd
            //業種コード[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //業種名称[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //販売エリアコード[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //販売エリア名称[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //総額表示掛率適用区分[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //仕入端数処理区分[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //StockFractionProcCd

            //伝票住所区分[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipAddressDiv
            //納品先コード[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpAddresseeCode
            //納品先名称[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //SlpAddresseeName
            //納品先名称2[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //納品先郵便番号[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseePostNo
            //納品先住所1_都道府県市区郡・町村・字[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr1
            //納品先住所3_番地[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr3
            //納品先住所4_アパート名称[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr4
            //納品先電話番号[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeTelNo
            //納品先FAX番号[仕入]
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeFaxNo
            //直送区分[仕入]
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpDirectSendingCd

            // ----------ADD 2013/01/21-----------<<<<<

            serInfo.Serialize( writer, serInfo );
            if ( graph is SuppPrtPprStcTblRsltWork )
            {
                SuppPrtPprStcTblRsltWork temp = (SuppPrtPprStcTblRsltWork)graph;

                SetSuppPrtPprStcTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is SuppPrtPprStcTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (SuppPrtPprStcTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( SuppPrtPprStcTblRsltWork temp in lst )
                {
                    SetSuppPrtPprStcTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// SuppPrtPprStcTblRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 53; // DEL 2009/09/08
        //private const int currentMemberCount = 52; // ADD 2009/09/08 // DEL 2012/10/15 田建委 Redmine#32862
        //private const int currentMemberCount = 54; // ADD 2012/10/15 田建委 Redmine#32862 //DEL 2013/01/21
        private const int currentMemberCount = 143; // ADD 2013/01/21

        /// <summary>
        ///  SuppPrtPprStcTblRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private void SetSuppPrtPprStcTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprStcTblRsltWork temp )
        {
            //データ区分
            writer.Write( temp.DataDiv );
            //伝票日付
            writer.Write( (Int64)temp.StockDate.Ticks );
            //伝票番号
            writer.Write( temp.PartySaleSlipNum );
            //行№(明細表示)
            writer.Write( temp.StockRowNo );
            //仕入形式
            writer.Write( temp.SupplierFormal );
            //仕入伝票区分
            writer.Write( temp.SupplierSlipCd );
            //担当者名
            writer.Write( temp.StockAgentName );
            //金額
            writer.Write( temp.StockTtlPricTaxExc );
            //品名(明細表示)
            writer.Write( temp.GoodsName );
            //品番(明細表示)
            writer.Write( temp.GoodsNo );
            //メーカーコード(明細表示)
            writer.Write( temp.GoodsMakerCd );
            //メーカー名称
            writer.Write( temp.MakerName );
            //BLコード(明細表示)
            writer.Write( temp.BLGoodsCode );
            //BLグループ(明細表示)
            writer.Write( temp.BLGroupCode );
            //数量(明細表示)
            writer.Write( temp.StockCount );
            //標準価格(明細表示)
            writer.Write( temp.ListPriceTaxExcFl );
            //オープン価格区分(明細表示)
            writer.Write( temp.OpenPriceDiv );
            //仕入先消費税転嫁方式コード
            writer.Write( temp.SuppCTaxLayCd );
            //仕入金額計（税込み）
            writer.Write( temp.StockTtlPricTaxInc );
            //仕入金額消費税額
            writer.Write( temp.StockPriceConsTax );
            //備考１
            writer.Write( temp.SupplierSlipNote1 );
            //備考２
            writer.Write( temp.SupplierSlipNote2 );
            //拠点
            writer.Write( temp.SectionGuideNm );
            //発行者
            // writer.Write( temp.StockInputName ); // DEL 2009/09/08
            //仕入先コード
            writer.Write( temp.SupplierCd );
            //仕入先名
            writer.Write( temp.SupplierSnm );
            //在取(明細表示)
            writer.Write( temp.StockOrderDivCd );
            //倉庫(明細表示)
            writer.Write( temp.WarehouseName );
            //棚番(明細表示)
            writer.Write( temp.WarehouseShelfNo );
            //ＵＯＥリマーク１
            writer.Write( temp.UoeRemark1 );
            //ＵＯＥリマーク２
            writer.Write( temp.UoeRemark2 );
            //仕入SEQ/支払№
            writer.Write( temp.SupplierSlipNo );
            //計上日
            writer.Write( (Int64)temp.StockAddUpADate.Ticks );
            //買掛区分
            writer.Write( temp.AccPayDivCd );
            //赤伝区分
            writer.Write( temp.DebitNoteDiv );
            //同時売上伝票番号(明細表示)
            writer.Write( temp.SalesSlipNum );
            //同時売上日付(明細表示)
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //得意先コード(明細表示)
            writer.Write( temp.CustomerCode );
            //得意先名(明細表示)
            writer.Write( temp.CustomerSnm );
            //拠点コード
            writer.Write( temp.SectionCode );
            //倉庫コード
            writer.Write( temp.WarehouseCode );
            //仕入先総額表示方法区分
            writer.Write( temp.SuppTtlAmntDspWayCd );
            //課税区分
            writer.Write( temp.TaxationCode );
            //仕入金額消費税額（内税）[伝票]
            writer.Write( temp.StckPrcConsTaxInclu );
            //仕入値引消費税額（内税）[伝票]
            writer.Write( temp.StckDisTtlTaxInclu );
            //仕入単価（税抜，浮動）[明細]
            writer.Write( temp.StockUnitPriceFl );
            //仕入金額（税抜き）[明細]
            writer.Write( temp.StockPriceTaxExc );
            //仕入金額（税込み）[明細]
            writer.Write( temp.StockPriceTaxInc );
            //仕入商品区分[伝票]
            writer.Write( temp.StockGoodsCd );
            //仕入金額消費税額[明細]
            writer.Write( temp.StockPriceConsTaxDtl );
            //仕入伝票区分（明細）[明細]
            writer.Write( temp.StockSlipCdDtl );
            //手数料支払額[支払]
            writer.Write( temp.FeePayment );
            //値引支払額[支払]
            writer.Write( temp.DiscountPayment );
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
            //変更前仕入単価（浮動）[明細]
            writer.Write(temp.BfStockUnitPriceFl);
            //変更前定価[明細]
            writer.Write(temp.BfListPrice);
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //論理削除区分[仕入]
            writer.Write(temp.SlpLogicalDeleteCode);
            //論理削除区分[仕入詳細
            writer.Write(temp.DtlLogicalDeleteCode);
            //部門コード[仕入]
            writer.Write(temp.SlpSubSectionCode);
            //仕入拠点コード[仕入]
            writer.Write(temp.StockSectionCd);
            //仕入先消費税税率[仕入]
            writer.Write(temp.SupplierConsTaxRate);
            //入力日[仕入]
            writer.Write((Int64)temp.InputDay.Ticks);
            //部門コード[仕入明細]
            writer.Write(temp.DtlSubSectionCode);
            //受注番号[仕入明細]
            writer.Write(temp.AcceptAnOrderNo);
            //共通通番[仕入明細]
            writer.Write(temp.CommonSeqNo);
            //仕入明細通番[仕入明細]
            writer.Write(temp.StockSlipDtlNum);
            //仕入形式（元）[仕入明細]
            writer.Write(temp.SupplierFormalSrc);
            //仕入明細通番（元）[仕入明細]
            writer.Write(temp.StockSlipDtlNumSrc);
            //受注ステータス（同時）[仕入明細]
            writer.Write(temp.AcptAnOdrStatusSync);
            //売上明細通番（同時）[仕入明細]
            writer.Write(temp.SalesSlipDtlNumSync);

            //仕入入力者コード[仕入明細]
            writer.Write(temp.StockInputCode);
            //仕入担当者コード[仕入明細]
            writer.Write(temp.StockAgentCode);
            //商品属性[仕入明細]
            writer.Write(temp.GoodsKindCode);
            //メーカーカナ名称[仕入明細]
            writer.Write(temp.MakerKanaName);
            //メーカーカナ名称（一式）[仕入明細]
            writer.Write(temp.CmpltMakerKanaName);
            //商品名称カナ[仕入明細]
            writer.Write(temp.GoodsNameKana);
            //商品大分類コード[仕入明細]
            writer.Write(temp.GoodsLGroup);
            //商品大分類名称[仕入明細]
            writer.Write(temp.GoodsLGroupName);
            //商品中分類コード[仕入明細]
            writer.Write(temp.GoodsMGroup);
            //商品中分類名称[仕入明細]
            writer.Write(temp.GoodsMGroupName);
            //BLグループコード名称[仕入明細]
            writer.Write(temp.BLGroupName);
            //BL商品コード名称（全角）[仕入明細]
            writer.Write(temp.BLGoodsFullName);
            //自社分類コード[仕入明細]
            writer.Write(temp.EnterpriseGanreCode);
            //掛率設定拠点（仕入単価）[仕入明細]
            writer.Write(temp.RateSectStckUnPrc);
            //掛率設定区分（仕入単価）[仕入明細]
            writer.Write(temp.RateDivStckUnPrc);
            //単価算出区分（仕入単価）[仕入明細]
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //価格区分（仕入単価）[仕入明細]
            writer.Write(temp.PriceCdStckUnPrc);
            //基準単価（仕入単価）[仕入明細]
            writer.Write(temp.StdUnPrcStckUnPrc);
            //端数処理単位（仕入単価）[仕入明細]
            writer.Write(temp.FracProcUnitStcUnPrc);
            //端数処理（仕入単価）[仕入明細]
            writer.Write(temp.FracProcStckUnPrc);
            //仕入単価（税込，浮動）[仕入明細]
            writer.Write(temp.StockUnitTaxPriceFl);
            //仕入単価変更区分[仕入明細]
            writer.Write(temp.StockUnitChngDiv);
            //BL商品コード（掛率）[仕入明細]
            writer.Write(temp.RateBLGoodsCode);
            //BL商品コード名称（掛率）[仕入明細]
            writer.Write(temp.RateBLGoodsName);
            //商品掛率グループコード（掛率）[仕入明細]
            writer.Write(temp.RateGoodsRateGrpCd);
            //商品掛率グループ名称（掛率）[仕入明細]
            writer.Write(temp.RateGoodsRateGrpNm);
            //BLグループコード（掛率）[仕入明細]
            writer.Write(temp.RateBLGroupCode);
            //BLグループ名称（掛率）[仕入明細]
            writer.Write(temp.RateBLGroupName);
            //発注数量[仕入明細]
            writer.Write(temp.OrderCnt);
            //発注調整数[仕入明細]
            writer.Write(temp.OrderAdjustCnt);
            //発注残数[仕入明細]
            writer.Write(temp.OrderRemainCnt);
            //残数更新日[仕入明細]
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //仕入伝票明細備考1[仕入明細]
            writer.Write(temp.StockDtiSlipNote1);
            //販売先コード[仕入明細]
            writer.Write(temp.SalesCustomerCode);
            //販売先略称[仕入明細]
            writer.Write(temp.SalesCustomerSnm);
            //伝票メモ１[仕入明細]
            writer.Write(temp.SlipMemo1);
            //伝票メモ２[仕入明細]
            writer.Write(temp.SlipMemo2);
            //伝票メモ３[仕入明細]
            writer.Write(temp.SlipMemo3);
            //社内メモ１[仕入明細]
            writer.Write(temp.InsideMemo1);
            //社内メモ２[仕入明細]
            writer.Write(temp.InsideMemo2);
            //社内メモ３[仕入明細]
            writer.Write(temp.InsideMemo3);
            //納品先コード[仕入明細]
            writer.Write(temp.AddresseeCode);
            //納品先名称[仕入明細]
            writer.Write(temp.AddresseeName);
            //直送区分[仕入明細]
            writer.Write(temp.DirectSendingCd);
            //発注番号[仕入明細]
            writer.Write(temp.OrderNumber);
            //注文方法[仕入明細]
            writer.Write(temp.WayToOrder);
            //納品完了予定日[仕入明細]
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //希望納期[仕入明細]
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //発注データ作成区分[仕入明細]
            writer.Write(temp.OrderDataCreateDiv);
            //発注データ作成日[仕入明細]
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //発注書発行済区分[仕入明細]
            writer.Write(temp.OrderFormIssuedDiv);

            //自社分類名称[仕入明細]
            writer.Write(temp.EnterpriseGanreName);
            //商品掛率ランク[仕入明細]
            writer.Write(temp.GoodsRateRank);
            //得意先掛率グループコード[仕入明細]
            writer.Write(temp.CustRateGrpCode);
            //仕入先掛率グループコード[仕入明細]
            writer.Write(temp.SuppRateGrpCode);
            //定価（税込，浮動）[仕入明細]
            writer.Write(temp.ListPriceTaxIncFl);
            //仕入率[仕入明細]
            writer.Write(temp.StockRate);
            //仕入計上拠点コード[仕入]
            writer.Write(temp.StockAddUpSectionCd);
            //業種コード[仕入]
            writer.Write(temp.BusinessTypeCode);
            //業種名称[仕入]
            writer.Write(temp.BusinessTypeName);
            //販売エリアコード[仕入]
            writer.Write(temp.SalesAreaCode);
            //販売エリア名称[仕入]
            writer.Write(temp.SalesAreaName);
            //総額表示掛率適用区分[仕入]
            writer.Write(temp.TtlAmntDispRateApy);
            //仕入端数処理区分[仕入]
            writer.Write(temp.StockFractionProcCd);

            //伝票住所区分[仕入]
            writer.Write(temp.SlipAddressDiv);
            //納品先コード[仕入]
            writer.Write(temp.SlpAddresseeCode);
            //納品先名称[仕入]
            writer.Write(temp.SlpAddresseeName);
            //納品先名称2[仕入]
            writer.Write(temp.AddresseeName2);
            //納品先郵便番号[仕入]
            writer.Write(temp.AddresseePostNo);
            //納品先住所1_都道府県市区郡・町村・字[仕入]
            writer.Write(temp.AddresseeAddr1);
            //納品先住所3_番地[仕入]
            writer.Write(temp.AddresseeAddr3);
            //納品先住所4_アパート名称[仕入]
            writer.Write(temp.AddresseeAddr4);
            //納品先電話番号[仕入]
            writer.Write(temp.AddresseeTelNo);
            //納品先FAX番号[仕入]
            writer.Write(temp.AddresseeFaxNo);
            //直送区分[仕入]
            writer.Write(temp.SlpDirectSendingCd);

            // ----------ADD 2013/01/21-----------<<<<<

        }

        /// <summary>
        ///  SuppPrtPprStcTblRsltWorkインスタンス取得
        /// </summary>
        /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private SuppPrtPprStcTblRsltWork GetSuppPrtPprStcTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SuppPrtPprStcTblRsltWork temp = new SuppPrtPprStcTblRsltWork();

            //データ区分
            temp.DataDiv = reader.ReadInt32();
            //伝票日付
            temp.StockDate = new DateTime( reader.ReadInt64() );
            //伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //行№(明細表示)
            temp.StockRowNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //担当者名
            temp.StockAgentName = reader.ReadString();
            //金額
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //品名(明細表示)
            temp.GoodsName = reader.ReadString();
            //品番(明細表示)
            temp.GoodsNo = reader.ReadString();
            //メーカーコード(明細表示)
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //BLコード(明細表示)
            temp.BLGoodsCode = reader.ReadInt32();
            //BLグループ(明細表示)
            temp.BLGroupCode = reader.ReadInt32();
            //数量(明細表示)
            temp.StockCount = reader.ReadDouble();
            //標準価格(明細表示)
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //オープン価格区分(明細表示)
            temp.OpenPriceDiv = reader.ReadInt32();
            //仕入先消費税転嫁方式コード
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //仕入金額計（税込み）
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //仕入金額消費税額
            temp.StockPriceConsTax = reader.ReadInt64();
            //備考１
            temp.SupplierSlipNote1 = reader.ReadString();
            //備考２
            temp.SupplierSlipNote2 = reader.ReadString();
            //拠点
            temp.SectionGuideNm = reader.ReadString();
            //発行者
            // temp.StockInputName = reader.ReadString(); // DEL 2009/09/08
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名
            temp.SupplierSnm = reader.ReadString();
            //在取(明細表示)
            temp.StockOrderDivCd = reader.ReadInt32();
            //倉庫(明細表示)
            temp.WarehouseName = reader.ReadString();
            //棚番(明細表示)
            temp.WarehouseShelfNo = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //仕入SEQ/支払№
            temp.SupplierSlipNo = reader.ReadInt32();
            //計上日
            temp.StockAddUpADate = new DateTime( reader.ReadInt64() );
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //同時売上伝票番号(明細表示)
            temp.SalesSlipNum = reader.ReadString();
            //同時売上日付(明細表示)
            temp.SalesDate = new DateTime( reader.ReadInt64() );
            //得意先コード(明細表示)
            temp.CustomerCode = reader.ReadInt32();
            //得意先名(明細表示)
            temp.CustomerSnm = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //仕入先総額表示方法区分
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //課税区分
            temp.TaxationCode = reader.ReadInt32();
            //仕入金額消費税額（内税）[伝票]
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //仕入値引消費税額（内税）[伝票]
            temp.StckDisTtlTaxInclu = reader.ReadInt64();
            //仕入単価（税抜，浮動）[明細]
            temp.StockUnitPriceFl = reader.ReadDouble();
            //仕入金額（税抜き）[明細]
            temp.StockPriceTaxExc = reader.ReadInt64();
            //仕入金額（税込み）[明細]
            temp.StockPriceTaxInc = reader.ReadInt64();
            //仕入商品区分[伝票]
            temp.StockGoodsCd = reader.ReadInt32();
            //仕入金額消費税額[明細]
            temp.StockPriceConsTaxDtl = reader.ReadInt64();
            //仕入伝票区分（明細）[明細]
            temp.StockSlipCdDtl = reader.ReadInt32();
            //手数料支払額[支払]
            temp.FeePayment = reader.ReadInt64();
            //値引支払額[支払]
            temp.DiscountPayment = reader.ReadInt64();
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
            //変更前仕入単価（浮動）[明細]
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //変更前定価[明細]
            temp.BfListPrice = reader.ReadDouble();
            // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            //論理削除区分[仕入]
            temp.SlpLogicalDeleteCode = reader.ReadInt32();
            //論理削除区分[仕入詳細]
            temp.DtlLogicalDeleteCode = reader.ReadInt32();
            //部門コード[仕入]
            temp.SlpSubSectionCode = reader.ReadInt32();
            //仕入拠点コード[仕入]
            temp.StockSectionCd = reader.ReadString();
            //仕入先消費税税率[仕入]
            temp.SupplierConsTaxRate = reader.ReadDouble();
            //入力日[仕入]
            temp.InputDay = new DateTime(reader.ReadInt64());
            //部門コード[仕入明細]
            temp.DtlSubSectionCode = reader.ReadInt32();
            //受注番号[仕入明細]
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //共通通番[仕入明細]
            temp.CommonSeqNo = reader.ReadInt64();
            //仕入明細通番[仕入明細]
            temp.StockSlipDtlNum = reader.ReadInt64();
            //仕入形式（元）[仕入明細]
            temp.SupplierFormalSrc = reader.ReadInt32();
            //仕入明細通番（元）[仕入明細]
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //受注ステータス（同時）[仕入明細]
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //売上明細通番（同時）[仕入明細]
            temp.SalesSlipDtlNumSync = reader.ReadInt64();

            //仕入入力者コード[仕入明細]
            temp.StockInputCode = reader.ReadString();
            //仕入担当者コード[仕入明細]
            temp.StockAgentCode = reader.ReadString();
            //商品属性[仕入明細]
            temp.GoodsKindCode = reader.ReadInt32();
            //メーカーカナ名称[仕入明細]
            temp.MakerKanaName = reader.ReadString();
            //メーカーカナ名称（一式）[仕入明細]
            temp.CmpltMakerKanaName = reader.ReadString();
            //商品名称カナ[仕入明細]
            temp.GoodsNameKana = reader.ReadString();
            //商品大分類コード[仕入明細]
            temp.GoodsLGroup = reader.ReadInt32();
            //商品大分類名称[仕入明細]
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類コード[仕入明細]
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類名称[仕入明細]
            temp.GoodsMGroupName = reader.ReadString();
            //BLグループコード名称[仕入明細]
            temp.BLGroupName = reader.ReadString();
            //BL商品コード名称（全角）[仕入明細]
            temp.BLGoodsFullName = reader.ReadString();
            //自社分類コード[仕入明細]
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //掛率設定拠点（仕入単価）[仕入明細]
            temp.RateSectStckUnPrc = reader.ReadString();
            //掛率設定区分（仕入単価）[仕入明細]
            temp.RateDivStckUnPrc = reader.ReadString();
            //単価算出区分（仕入単価）[仕入明細]
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //価格区分（仕入単価）[仕入明細]
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //基準単価（仕入単価）[仕入明細]
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //端数処理単位（仕入単価）[仕入明細]
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //端数処理（仕入単価）[仕入明細]
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //仕入単価（税込，浮動）[仕入明細]
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //仕入単価変更区分[仕入明細]
            temp.StockUnitChngDiv = reader.ReadInt32();
            //BL商品コード（掛率）[仕入明細]
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（掛率）[仕入明細]
            temp.RateBLGoodsName = reader.ReadString();
            //商品掛率グループコード（掛率）[仕入明細]
            temp.RateGoodsRateGrpCd = reader.ReadInt32();
            //商品掛率グループ名称（掛率）[仕入明細]
            temp.RateGoodsRateGrpNm = reader.ReadString();
            //BLグループコード（掛率）[仕入明細]
            temp.RateBLGroupCode = reader.ReadInt32();
            //BLグループ名称（掛率）[仕入明細]
            temp.RateBLGroupName = reader.ReadString();
            //発注数量[仕入明細]
            temp.OrderCnt = reader.ReadDouble();
            //発注調整数[仕入明細]
            temp.OrderAdjustCnt = reader.ReadDouble();
            //発注残数[仕入明細]
            temp.OrderRemainCnt = reader.ReadDouble();
            //残数更新日[仕入明細]
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //仕入伝票明細備考1[仕入明細]
            temp.StockDtiSlipNote1 = reader.ReadString();
            //販売先コード[仕入明細]
            temp.SalesCustomerCode = reader.ReadInt32();
            //販売先略称[仕入明細]
            temp.SalesCustomerSnm = reader.ReadString();
            //伝票メモ１[仕入明細]
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２[仕入明細]
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３[仕入明細]
            temp.SlipMemo3 = reader.ReadString();
            //社内メモ１[仕入明細]
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２[仕入明細]
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３[仕入明細]
            temp.InsideMemo3 = reader.ReadString();
            //納品先コード[仕入明細]
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称[仕入明細]
            temp.AddresseeName = reader.ReadString();
            //直送区分[仕入明細]
            temp.DirectSendingCd = reader.ReadInt32();
            //発注番号[仕入明細]
            temp.OrderNumber = reader.ReadString();
            //注文方法[仕入明細]
            temp.WayToOrder = reader.ReadInt32();
            //納品完了予定日[仕入明細]
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //希望納期[仕入明細]
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //発注データ作成区分[仕入明細]
            temp.OrderDataCreateDiv = reader.ReadInt32();
            //発注データ作成日[仕入明細]
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //発注書発行済区分[仕入明細]
            temp.OrderFormIssuedDiv = reader.ReadInt32();

            //自社分類名称[仕入明細]
            temp.EnterpriseGanreName = reader.ReadString();
            //商品掛率ランク[仕入明細]
            temp.GoodsRateRank = reader.ReadString();
            //得意先掛率グループコード[仕入明細]
            temp.CustRateGrpCode = reader.ReadInt32();
            //仕入先掛率グループコード[仕入明細]
            temp.SuppRateGrpCode = reader.ReadInt32();
            //定価（税込，浮動）[仕入明細]
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //仕入率[仕入明細]
            temp.StockRate = reader.ReadDouble();
            //仕入計上拠点コード[仕入]
            temp.StockAddUpSectionCd = reader.ReadString();
            //業種コード[仕入]
            temp.BusinessTypeCode = reader.ReadInt32();
            //業種名称[仕入]
            temp.BusinessTypeName = reader.ReadString();
            //販売エリアコード[仕入]
            temp.SalesAreaCode = reader.ReadInt32();
            //販売エリア名称[仕入]
            temp.SalesAreaName = reader.ReadString();
            //総額表示掛率適用区分[仕入]
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //仕入端数処理区分[仕入]
            temp.StockFractionProcCd = reader.ReadInt32();

            //伝票住所区分[仕入]
            temp.SlipAddressDiv = reader.ReadInt32();
            //納品先コード[仕入]
            temp.SlpAddresseeCode = reader.ReadInt32();
            //納品先名称[仕入]
            temp.SlpAddresseeName = reader.ReadString();
            //納品先名称2[仕入]
            temp.AddresseeName2 = reader.ReadString();
            //納品先郵便番号[仕入]
            temp.AddresseePostNo = reader.ReadString();
            //納品先住所1_都道府県市区郡・町村・字[仕入]
            temp.AddresseeAddr1 = reader.ReadString();
            //納品先住所3_番地[仕入]
            temp.AddresseeAddr3 = reader.ReadString();
            //納品先住所4_アパート名称[仕入]
            temp.AddresseeAddr4 = reader.ReadString();
            //納品先電話番号[仕入]
            temp.AddresseeTelNo = reader.ReadString();
            //納品先FAX番号[仕入]
            temp.AddresseeFaxNo = reader.ReadString();
            //直送区分[仕入]
            temp.SlpDirectSendingCd = reader.ReadInt32();

            // ----------ADD 2013/01/21-----------<<<<<

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>SuppPrtPprStcTblRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprStcTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                SuppPrtPprStcTblRsltWork temp = GetSuppPrtPprStcTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SuppPrtPprStcTblRsltWork[])lst.ToArray( typeof( SuppPrtPprStcTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

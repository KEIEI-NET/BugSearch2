using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUGoodsPriceUWork
    /// <summary>
    ///                      商品・価格ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品・価格ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2012/06/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/5  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   　提供区分</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsUGoodsPriceUWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private string _goodsMakerCd = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>BL商品コード</summary>
        private string _bLGoodsCode = "";

        /// <summary>商品区分コード</summary>
        private string _enterpriseGanreCode = "";

        /// <summary>層別</summary>
        /// <remarks>nchar 6 から修正</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品属性</summary>
        /// <remarks>0:純正　1:その他</remarks>
        private string _goodsKindCode = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private string _taxationDivCd = "";

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>価格開始年月日１</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate1 = "";

        /// <summary>価格１</summary>
        private string _listPrice1 = "";

        /// <summary>オープン価格区分１</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _openPriceDiv1 = "";

        /// <summary>仕入率１</summary>
        private string _stockRate1 = "";

        /// <summary>原単価１</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private string _salesUnitCost1 = "";

        /// <summary>価格開始年月日２</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate2 = "";

        /// <summary>価格２</summary>
        private string _listPrice2 = "";

        /// <summary>オープン価格区分２</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _openPriceDiv2 = "";

        /// <summary>仕入率２</summary>
        private string _stockRate2 = "";

        /// <summary>原単価２</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private string _salesUnitCost2 = "";

        /// <summary>価格開始年月日３</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate3 = "";

        /// <summary>価格３</summary>
        private string _listPrice3 = "";

        /// <summary>オープン価格区分３</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _openPriceDiv3 = "";

        /// <summary>仕入率３</summary>
        private string _stockRate3 = "";

        /// <summary>原単価３</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private string _salesUnitCost3 = "";

        /// <summary>価格開始年月日４</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate4 = "";

        /// <summary>価格４</summary>
        private string _listPrice4 = "";

        /// <summary>オープン価格区分４</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _openPriceDiv4 = "";

        /// <summary>仕入率４</summary>
        private string _stockRate4 = "";

        /// <summary>原単価４</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private string _salesUnitCost4 = "";

        /// <summary>価格開始年月日４</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _priceStartDate5 = "";

        /// <summary>価格４</summary>
        private string _listPrice5 = "";

        /// <summary>オープン価格区分４</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _openPriceDiv5 = "";

        /// <summary>仕入率４</summary>
        private string _stockRate5 = "";

        /// <summary>原単価４</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private string _salesUnitCost5 = "";

        /// <summary>エラーログ</summary>
        private string _errorMsg = "";

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
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

        /// public propaty name  :  Jan
        /// <summary>JANコードプロパティ</summary>
        /// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>商品区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>層別プロパティ</summary>
        /// <value>nchar 6 から修正</value>
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

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正　1:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
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

        /// public propaty name  :  PriceStartDate1
        /// <summary>価格開始年月日１プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDate1
        {
            get { return _priceStartDate1; }
            set { _priceStartDate1 = value; }
        }

        /// public propaty name  :  ListPrice1
        /// <summary>価格１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrice1
        {
            get { return _listPrice1; }
            set { _listPrice1 = value; }
        }

        /// public propaty name  :  OpenPriceDiv1
        /// <summary>オープン価格区分１プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OpenPriceDiv1
        {
            get { return _openPriceDiv1; }
            set { _openPriceDiv1 = value; }
        }

        /// public propaty name  :  StockRate1
        /// <summary>仕入率１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRate1
        {
            get { return _stockRate1; }
            set { _stockRate1 = value; }
        }

        /// public propaty name  :  SalesUnitCost1
        /// <summary>原単価１プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesUnitCost1
        {
            get { return _salesUnitCost1; }
            set { _salesUnitCost1 = value; }
        }

        /// public propaty name  :  PriceStartDate2
        /// <summary>価格開始年月日２プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDate2
        {
            get { return _priceStartDate2; }
            set { _priceStartDate2 = value; }
        }

        /// public propaty name  :  ListPrice2
        /// <summary>価格２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrice2
        {
            get { return _listPrice2; }
            set { _listPrice2 = value; }
        }

        /// public propaty name  :  OpenPriceDiv2
        /// <summary>オープン価格区分２プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OpenPriceDiv2
        {
            get { return _openPriceDiv2; }
            set { _openPriceDiv2 = value; }
        }

        /// public propaty name  :  StockRate2
        /// <summary>仕入率２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRate2
        {
            get { return _stockRate2; }
            set { _stockRate2 = value; }
        }

        /// public propaty name  :  SalesUnitCost2
        /// <summary>原単価２プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesUnitCost2
        {
            get { return _salesUnitCost2; }
            set { _salesUnitCost2 = value; }
        }

        /// public propaty name  :  PriceStartDate3
        /// <summary>価格開始年月日３プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDate3
        {
            get { return _priceStartDate3; }
            set { _priceStartDate3 = value; }
        }

        /// public propaty name  :  ListPrice3
        /// <summary>価格３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrice3
        {
            get { return _listPrice3; }
            set { _listPrice3 = value; }
        }

        /// public propaty name  :  OpenPriceDiv3
        /// <summary>オープン価格区分３プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OpenPriceDiv3
        {
            get { return _openPriceDiv3; }
            set { _openPriceDiv3 = value; }
        }

        /// public propaty name  :  StockRate3
        /// <summary>仕入率３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRate3
        {
            get { return _stockRate3; }
            set { _stockRate3 = value; }
        }

        /// public propaty name  :  SalesUnitCost3
        /// <summary>原単価３プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesUnitCost3
        {
            get { return _salesUnitCost3; }
            set { _salesUnitCost3 = value; }
        }

        /// public propaty name  :  PriceStartDate4
        /// <summary>価格開始年月日４プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDate4
        {
            get { return _priceStartDate4; }
            set { _priceStartDate4 = value; }
        }

        /// public propaty name  :  ListPrice4
        /// <summary>価格４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrice4
        {
            get { return _listPrice4; }
            set { _listPrice4 = value; }
        }

        /// public propaty name  :  OpenPriceDiv4
        /// <summary>オープン価格区分４プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OpenPriceDiv4
        {
            get { return _openPriceDiv4; }
            set { _openPriceDiv4 = value; }
        }

        /// public propaty name  :  StockRate4
        /// <summary>仕入率４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRate4
        {
            get { return _stockRate4; }
            set { _stockRate4 = value; }
        }

        /// public propaty name  :  SalesUnitCost4
        /// <summary>原単価４プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesUnitCost4
        {
            get { return _salesUnitCost4; }
            set { _salesUnitCost4 = value; }
        }

        /// public propaty name  :  PriceStartDate5
        /// <summary>価格開始年月日４プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceStartDate5
        {
            get { return _priceStartDate5; }
            set { _priceStartDate5 = value; }
        }

        /// public propaty name  :  ListPrice5
        /// <summary>価格４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrice5
        {
            get { return _listPrice5; }
            set { _listPrice5 = value; }
        }

        /// public propaty name  :  OpenPriceDiv5
        /// <summary>オープン価格区分４プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OpenPriceDiv5
        {
            get { return _openPriceDiv5; }
            set { _openPriceDiv5 = value; }
        }

        /// public propaty name  :  StockRate5
        /// <summary>仕入率４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRate5
        {
            get { return _stockRate5; }
            set { _stockRate5 = value; }
        }

        /// public propaty name  :  SalesUnitCost5
        /// <summary>原単価４プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesUnitCost5
        {
            get { return _salesUnitCost5; }
            set { _salesUnitCost5 = value; }
        }

        /// public propaty name  :  ErrorMsg
        /// <summary>エラーログプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーログプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }

        /// <summary>
        /// 商品・価格ワークコンストラクタ
        /// </summary>
        /// <returns>GoodsUGoodsPriceUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsUGoodsPriceUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsUGoodsPriceUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsUGoodsPriceUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsUGoodsPriceUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUGoodsPriceUWork || graph is ArrayList || graph is GoodsUGoodsPriceUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsUGoodsPriceUWork).FullName));

            if (graph != null && graph is GoodsUGoodsPriceUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUGoodsPriceUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsUGoodsPriceUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUGoodsPriceUWork[])graph).Length;
            }
            else if (graph is GoodsUGoodsPriceUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerCd
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //JANコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsCode
            //商品区分コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreCode
            //層別
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //商品属性
            serInfo.MemberInfo.Add(typeof(string)); //GoodsKindCode
            //課税区分
            serInfo.MemberInfo.Add(typeof(string)); //TaxationDivCd
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //価格開始年月日１
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate1
            //価格１
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice1
            //オープン価格区分１
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv1
            //仕入率１
            serInfo.MemberInfo.Add(typeof(string)); //StockRate1
            //原単価１
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost1
            //価格開始年月日２
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate2
            //価格２
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice2
            //オープン価格区分２
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv2
            //仕入率２
            serInfo.MemberInfo.Add(typeof(string)); //StockRate2
            //原単価２
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost2
            //価格開始年月日３
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate3
            //価格３
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice3
            //オープン価格区分３
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv3
            //仕入率３
            serInfo.MemberInfo.Add(typeof(string)); //StockRate3
            //原単価３
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost3
            //価格開始年月日４
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate4
            //価格４
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice4
            //オープン価格区分４
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv4
            //仕入率４
            serInfo.MemberInfo.Add(typeof(string)); //StockRate4
            //原単価４
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost4
            //価格開始年月日４
            serInfo.MemberInfo.Add(typeof(string)); //PriceStartDate5
            //価格４
            serInfo.MemberInfo.Add(typeof(string)); //ListPrice5
            //オープン価格区分４
            serInfo.MemberInfo.Add(typeof(string)); //OpenPriceDiv5
            //仕入率４
            serInfo.MemberInfo.Add(typeof(string)); //StockRate5
            //原単価４
            serInfo.MemberInfo.Add(typeof(string)); //SalesUnitCost5
            //エラーログ
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMsg


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUGoodsPriceUWork)
            {
                GoodsUGoodsPriceUWork temp = (GoodsUGoodsPriceUWork)graph;

                SetGoodsUGoodsPriceUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUGoodsPriceUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUGoodsPriceUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUGoodsPriceUWork temp in lst)
                {
                    SetGoodsUGoodsPriceUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUGoodsPriceUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 40;

        /// <summary>
        ///  GoodsUGoodsPriceUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsUGoodsPriceUWork(System.IO.BinaryWriter writer, GoodsUGoodsPriceUWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //JANコード
            writer.Write(temp.Jan);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品区分コード
            writer.Write(temp.EnterpriseGanreCode);
            //層別
            writer.Write(temp.GoodsRateRank);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //商品備考１
            writer.Write(temp.GoodsNote1);
            //商品備考２
            writer.Write(temp.GoodsNote2);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            //価格開始年月日１
            writer.Write(temp.PriceStartDate1);
            //価格１
            writer.Write(temp.ListPrice1);
            //オープン価格区分１
            writer.Write(temp.OpenPriceDiv1);
            //仕入率１
            writer.Write(temp.StockRate1);
            //原単価１
            writer.Write(temp.SalesUnitCost1);
            //価格開始年月日２
            writer.Write(temp.PriceStartDate2);
            //価格２
            writer.Write(temp.ListPrice2);
            //オープン価格区分２
            writer.Write(temp.OpenPriceDiv2);
            //仕入率２
            writer.Write(temp.StockRate2);
            //原単価２
            writer.Write(temp.SalesUnitCost2);
            //価格開始年月日３
            writer.Write(temp.PriceStartDate3);
            //価格３
            writer.Write(temp.ListPrice3);
            //オープン価格区分３
            writer.Write(temp.OpenPriceDiv3);
            //仕入率３
            writer.Write(temp.StockRate3);
            //原単価３
            writer.Write(temp.SalesUnitCost3);
            //価格開始年月日４
            writer.Write(temp.PriceStartDate4);
            //価格４
            writer.Write(temp.ListPrice4);
            //オープン価格区分４
            writer.Write(temp.OpenPriceDiv4);
            //仕入率４
            writer.Write(temp.StockRate4);
            //原単価４
            writer.Write(temp.SalesUnitCost4);
            //価格開始年月日４
            writer.Write(temp.PriceStartDate5);
            //価格４
            writer.Write(temp.ListPrice5);
            //オープン価格区分４
            writer.Write(temp.OpenPriceDiv5);
            //仕入率４
            writer.Write(temp.StockRate5);
            //原単価４
            writer.Write(temp.SalesUnitCost5);
            //エラーログ
            writer.Write(temp.ErrorMsg);

        }

        /// <summary>
        ///  GoodsUGoodsPriceUWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsUGoodsPriceUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsUGoodsPriceUWork GetGoodsUGoodsPriceUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsUGoodsPriceUWork temp = new GoodsUGoodsPriceUWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //JANコード
            temp.Jan = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadString();
            //商品区分コード
            temp.EnterpriseGanreCode = reader.ReadString();
            //層別
            temp.GoodsRateRank = reader.ReadString();
            //商品属性
            temp.GoodsKindCode = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadString();
            //商品備考１
            temp.GoodsNote1 = reader.ReadString();
            //商品備考２
            temp.GoodsNote2 = reader.ReadString();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            //価格開始年月日１
            temp.PriceStartDate1 = reader.ReadString();
            //価格１
            temp.ListPrice1 = reader.ReadString();
            //オープン価格区分１
            temp.OpenPriceDiv1 = reader.ReadString();
            //仕入率１
            temp.StockRate1 = reader.ReadString();
            //原単価１
            temp.SalesUnitCost1 = reader.ReadString();
            //価格開始年月日２
            temp.PriceStartDate2 = reader.ReadString();
            //価格２
            temp.ListPrice2 = reader.ReadString();
            //オープン価格区分２
            temp.OpenPriceDiv2 = reader.ReadString();
            //仕入率２
            temp.StockRate2 = reader.ReadString();
            //原単価２
            temp.SalesUnitCost2 = reader.ReadString();
            //価格開始年月日３
            temp.PriceStartDate3 = reader.ReadString();
            //価格３
            temp.ListPrice3 = reader.ReadString();
            //オープン価格区分３
            temp.OpenPriceDiv3 = reader.ReadString();
            //仕入率３
            temp.StockRate3 = reader.ReadString();
            //原単価３
            temp.SalesUnitCost3 = reader.ReadString();
            //価格開始年月日４
            temp.PriceStartDate4 = reader.ReadString();
            //価格４
            temp.ListPrice4 = reader.ReadString();
            //オープン価格区分４
            temp.OpenPriceDiv4 = reader.ReadString();
            //仕入率４
            temp.StockRate4 = reader.ReadString();
            //原単価４
            temp.SalesUnitCost4 = reader.ReadString();
            //価格開始年月日４
            temp.PriceStartDate5 = reader.ReadString();
            //価格４
            temp.ListPrice5 = reader.ReadString();
            //オープン価格区分４
            temp.OpenPriceDiv5 = reader.ReadString();
            //仕入率４
            temp.StockRate5 = reader.ReadString();
            //原単価４
            temp.SalesUnitCost5 = reader.ReadString();
            //エラーログ
            temp.ErrorMsg = reader.ReadString();


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
        /// <returns>GoodsUGoodsPriceUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUGoodsPriceUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUGoodsPriceUWork temp = GetGoodsUGoodsPriceUWork(reader, serInfo);
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
                    retValue = (GoodsUGoodsPriceUWork[])lst.ToArray(typeof(GoodsUGoodsPriceUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

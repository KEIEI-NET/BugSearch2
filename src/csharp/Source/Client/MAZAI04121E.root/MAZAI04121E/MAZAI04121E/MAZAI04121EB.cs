// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
/*
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveExp
    /// <summary>
    ///                      在庫移動詳細データ
    /// </summary>
    /// <remarks>
    /// note             :   在庫移動詳細データヘッダファイル<br />
    /// Programmer       :   自動生成<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/02/05  (CSharp File Generated Date)<br />
    /// Update Note      :   <br />
    /// </remarks>
    public class StockMoveExp
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>在庫移動形式</summary>
        /// <remarks>1:拠点間移動、2：倉庫移動</remarks>
        private Int32 _stockMoveFormal;

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>在庫移動行番号</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>在庫移動行詳細番号</summary>
        private Int32 _stockMoveExpNum;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>移動元拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>移動元拠点ガイド名称</summary>
        private string _bfSectionGuideNm = "";

        /// <summary>移動元倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>移動元倉庫名称</summary>
        private string _bfEnterWarehName = "";

        /// <summary>移動先拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>移動先拠点ガイド名称</summary>
        private string _afSectionGuideNm = "";

        /// <summary>移動先倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>移動先倉庫名称</summary>
        private string _afEnterWarehName = "";

        /// <summary>事業者コード</summary>
        private Int32 _carrierEpCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品コード</summary>
        private string _goodsCode = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>製造番号</summary>
        /// <remarks>※「製番なし」の場合、null</remarks>
        private string _productNumber = "";

        /// <summary>製番在庫マスタGUID</summary>
        private Guid _productStockGuid;

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社、1:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>仕入単価</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Int64 _stockUnitPrice;

        /// <summary>仕入金額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _stockPrice;

        /// <summary>仕入金額消費税額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>仕入外税対象額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _itdedStckOutTax;

        /// <summary>仕入内税対象額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _itdedStckInTax;

        /// <summary>仕入非課税対象額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _itdedStckTaxFree;

        /// <summary>仕入外税額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _stckOuterTax;

        /// <summary>仕入内税額</summary>
        /// <remarks>　〃</remarks>
        private Int64 _stckInnerTax;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationCode;

        /// <summary>商品電話番号1</summary>
        private string _stockTelNo1 = "";

        /// <summary>商品電話番号2</summary>
        private string _stockTelNo2 = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>事業者名称</summary>
        private string _carrierEpName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 和暦(略)プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   作成日時 西暦(略)プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新日時プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新日時 和暦プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新日時 和暦(略)プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新日時 西暦プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新日時 西暦(略)プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   企業コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   GUIDプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新従業員コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新アセンブリID1プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新アセンブリID2プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   論理削除区分プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>在庫移動形式プロパティ</summary>
        /// <value>1:拠点間移動、2：倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動形式プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動伝票番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>在庫移動行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動行番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  StockMoveExpNum
        /// <summary>在庫移動行詳細番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動行詳細番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockMoveExpNum
        {
            get { return _stockMoveExpNum; }
            set { _stockMoveExpNum = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideNm
        /// <summary>移動元拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元拠点ガイド名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfSectionGuideNm
        {
            get { return _bfSectionGuideNm; }
            set { _bfSectionGuideNm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元倉庫コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元倉庫名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideNm
        /// <summary>移動先拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先拠点ガイド名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfSectionGuideNm
        {
            get { return _afSectionGuideNm; }
            set { _afSectionGuideNm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先倉庫コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先倉庫名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  CarrierEpCode
        /// <summary>事業者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   事業者コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 CarrierEpCode
        {
            get { return _carrierEpCode; }
            set { _carrierEpCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   得意先コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   メーカーコードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   メーカー名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   商品コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   商品名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  ProductNumber
        /// <summary>製造番号プロパティ</summary>
        /// <value>※「製番なし」の場合、null</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   製造番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; }
        }

        /// public propaty name  :  ProductStockGuid
        /// <summary>製番在庫マスタGUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   製番在庫マスタGUIDプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Guid ProductStockGuid
        {
            get { return _productStockGuid; }
            set { _productStockGuid = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:自社、1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫区分プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  StockUnitPrice
        /// <summary>仕入単価プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入単価プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 StockUnitPrice
        {
            get { return _stockUnitPrice; }
            set { _stockUnitPrice = value; }
        }

        /// public propaty name  :  StockPrice
        /// <summary>仕入金額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入金額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 StockPrice
        {
            get { return _stockPrice; }
            set { _stockPrice = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>仕入金額消費税額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入金額消費税額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  ItdedStckOutTax
        /// <summary>仕入外税対象額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入外税対象額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 ItdedStckOutTax
        {
            get { return _itdedStckOutTax; }
            set { _itdedStckOutTax = value; }
        }

        /// public propaty name  :  ItdedStckInTax
        /// <summary>仕入内税対象額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入内税対象額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 ItdedStckInTax
        {
            get { return _itdedStckInTax; }
            set { _itdedStckInTax = value; }
        }

        /// public propaty name  :  ItdedStckTaxFree
        /// <summary>仕入非課税対象額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入非課税対象額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 ItdedStckTaxFree
        {
            get { return _itdedStckTaxFree; }
            set { _itdedStckTaxFree = value; }
        }

        /// public propaty name  :  StckOuterTax
        /// <summary>仕入外税額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入外税額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 StckOuterTax
        {
            get { return _stckOuterTax; }
            set { _stckOuterTax = value; }
        }

        /// public propaty name  :  StckInnerTax
        /// <summary>仕入内税額プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   仕入内税額プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int64 StckInnerTax
        {
            get { return _stckInnerTax; }
            set { _stckInnerTax = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   課税区分プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StockTelNo1
        /// <summary>商品電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   商品電話番号1プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string StockTelNo1
        {
            get { return _stockTelNo1; }
            set { _stockTelNo1 = value; }
        }

        /// public propaty name  :  StockTelNo2
        /// <summary>商品電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   商品電話番号2プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string StockTelNo2
        {
            get { return _stockTelNo2; }
            set { _stockTelNo2 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   企業名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   更新従業員名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  CarrierEpName
        /// <summary>事業者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   事業者名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CarrierEpName
        {
            get { return _carrierEpName; }
            set { _carrierEpName = value; }
        }


        /// <summary>
        /// 在庫移動詳細データコンストラクタ
        /// </summary>
        /// <returns>StockMoveExpクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの新しいインスタンスを生成します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public StockMoveExp()
        {
        }

        /// <summary>
        /// 在庫移動詳細データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="stockMoveFormal">在庫移動形式(1:拠点間移動、2：倉庫移動)</param>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="stockMoveRowNo">在庫移動行番号</param>
        /// <param name="stockMoveExpNum">在庫移動行詳細番号</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bfSectionCode">移動元拠点コード</param>
        /// <param name="bfSectionGuideNm">移動元拠点ガイド名称</param>
        /// <param name="bfEnterWarehCode">移動元倉庫コード</param>
        /// <param name="bfEnterWarehName">移動元倉庫名称</param>
        /// <param name="afSectionCode">移動先拠点コード</param>
        /// <param name="afSectionGuideNm">移動先拠点ガイド名称</param>
        /// <param name="afEnterWarehCode">移動先倉庫コード</param>
        /// <param name="afEnterWarehName">移動先倉庫名称</param>
        /// <param name="carrierEpCode">事業者コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="productNumber">製造番号(※「製番なし」の場合、null)</param>
        /// <param name="productStockGuid">製番在庫マスタGUID</param>
        /// <param name="stockDiv">在庫区分(0:自社、1:受託)</param>
        /// <param name="stockUnitPrice">仕入単価(在庫移動する在庫の仕入価格情報をセット)</param>
        /// <param name="stockPrice">仕入金額(　〃)</param>
        /// <param name="stockPriceConsTax">仕入金額消費税額(　〃)</param>
        /// <param name="itdedStckOutTax">仕入外税対象額(　〃)</param>
        /// <param name="itdedStckInTax">仕入内税対象額(　〃)</param>
        /// <param name="itdedStckTaxFree">仕入非課税対象額(　〃)</param>
        /// <param name="stckOuterTax">仕入外税額(　〃)</param>
        /// <param name="stckInnerTax">仕入内税額(　〃)</param>
        /// <param name="taxationCode">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="stockTelNo1">商品電話番号1</param>
        /// <param name="stockTelNo2">商品電話番号2</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="carrierEpName">事業者名称</param>
        /// <returns>StockMoveExpクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの新しいインスタンスを生成します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public StockMoveExp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockMoveFormal, Int32 stockMoveSlipNo, Int32 stockMoveRowNo, Int32 stockMoveExpNum, string sectionCode, string bfSectionCode, string bfSectionGuideNm, string bfEnterWarehCode, string bfEnterWarehName, string afSectionCode, string afSectionGuideNm, string afEnterWarehCode, string afEnterWarehName, Int32 carrierEpCode, Int32 customerCode, Int32 makerCode, string makerName, string goodsCode, string goodsName, string productNumber, Guid productStockGuid, Int32 stockDiv, Int64 stockUnitPrice, Int64 stockPrice, Int64 stockPriceConsTax, Int64 itdedStckOutTax, Int64 itdedStckInTax, Int64 itdedStckTaxFree, Int64 stckOuterTax, Int64 stckInnerTax, Int32 taxationCode, string stockTelNo1, string stockTelNo2, string enterpriseName, string updEmployeeName, string carrierEpName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._stockMoveFormal = stockMoveFormal;
            this._stockMoveSlipNo = stockMoveSlipNo;
            this._stockMoveRowNo = stockMoveRowNo;
            this._stockMoveExpNum = stockMoveExpNum;
            this._sectionCode = sectionCode;
            this._bfSectionCode = bfSectionCode;
            this._bfSectionGuideNm = bfSectionGuideNm;
            this._bfEnterWarehCode = bfEnterWarehCode;
            this._bfEnterWarehName = bfEnterWarehName;
            this._afSectionCode = afSectionCode;
            this._afSectionGuideNm = afSectionGuideNm;
            this._afEnterWarehCode = afEnterWarehCode;
            this._afEnterWarehName = afEnterWarehName;
            this._carrierEpCode = carrierEpCode;
            this._customerCode = customerCode;
            this._makerCode = makerCode;
            this._makerName = makerName;
            this._goodsCode = goodsCode;
            this._goodsName = goodsName;
            this._productNumber = productNumber;
            this._productStockGuid = productStockGuid;
            this._stockDiv = stockDiv;
            this._stockUnitPrice = stockUnitPrice;
            this._stockPrice = stockPrice;
            this._stockPriceConsTax = stockPriceConsTax;
            this._itdedStckOutTax = itdedStckOutTax;
            this._itdedStckInTax = itdedStckInTax;
            this._itdedStckTaxFree = itdedStckTaxFree;
            this._stckOuterTax = stckOuterTax;
            this._stckInnerTax = stckInnerTax;
            this._taxationCode = taxationCode;
            this._stockTelNo1 = stockTelNo1;
            this._stockTelNo2 = stockTelNo2;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._carrierEpName = carrierEpName;

        }

        /// <summary>
        /// 在庫移動詳細データ複製処理
        /// </summary>
        /// <returns>StockMoveExpクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   自身の内容と等しいStockMoveExpクラスのインスタンスを返します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public StockMoveExp Clone()
        {
            return new StockMoveExp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockMoveFormal, this._stockMoveSlipNo, this._stockMoveRowNo, this._stockMoveExpNum, this._sectionCode, this._bfSectionCode, this._bfSectionGuideNm, this._bfEnterWarehCode, this._bfEnterWarehName, this._afSectionCode, this._afSectionGuideNm, this._afEnterWarehCode, this._afEnterWarehName, this._carrierEpCode, this._customerCode, this._makerCode, this._makerName, this._goodsCode, this._goodsName, this._productNumber, this._productStockGuid, this._stockDiv, this._stockUnitPrice, this._stockPrice, this._stockPriceConsTax, this._itdedStckOutTax, this._itdedStckInTax, this._itdedStckTaxFree, this._stckOuterTax, this._stckInnerTax, this._taxationCode, this._stockTelNo1, this._stockTelNo2, this._enterpriseName, this._updEmployeeName, this._carrierEpName);
        }

        /// <summary>
        /// 在庫移動詳細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveExpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの内容が一致するか比較します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public bool Equals(StockMoveExp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.StockMoveFormal == target.StockMoveFormal)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.StockMoveRowNo == target.StockMoveRowNo)
                 && (this.StockMoveExpNum == target.StockMoveExpNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionGuideNm == target.BfSectionGuideNm)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.BfEnterWarehName == target.BfEnterWarehName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionGuideNm == target.AfSectionGuideNm)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.AfEnterWarehName == target.AfEnterWarehName)
                 && (this.CarrierEpCode == target.CarrierEpCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.ProductNumber == target.ProductNumber)
                 && (this.ProductStockGuid == target.ProductStockGuid)
                 && (this.StockDiv == target.StockDiv)
                 && (this.StockUnitPrice == target.StockUnitPrice)
                 && (this.StockPrice == target.StockPrice)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.ItdedStckOutTax == target.ItdedStckOutTax)
                 && (this.ItdedStckInTax == target.ItdedStckInTax)
                 && (this.ItdedStckTaxFree == target.ItdedStckTaxFree)
                 && (this.StckOuterTax == target.StckOuterTax)
                 && (this.StckInnerTax == target.StckInnerTax)
                 && (this.TaxationCode == target.TaxationCode)
                 && (this.StockTelNo1 == target.StockTelNo1)
                 && (this.StockTelNo2 == target.StockTelNo2)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.CarrierEpName == target.CarrierEpName));
        }

        /// <summary>
        /// 在庫移動詳細データ比較処理
        /// </summary>
        /// <param name="stockMoveExp1">
        ///                    比較するStockMoveExpクラスのインスタンス
        /// </param>
        /// <param name="stockMoveExp2">比較するStockMoveExpクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの内容が一致するか比較します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public static bool Equals(StockMoveExp stockMoveExp1, StockMoveExp stockMoveExp2)
        {
            return ((stockMoveExp1.CreateDateTime == stockMoveExp2.CreateDateTime)
                 && (stockMoveExp1.UpdateDateTime == stockMoveExp2.UpdateDateTime)
                 && (stockMoveExp1.EnterpriseCode == stockMoveExp2.EnterpriseCode)
                 && (stockMoveExp1.FileHeaderGuid == stockMoveExp2.FileHeaderGuid)
                 && (stockMoveExp1.UpdEmployeeCode == stockMoveExp2.UpdEmployeeCode)
                 && (stockMoveExp1.UpdAssemblyId1 == stockMoveExp2.UpdAssemblyId1)
                 && (stockMoveExp1.UpdAssemblyId2 == stockMoveExp2.UpdAssemblyId2)
                 && (stockMoveExp1.LogicalDeleteCode == stockMoveExp2.LogicalDeleteCode)
                 && (stockMoveExp1.StockMoveFormal == stockMoveExp2.StockMoveFormal)
                 && (stockMoveExp1.StockMoveSlipNo == stockMoveExp2.StockMoveSlipNo)
                 && (stockMoveExp1.StockMoveRowNo == stockMoveExp2.StockMoveRowNo)
                 && (stockMoveExp1.StockMoveExpNum == stockMoveExp2.StockMoveExpNum)
                 && (stockMoveExp1.SectionCode == stockMoveExp2.SectionCode)
                 && (stockMoveExp1.BfSectionCode == stockMoveExp2.BfSectionCode)
                 && (stockMoveExp1.BfSectionGuideNm == stockMoveExp2.BfSectionGuideNm)
                 && (stockMoveExp1.BfEnterWarehCode == stockMoveExp2.BfEnterWarehCode)
                 && (stockMoveExp1.BfEnterWarehName == stockMoveExp2.BfEnterWarehName)
                 && (stockMoveExp1.AfSectionCode == stockMoveExp2.AfSectionCode)
                 && (stockMoveExp1.AfSectionGuideNm == stockMoveExp2.AfSectionGuideNm)
                 && (stockMoveExp1.AfEnterWarehCode == stockMoveExp2.AfEnterWarehCode)
                 && (stockMoveExp1.AfEnterWarehName == stockMoveExp2.AfEnterWarehName)
                 && (stockMoveExp1.CarrierEpCode == stockMoveExp2.CarrierEpCode)
                 && (stockMoveExp1.CustomerCode == stockMoveExp2.CustomerCode)
                 && (stockMoveExp1.MakerCode == stockMoveExp2.MakerCode)
                 && (stockMoveExp1.MakerName == stockMoveExp2.MakerName)
                 && (stockMoveExp1.GoodsCode == stockMoveExp2.GoodsCode)
                 && (stockMoveExp1.GoodsName == stockMoveExp2.GoodsName)
                 && (stockMoveExp1.ProductNumber == stockMoveExp2.ProductNumber)
                 && (stockMoveExp1.ProductStockGuid == stockMoveExp2.ProductStockGuid)
                 && (stockMoveExp1.StockDiv == stockMoveExp2.StockDiv)
                 && (stockMoveExp1.StockUnitPrice == stockMoveExp2.StockUnitPrice)
                 && (stockMoveExp1.StockPrice == stockMoveExp2.StockPrice)
                 && (stockMoveExp1.StockPriceConsTax == stockMoveExp2.StockPriceConsTax)
                 && (stockMoveExp1.ItdedStckOutTax == stockMoveExp2.ItdedStckOutTax)
                 && (stockMoveExp1.ItdedStckInTax == stockMoveExp2.ItdedStckInTax)
                 && (stockMoveExp1.ItdedStckTaxFree == stockMoveExp2.ItdedStckTaxFree)
                 && (stockMoveExp1.StckOuterTax == stockMoveExp2.StckOuterTax)
                 && (stockMoveExp1.StckInnerTax == stockMoveExp2.StckInnerTax)
                 && (stockMoveExp1.TaxationCode == stockMoveExp2.TaxationCode)
                 && (stockMoveExp1.StockTelNo1 == stockMoveExp2.StockTelNo1)
                 && (stockMoveExp1.StockTelNo2 == stockMoveExp2.StockTelNo2)
                 && (stockMoveExp1.EnterpriseName == stockMoveExp2.EnterpriseName)
                 && (stockMoveExp1.UpdEmployeeName == stockMoveExp2.UpdEmployeeName)
                 && (stockMoveExp1.CarrierEpName == stockMoveExp2.CarrierEpName));
        }
        /// <summary>
        /// 在庫移動詳細データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveExpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの内容が一致するか比較しし、一致しない項目の名称を返します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public ArrayList Compare(StockMoveExp target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.StockMoveFormal != target.StockMoveFormal) resList.Add("StockMoveFormal");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.StockMoveRowNo != target.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (this.StockMoveExpNum != target.StockMoveExpNum) resList.Add("StockMoveExpNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionGuideNm != target.BfSectionGuideNm) resList.Add("BfSectionGuideNm");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.BfEnterWarehName != target.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionGuideNm != target.AfSectionGuideNm) resList.Add("AfSectionGuideNm");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.AfEnterWarehName != target.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (this.CarrierEpCode != target.CarrierEpCode) resList.Add("CarrierEpCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.ProductNumber != target.ProductNumber) resList.Add("ProductNumber");
            if (this.ProductStockGuid != target.ProductStockGuid) resList.Add("ProductStockGuid");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.StockUnitPrice != target.StockUnitPrice) resList.Add("StockUnitPrice");
            if (this.StockPrice != target.StockPrice) resList.Add("StockPrice");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.ItdedStckOutTax != target.ItdedStckOutTax) resList.Add("ItdedStckOutTax");
            if (this.ItdedStckInTax != target.ItdedStckInTax) resList.Add("ItdedStckInTax");
            if (this.ItdedStckTaxFree != target.ItdedStckTaxFree) resList.Add("ItdedStckTaxFree");
            if (this.StckOuterTax != target.StckOuterTax) resList.Add("StckOuterTax");
            if (this.StckInnerTax != target.StckInnerTax) resList.Add("StckInnerTax");
            if (this.TaxationCode != target.TaxationCode) resList.Add("TaxationCode");
            if (this.StockTelNo1 != target.StockTelNo1) resList.Add("StockTelNo1");
            if (this.StockTelNo2 != target.StockTelNo2) resList.Add("StockTelNo2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.CarrierEpName != target.CarrierEpName) resList.Add("CarrierEpName");

            return resList;
        }

        /// <summary>
        /// 在庫移動詳細データ比較処理
        /// </summary>
        /// <param name="stockMoveExp1">比較するStockMoveExpクラスのインスタンス</param>
        /// <param name="stockMoveExp2">比較するStockMoveExpクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveExpクラスの内容が一致するか比較し、一致しない項目の名称を返します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveExp stockMoveExp1, StockMoveExp stockMoveExp2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveExp1.CreateDateTime != stockMoveExp2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMoveExp1.UpdateDateTime != stockMoveExp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMoveExp1.EnterpriseCode != stockMoveExp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveExp1.FileHeaderGuid != stockMoveExp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMoveExp1.UpdEmployeeCode != stockMoveExp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMoveExp1.UpdAssemblyId1 != stockMoveExp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMoveExp1.UpdAssemblyId2 != stockMoveExp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMoveExp1.LogicalDeleteCode != stockMoveExp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMoveExp1.StockMoveFormal != stockMoveExp2.StockMoveFormal) resList.Add("StockMoveFormal");
            if (stockMoveExp1.StockMoveSlipNo != stockMoveExp2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveExp1.StockMoveRowNo != stockMoveExp2.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (stockMoveExp1.StockMoveExpNum != stockMoveExp2.StockMoveExpNum) resList.Add("StockMoveExpNum");
            if (stockMoveExp1.SectionCode != stockMoveExp2.SectionCode) resList.Add("SectionCode");
            if (stockMoveExp1.BfSectionCode != stockMoveExp2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveExp1.BfSectionGuideNm != stockMoveExp2.BfSectionGuideNm) resList.Add("BfSectionGuideNm");
            if (stockMoveExp1.BfEnterWarehCode != stockMoveExp2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveExp1.BfEnterWarehName != stockMoveExp2.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (stockMoveExp1.AfSectionCode != stockMoveExp2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveExp1.AfSectionGuideNm != stockMoveExp2.AfSectionGuideNm) resList.Add("AfSectionGuideNm");
            if (stockMoveExp1.AfEnterWarehCode != stockMoveExp2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveExp1.AfEnterWarehName != stockMoveExp2.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (stockMoveExp1.CarrierEpCode != stockMoveExp2.CarrierEpCode) resList.Add("CarrierEpCode");
            if (stockMoveExp1.CustomerCode != stockMoveExp2.CustomerCode) resList.Add("CustomerCode");
            if (stockMoveExp1.MakerCode != stockMoveExp2.MakerCode) resList.Add("MakerCode");
            if (stockMoveExp1.MakerName != stockMoveExp2.MakerName) resList.Add("MakerName");
            if (stockMoveExp1.GoodsCode != stockMoveExp2.GoodsCode) resList.Add("GoodsCode");
            if (stockMoveExp1.GoodsName != stockMoveExp2.GoodsName) resList.Add("GoodsName");
            if (stockMoveExp1.ProductNumber != stockMoveExp2.ProductNumber) resList.Add("ProductNumber");
            if (stockMoveExp1.ProductStockGuid != stockMoveExp2.ProductStockGuid) resList.Add("ProductStockGuid");
            if (stockMoveExp1.StockDiv != stockMoveExp2.StockDiv) resList.Add("StockDiv");
            if (stockMoveExp1.StockUnitPrice != stockMoveExp2.StockUnitPrice) resList.Add("StockUnitPrice");
            if (stockMoveExp1.StockPrice != stockMoveExp2.StockPrice) resList.Add("StockPrice");
            if (stockMoveExp1.StockPriceConsTax != stockMoveExp2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (stockMoveExp1.ItdedStckOutTax != stockMoveExp2.ItdedStckOutTax) resList.Add("ItdedStckOutTax");
            if (stockMoveExp1.ItdedStckInTax != stockMoveExp2.ItdedStckInTax) resList.Add("ItdedStckInTax");
            if (stockMoveExp1.ItdedStckTaxFree != stockMoveExp2.ItdedStckTaxFree) resList.Add("ItdedStckTaxFree");
            if (stockMoveExp1.StckOuterTax != stockMoveExp2.StckOuterTax) resList.Add("StckOuterTax");
            if (stockMoveExp1.StckInnerTax != stockMoveExp2.StckInnerTax) resList.Add("StckInnerTax");
            if (stockMoveExp1.TaxationCode != stockMoveExp2.TaxationCode) resList.Add("TaxationCode");
            if (stockMoveExp1.StockTelNo1 != stockMoveExp2.StockTelNo1) resList.Add("StockTelNo1");
            if (stockMoveExp1.StockTelNo2 != stockMoveExp2.StockTelNo2) resList.Add("StockTelNo2");
            if (stockMoveExp1.EnterpriseName != stockMoveExp2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMoveExp1.UpdEmployeeName != stockMoveExp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockMoveExp1.CarrierEpName != stockMoveExp2.CarrierEpName) resList.Add("CarrierEpName");

            return resList;
        }
    }
}
*/
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

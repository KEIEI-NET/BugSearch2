using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;// ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GetUsrGoodsUnitDataWork
    /// <summary>
    ///                      提供データユーザー商品取得クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供データユーザー商品取得クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GetUsrGoodsUnitDataWork : IFileHeader
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

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正　1:その他</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>更新年月日</summary>
        private DateTime _updateDate;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ,1:提供データ</remarks>
        private Int32 _offerDataDiv;

        /// <summary>作成日時(価格)</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _priceCreateDateTime;

        /// <summary>更新日時(価格)</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _priceUpdateDateTime;

        /// <summary>企業コード(価格)</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _priceEnterpriseCode = "";

        /// <summary>GUID(価格)</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _priceFileHeaderGuid;

        /// <summary>更新従業員コード(価格)</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _priceUpdEmployeeCode = "";

        /// <summary>更新アセンブリID1(価格)</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _priceUpdAssemblyId1 = "";

        /// <summary>更新アセンブリID2(価格)</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _priceUpdAssemblyId2 = "";

        /// <summary>論理削除区分(価格)</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _priceLogicalDeleteCode;

        /// <summary>商品メーカーコード(価格)</summary>
        private Int32 _priceGoodsMakerCd;

        /// <summary>商品番号(価格)</summary>
        private string _priceGoodsNo = "";

        /// <summary>価格開始日(価格)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _pricePriceStartDate;

        /// <summary>定価（浮動）</summary>
        private Double _priceListPrice;

        /// <summary>原価単価</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private Double _priceSalesUnitCost;

        /// <summary>仕入率</summary>
        private Double _priceStockRate;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _priceOpenPriceDiv;

        /// <summary>提供日付(価格)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceOfferDate;

        /// <summary>更新年月日(価格)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceUpdateDate;

        /// <summary>対象件数</summary>
        private Int32 _priceCount;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正　1:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// <value>0:ユーザデータ,1:提供データ</value>
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

        /// public propaty name  :  PriceCreateDateTime
        /// <summary>作成日時(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceCreateDateTime
        {
            get { return _priceCreateDateTime; }
            set { _priceCreateDateTime = value; }
        }

        /// public propaty name  :  PriceUpdateDateTime
        /// <summary>更新日時(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceUpdateDateTime
        {
            get { return _priceUpdateDateTime; }
            set { _priceUpdateDateTime = value; }
        }

        /// public propaty name  :  PriceEnterpriseCode
        /// <summary>企業コード(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コード(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceEnterpriseCode
        {
            get { return _priceEnterpriseCode; }
            set { _priceEnterpriseCode = value; }
        }

        /// public propaty name  :  PriceFileHeaderGuid
        /// <summary>GUID(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid PriceFileHeaderGuid
        {
            get { return _priceFileHeaderGuid; }
            set { _priceFileHeaderGuid = value; }
        }

        /// public propaty name  :  PriceUpdEmployeeCode
        /// <summary>更新従業員コード(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コード(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceUpdEmployeeCode
        {
            get { return _priceUpdEmployeeCode; }
            set { _priceUpdEmployeeCode = value; }
        }

        /// public propaty name  :  PriceUpdAssemblyId1
        /// <summary>更新アセンブリID1(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceUpdAssemblyId1
        {
            get { return _priceUpdAssemblyId1; }
            set { _priceUpdAssemblyId1 = value; }
        }

        /// public propaty name  :  PriceUpdAssemblyId2
        /// <summary>更新アセンブリID2(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceUpdAssemblyId2
        {
            get { return _priceUpdAssemblyId2; }
            set { _priceUpdAssemblyId2 = value; }
        }

        /// public propaty name  :  PriceLogicalDeleteCode
        /// <summary>論理削除区分(価格)プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceLogicalDeleteCode
        {
            get { return _priceLogicalDeleteCode; }
            set { _priceLogicalDeleteCode = value; }
        }

        /// public propaty name  :  PriceGoodsMakerCd
        /// <summary>商品メーカーコード(価格)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceGoodsMakerCd
        {
            get { return _priceGoodsMakerCd; }
            set { _priceGoodsMakerCd = value; }
        }

        /// public propaty name  :  PriceGoodsNo
        /// <summary>商品番号(価格)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceGoodsNo
        {
            get { return _priceGoodsNo; }
            set { _priceGoodsNo = value; }
        }

        /// public propaty name  :  PricePriceStartDate
        /// <summary>価格開始日(価格)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PricePriceStartDate
        {
            get { return _pricePriceStartDate; }
            set { _pricePriceStartDate = value; }
        }

        /// public propaty name  :  PriceListPrice
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceListPrice
        {
            get { return _priceListPrice; }
            set { _priceListPrice = value; }
        }

        /// public propaty name  :  PriceSalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceSalesUnitCost
        {
            get { return _priceSalesUnitCost; }
            set { _priceSalesUnitCost = value; }
        }

        /// public propaty name  :  PriceStockRate
        /// <summary>仕入率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceStockRate
        {
            get { return _priceStockRate; }
            set { _priceStockRate = value; }
        }

        /// public propaty name  :  PriceOpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceOpenPriceDiv
        {
            get { return _priceOpenPriceDiv; }
            set { _priceOpenPriceDiv = value; }
        }

        /// public propaty name  :  PriceOfferDate
        /// <summary>提供日付(価格)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  PriceUpdateDate
        /// <summary>更新年月日(価格)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日(価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceUpdateDate
        {
            get { return _priceUpdateDate; }
            set { _priceUpdateDate = value; }
        }

        /// public propaty name  :  PriceCount
        /// <summary>対象件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceCount
        {
            get { return _priceCount; }
            set { _priceCount = value; }
        }


        /// <summary>
        /// 提供データユーザー商品取得クラスワークコンストラクタ
        /// </summary>
        /// <returns>GetUsrGoodsUnitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GetUsrGoodsUnitDataWork()
        {
        }

    }

    // --- ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応----->>>>>
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GetUsrGoodsUnitDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GetUsrGoodsUnitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GetUsrGoodsUnitDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GetUsrGoodsUnitDataWork || graph is ArrayList || graph is GetUsrGoodsUnitDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GetUsrGoodsUnitDataWork).FullName));

            if (graph != null && graph is GetUsrGoodsUnitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GetUsrGoodsUnitDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GetUsrGoodsUnitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GetUsrGoodsUnitDataWork[])graph).Length;
            }
            else if (graph is GetUsrGoodsUnitDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //JANコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //ハイフン無商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDate
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //作成日時(価格)
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceCreateDateTime
            //更新日時(価格)
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceUpdateDateTime
            //企業コード(価格)
            serInfo.MemberInfo.Add(typeof(string)); //PriceEnterpriseCode
            //GUID(価格)
            serInfo.MemberInfo.Add(typeof(byte[]));  //PriceFileHeaderGuid
            //更新従業員コード(価格)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdEmployeeCode
            //更新アセンブリID1(価格)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdAssemblyId1
            //更新アセンブリID2(価格)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdAssemblyId2
            //論理削除区分(価格)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceLogicalDeleteCode
            //商品メーカーコード(価格)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceGoodsMakerCd
            //商品番号(価格)
            serInfo.MemberInfo.Add(typeof(string)); //PriceGoodsNo
            //価格開始日(価格)
            serInfo.MemberInfo.Add(typeof(Int32)); //PricePriceStartDate
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //PriceListPrice
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //PriceSalesUnitCost
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //PriceStockRate
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceOpenPriceDiv
            //提供日付(価格)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceOfferDate
            //更新年月日(価格)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDate
            //対象件数
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCount


            serInfo.Serialize(writer, serInfo);
            if (graph is GetUsrGoodsUnitDataWork)
            {
                GetUsrGoodsUnitDataWork temp = (GetUsrGoodsUnitDataWork)graph;

                SetGetUsrGoodsUnitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GetUsrGoodsUnitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GetUsrGoodsUnitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GetUsrGoodsUnitDataWork temp in lst)
                {
                    SetGetUsrGoodsUnitDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GetUsrGoodsUnitDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  GetUsrGoodsUnitDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGetUsrGoodsUnitDataWork(System.IO.BinaryWriter writer, GetUsrGoodsUnitDataWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //JANコード
            writer.Write(temp.Jan);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //ハイフン無商品番号
            writer.Write(temp.GoodsNoNoneHyphen);
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品備考１
            writer.Write(temp.GoodsNote1);
            //商品備考２
            writer.Write(temp.GoodsNote2);
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);
            //作成日時(価格)
            writer.Write((Int64)temp.PriceCreateDateTime.Ticks);
            //更新日時(価格)
            writer.Write((Int64)temp.PriceUpdateDateTime.Ticks);
            //企業コード(価格)
            writer.Write(temp.PriceEnterpriseCode);
            //GUID(価格)
            byte[] priceFileHeaderGuidArray = temp.PriceFileHeaderGuid.ToByteArray();
            writer.Write(priceFileHeaderGuidArray.Length);
            writer.Write(temp.PriceFileHeaderGuid.ToByteArray());
            //更新従業員コード(価格)
            writer.Write(temp.PriceUpdEmployeeCode);
            //更新アセンブリID1(価格)
            writer.Write(temp.PriceUpdAssemblyId1);
            //更新アセンブリID2(価格)
            writer.Write(temp.PriceUpdAssemblyId2);
            //論理削除区分(価格)
            writer.Write(temp.PriceLogicalDeleteCode);
            //商品メーカーコード(価格)
            writer.Write(temp.PriceGoodsMakerCd);
            //商品番号(価格)
            writer.Write(temp.PriceGoodsNo);
            //価格開始日(価格)
            writer.Write(temp.PricePriceStartDate);
            //定価（浮動）
            writer.Write(temp.PriceListPrice);
            //原価単価
            writer.Write(temp.PriceSalesUnitCost);
            //仕入率
            writer.Write(temp.PriceStockRate);
            //オープン価格区分
            writer.Write(temp.PriceOpenPriceDiv);
            //提供日付(価格)
            writer.Write(temp.PriceOfferDate);
            //更新年月日(価格)
            writer.Write(temp.PriceUpdateDate);
            //対象件数
            writer.Write(temp.PriceCount);

        }

        /// <summary>
        ///  GetUsrGoodsUnitDataWorkインスタンス取得
        /// </summary>
        /// <returns>GetUsrGoodsUnitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GetUsrGoodsUnitDataWork GetGetUsrGoodsUnitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GetUsrGoodsUnitDataWork temp = new GetUsrGoodsUnitDataWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //JANコード
            temp.Jan = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //ハイフン無商品番号
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品備考１
            temp.GoodsNote1 = reader.ReadString();
            //商品備考２
            temp.GoodsNote2 = reader.ReadString();
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();
            //作成日時(価格)
            temp.PriceCreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時(価格)
            temp.PriceUpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード(価格)
            temp.PriceEnterpriseCode = reader.ReadString();
            //GUID(価格)
            int lenOfPriceFileHeaderGuidArray = reader.ReadInt32();
            byte[] priceFileHeaderGuidArray = reader.ReadBytes(lenOfPriceFileHeaderGuidArray);
            temp.PriceFileHeaderGuid = new Guid(priceFileHeaderGuidArray);
            //更新従業員コード(価格)
            temp.PriceUpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1(価格)
            temp.PriceUpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2(価格)
            temp.PriceUpdAssemblyId2 = reader.ReadString();
            //論理削除区分(価格)
            temp.PriceLogicalDeleteCode = reader.ReadInt32();
            //商品メーカーコード(価格)
            temp.PriceGoodsMakerCd = reader.ReadInt32();
            //商品番号(価格)
            temp.PriceGoodsNo = reader.ReadString();
            //価格開始日(価格)
            temp.PricePriceStartDate = reader.ReadInt32();
            //定価（浮動）
            temp.PriceListPrice = reader.ReadDouble();
            //原価単価
            temp.PriceSalesUnitCost = reader.ReadDouble();
            //仕入率
            temp.PriceStockRate = reader.ReadDouble();
            //オープン価格区分
            temp.PriceOpenPriceDiv = reader.ReadInt32();
            //提供日付(価格)
            temp.PriceOfferDate = reader.ReadInt32();
            //更新年月日(価格)
            temp.PriceUpdateDate = reader.ReadInt32();
            //対象件数
            temp.PriceCount = reader.ReadInt32();


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
        /// <returns>GetUsrGoodsUnitDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetUsrGoodsUnitDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GetUsrGoodsUnitDataWork temp = GetGetUsrGoodsUnitDataWork(reader, serInfo);
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
                    retValue = (GetUsrGoodsUnitDataWork[])lst.ToArray(typeof(GetUsrGoodsUnitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    // --- ADD 2021/07/20 3H 王俊 「提供データ更新処理」機能がシリアライズ障害対応-----<<<<<
}

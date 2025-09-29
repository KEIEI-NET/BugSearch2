using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RateSearchResult
    /// <summary>
    ///                      掛率マスタ一括登録修正抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタ一括登録修正抽出結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RateSearchResult
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>単価掛率設定区分</summary>
        /// <remarks>単価種類＋掛率設定区分（1A1,2A2等）</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>単価種類</summary>
        /// <remarks>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</remarks>
        private string _unitPriceKind = "";

        /// <summary>掛率設定区分</summary>
        /// <remarks>A1,A2等</remarks>
        private string _rateSettingDivide = "";

        /// <summary>掛率設定区分（商品）</summary>
        /// <remarks>A～O　</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>掛率設定名称（商品）</summary>
        /// <remarks>A： "メーカー＋商品"</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>掛率設定区分（得意先）</summary>
        /// <remarks>1～9　</remarks>
        private string _rateMngCustCd = "";

        /// <summary>掛率設定名称（得意先）</summary>
        /// <remarks>1： "得意先＋仕入先"</remarks>
        private string _rateMngCustNm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>中分類を使用</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>ロット数</summary>
        /// <remarks>表示順位はロット数の昇順とする</remarks>
        private Double _lotCount;

        /// <summary>価格（浮動）</summary>
        /// <remarks>売価設定/売上単価、原価設定/仕入単価、定価設定/定価</remarks>
        private Double _priceFl;

        /// <summary>掛率</summary>
        /// <remarks>掛率（売価設定/売価率、仕入設定/仕入率）</remarks>
        private Double _rateVal;

        /// <summary>UP率</summary>
        /// <remarks>UP率（売価設定/原価UP率、定価/定価UP率）</remarks>
        private Double _upRate;

        /// <summary>粗利確保率</summary>
        /// <remarks>売上単価のみ</remarks>
        private Double _grsProfitSecureRate;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        /// <remarks>1:切捨て, 2:四捨五入, 3:切上げ</remarks>
        private Int32 _unPrcFracProcDiv;

        /// <summary>商品中分類コード</summary>
        /// <remarks>【優良設定マスタ】</remarks>
        private Int32 _prmGoodsMGroup;

        /// <summary>BLコード</summary>
        /// <remarks>【優良設定マスタ】</remarks>
        private Int32 _prmTbsPartsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>部品メーカーコード</summary>
        /// <remarks>【優良設定マスタ】</remarks>
        private Int32 _prmPartsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>【商品管理情報マスタ】</remarks>
        private Int32 _goodsSupplierCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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

        /// public propaty name  :  UnitRateSetDivCd
        /// <summary>単価掛率設定区分プロパティ</summary>
        /// <value>単価種類＋掛率設定区分（1A1,2A2等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価掛率設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitRateSetDivCd
        {
            get { return _unitRateSetDivCd; }
            set { _unitRateSetDivCd = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>単価種類プロパティ</summary>
        /// <value>1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価種類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>掛率設定区分プロパティ</summary>
        /// <value>A1,A2等</value>
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

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>掛率設定区分（商品）プロパティ</summary>
        /// <value>A～O　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>掛率設定名称（商品）プロパティ</summary>
        /// <value>A： "メーカー＋商品"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（商品）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>掛率設定区分（得意先）プロパティ</summary>
        /// <value>1～9　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定区分（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>掛率設定名称（得意先）プロパティ</summary>
        /// <value>1： "得意先＋仕入先"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率設定名称（得意先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
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

        /// public propaty name  :  LotCount
        /// <summary>ロット数プロパティ</summary>
        /// <value>表示順位はロット数の昇順とする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロット数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LotCount
        {
            get { return _lotCount; }
            set { _lotCount = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>価格（浮動）プロパティ</summary>
        /// <value>売価設定/売上単価、原価設定/仕入単価、定価設定/定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>掛率プロパティ</summary>
        /// <value>掛率（売価設定/売価率、仕入設定/仕入率）</value>
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

        /// public propaty name  :  UpRate
        /// <summary>UP率プロパティ</summary>
        /// <value>UP率（売価設定/原価UP率、定価/定価UP率）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>粗利確保率プロパティ</summary>
        /// <value>売上単価のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利確保率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitSecureRate
        {
            get { return _grsProfitSecureRate; }
            set { _grsProfitSecureRate = value; }
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
        /// <value>1:切捨て, 2:四捨五入, 3:切上げ</value>
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

        /// public propaty name  :  PrmGoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>【優良設定マスタ】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmGoodsMGroup
        {
            get { return _prmGoodsMGroup; }
            set { _prmGoodsMGroup = value; }
        }

        /// public propaty name  :  PrmTbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>【優良設定マスタ】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmTbsPartsCode
        {
            get { return _prmTbsPartsCode; }
            set { _prmTbsPartsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  PrmPartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>【優良設定マスタ】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmPartsMakerCd
        {
            get { return _prmPartsMakerCd; }
            set { _prmPartsMakerCd = value; }
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

        /// public propaty name  :  GoodsSupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>【商品管理情報マスタ】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsSupplierCd
        {
            get { return _goodsSupplierCd; }
            set { _goodsSupplierCd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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


        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラスコンストラクタ
        /// </summary>
        /// <returns>RateSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateSearchResult()
        {
        }

        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitRateSetDivCd">単価掛率設定区分(単価種類＋掛率設定区分（1A1,2A2等）)</param>
        /// <param name="unitPriceKind">単価種類(1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価)</param>
        /// <param name="rateSettingDivide">掛率設定区分(A1,A2等)</param>
        /// <param name="rateMngGoodsCd">掛率設定区分（商品）(A～O　)</param>
        /// <param name="rateMngGoodsNm">掛率設定名称（商品）(A： "メーカー＋商品")</param>
        /// <param name="rateMngCustCd">掛率設定区分（得意先）(1～9　)</param>
        /// <param name="rateMngCustNm">掛率設定名称（得意先）(1： "得意先＋仕入先")</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsRateRank">商品掛率ランク(層別)</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード(中分類を使用)</param>
        /// <param name="bLGroupCode">BLグループコード(商品区分詳細)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="lotCount">ロット数(表示順位はロット数の昇順とする)</param>
        /// <param name="priceFl">価格（浮動）(売価設定/売上単価、原価設定/仕入単価、定価設定/定価)</param>
        /// <param name="rateVal">掛率(掛率（売価設定/売価率、仕入設定/仕入率）)</param>
        /// <param name="upRate">UP率(UP率（売価設定/原価UP率、定価/定価UP率）)</param>
        /// <param name="grsProfitSecureRate">粗利確保率(売上単価のみ)</param>
        /// <param name="unPrcFracProcUnit">単価端数処理単位</param>
        /// <param name="unPrcFracProcDiv">単価端数処理区分(1:切捨て, 2:四捨五入, 3:切上げ)</param>
        /// <param name="prmGoodsMGroup">商品中分類コード(【優良設定マスタ】)</param>
        /// <param name="prmTbsPartsCode">BLコード(【優良設定マスタ】)</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <param name="prmPartsMakerCd">部品メーカーコード(【優良設定マスタ】)</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsSupplierCd">仕入先コード(【商品管理情報マスタ】)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>RateSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateSearchResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string unitRateSetDivCd, string unitPriceKind, string rateSettingDivide, string rateMngGoodsCd, string rateMngGoodsNm, string rateMngCustCd, string rateMngCustNm, Int32 goodsMakerCd, string goodsNo, string goodsRateRank, Int32 goodsRateGrpCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 customerCode, Int32 custRateGrpCode, Int32 supplierCd, Double lotCount, Double priceFl, Double rateVal, Double upRate, Double grsProfitSecureRate, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Int32 prmGoodsMGroup, Int32 prmTbsPartsCode, string bLGoodsHalfName, Int32 prmPartsMakerCd, string makerName, Int32 goodsSupplierCd, string enterpriseName, string updEmployeeName, string bLGoodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._unitRateSetDivCd = unitRateSetDivCd;
            this._unitPriceKind = unitPriceKind;
            this._rateSettingDivide = rateSettingDivide;
            this._rateMngGoodsCd = rateMngGoodsCd;
            this._rateMngGoodsNm = rateMngGoodsNm;
            this._rateMngCustCd = rateMngCustCd;
            this._rateMngCustNm = rateMngCustNm;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsRateRank = goodsRateRank;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._lotCount = lotCount;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._upRate = upRate;
            this._grsProfitSecureRate = grsProfitSecureRate;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._prmGoodsMGroup = prmGoodsMGroup;
            this._prmTbsPartsCode = prmTbsPartsCode;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._prmPartsMakerCd = prmPartsMakerCd;
            this._makerName = makerName;
            this._goodsSupplierCd = goodsSupplierCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラス複製処理
        /// </summary>
        /// <returns>RateSearchResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRateSearchResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateSearchResult Clone()
        {
            return new RateSearchResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._unitRateSetDivCd, this._unitPriceKind, this._rateSettingDivide, this._rateMngGoodsCd, this._rateMngGoodsNm, this._rateMngCustCd, this._rateMngCustNm, this._goodsMakerCd, this._goodsNo, this._goodsRateRank, this._goodsRateGrpCode, this._bLGroupCode, this._bLGoodsCode, this._customerCode, this._custRateGrpCode, this._supplierCd, this._lotCount, this._priceFl, this._rateVal, this._upRate, this._grsProfitSecureRate, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._prmGoodsMGroup, this._prmTbsPartsCode, this._bLGoodsHalfName, this._prmPartsMakerCd, this._makerName, this._goodsSupplierCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
        }

        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のRateSearchResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RateSearchResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UnitRateSetDivCd == target.UnitRateSetDivCd)
                 && (this.UnitPriceKind == target.UnitPriceKind)
                 && (this.RateSettingDivide == target.RateSettingDivide)
                 && (this.RateMngGoodsCd == target.RateMngGoodsCd)
                 && (this.RateMngGoodsNm == target.RateMngGoodsNm)
                 && (this.RateMngCustCd == target.RateMngCustCd)
                 && (this.RateMngCustNm == target.RateMngCustNm)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.LotCount == target.LotCount)
                 && (this.PriceFl == target.PriceFl)
                 && (this.RateVal == target.RateVal)
                 && (this.UpRate == target.UpRate)
                 && (this.GrsProfitSecureRate == target.GrsProfitSecureRate)
                 && (this.UnPrcFracProcUnit == target.UnPrcFracProcUnit)
                 && (this.UnPrcFracProcDiv == target.UnPrcFracProcDiv)
                 && (this.PrmGoodsMGroup == target.PrmGoodsMGroup)
                 && (this.PrmTbsPartsCode == target.PrmTbsPartsCode)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.PrmPartsMakerCd == target.PrmPartsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsSupplierCd == target.GoodsSupplierCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラス比較処理
        /// </summary>
        /// <param name="rateSearchResult1">
        ///                    比較するRateSearchResultクラスのインスタンス
        /// </param>
        /// <param name="rateSearchResult2">比較するRateSearchResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RateSearchResult rateSearchResult1, RateSearchResult rateSearchResult2)
        {
            return ((rateSearchResult1.CreateDateTime == rateSearchResult2.CreateDateTime)
                 && (rateSearchResult1.UpdateDateTime == rateSearchResult2.UpdateDateTime)
                 && (rateSearchResult1.EnterpriseCode == rateSearchResult2.EnterpriseCode)
                 && (rateSearchResult1.FileHeaderGuid == rateSearchResult2.FileHeaderGuid)
                 && (rateSearchResult1.UpdEmployeeCode == rateSearchResult2.UpdEmployeeCode)
                 && (rateSearchResult1.UpdAssemblyId1 == rateSearchResult2.UpdAssemblyId1)
                 && (rateSearchResult1.UpdAssemblyId2 == rateSearchResult2.UpdAssemblyId2)
                 && (rateSearchResult1.LogicalDeleteCode == rateSearchResult2.LogicalDeleteCode)
                 && (rateSearchResult1.SectionCode == rateSearchResult2.SectionCode)
                 && (rateSearchResult1.UnitRateSetDivCd == rateSearchResult2.UnitRateSetDivCd)
                 && (rateSearchResult1.UnitPriceKind == rateSearchResult2.UnitPriceKind)
                 && (rateSearchResult1.RateSettingDivide == rateSearchResult2.RateSettingDivide)
                 && (rateSearchResult1.RateMngGoodsCd == rateSearchResult2.RateMngGoodsCd)
                 && (rateSearchResult1.RateMngGoodsNm == rateSearchResult2.RateMngGoodsNm)
                 && (rateSearchResult1.RateMngCustCd == rateSearchResult2.RateMngCustCd)
                 && (rateSearchResult1.RateMngCustNm == rateSearchResult2.RateMngCustNm)
                 && (rateSearchResult1.GoodsMakerCd == rateSearchResult2.GoodsMakerCd)
                 && (rateSearchResult1.GoodsNo == rateSearchResult2.GoodsNo)
                 && (rateSearchResult1.GoodsRateRank == rateSearchResult2.GoodsRateRank)
                 && (rateSearchResult1.GoodsRateGrpCode == rateSearchResult2.GoodsRateGrpCode)
                 && (rateSearchResult1.BLGroupCode == rateSearchResult2.BLGroupCode)
                 && (rateSearchResult1.BLGoodsCode == rateSearchResult2.BLGoodsCode)
                 && (rateSearchResult1.CustomerCode == rateSearchResult2.CustomerCode)
                 && (rateSearchResult1.CustRateGrpCode == rateSearchResult2.CustRateGrpCode)
                 && (rateSearchResult1.SupplierCd == rateSearchResult2.SupplierCd)
                 && (rateSearchResult1.LotCount == rateSearchResult2.LotCount)
                 && (rateSearchResult1.PriceFl == rateSearchResult2.PriceFl)
                 && (rateSearchResult1.RateVal == rateSearchResult2.RateVal)
                 && (rateSearchResult1.UpRate == rateSearchResult2.UpRate)
                 && (rateSearchResult1.GrsProfitSecureRate == rateSearchResult2.GrsProfitSecureRate)
                 && (rateSearchResult1.UnPrcFracProcUnit == rateSearchResult2.UnPrcFracProcUnit)
                 && (rateSearchResult1.UnPrcFracProcDiv == rateSearchResult2.UnPrcFracProcDiv)
                 && (rateSearchResult1.PrmGoodsMGroup == rateSearchResult2.PrmGoodsMGroup)
                 && (rateSearchResult1.PrmTbsPartsCode == rateSearchResult2.PrmTbsPartsCode)
                 && (rateSearchResult1.BLGoodsHalfName == rateSearchResult2.BLGoodsHalfName)
                 && (rateSearchResult1.PrmPartsMakerCd == rateSearchResult2.PrmPartsMakerCd)
                 && (rateSearchResult1.MakerName == rateSearchResult2.MakerName)
                 && (rateSearchResult1.GoodsSupplierCd == rateSearchResult2.GoodsSupplierCd)
                 && (rateSearchResult1.EnterpriseName == rateSearchResult2.EnterpriseName)
                 && (rateSearchResult1.UpdEmployeeName == rateSearchResult2.UpdEmployeeName)
                 && (rateSearchResult1.BLGoodsName == rateSearchResult2.BLGoodsName));
        }
        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のRateSearchResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RateSearchResult target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UnitRateSetDivCd != target.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (this.UnitPriceKind != target.UnitPriceKind) resList.Add("UnitPriceKind");
            if (this.RateSettingDivide != target.RateSettingDivide) resList.Add("RateSettingDivide");
            if (this.RateMngGoodsCd != target.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (this.RateMngGoodsNm != target.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (this.RateMngCustCd != target.RateMngCustCd) resList.Add("RateMngCustCd");
            if (this.RateMngCustNm != target.RateMngCustNm) resList.Add("RateMngCustNm");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.LotCount != target.LotCount) resList.Add("LotCount");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.GrsProfitSecureRate != target.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.PrmGoodsMGroup != target.PrmGoodsMGroup) resList.Add("PrmGoodsMGroup");
            if (this.PrmTbsPartsCode != target.PrmTbsPartsCode) resList.Add("PrmTbsPartsCode");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.PrmPartsMakerCd != target.PrmPartsMakerCd) resList.Add("PrmPartsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsSupplierCd != target.GoodsSupplierCd) resList.Add("GoodsSupplierCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 掛率マスタ一括登録修正抽出結果クラス比較処理
        /// </summary>
        /// <param name="rateSearchResult1">比較するRateSearchResultクラスのインスタンス</param>
        /// <param name="rateSearchResult2">比較するRateSearchResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RateSearchResult rateSearchResult1, RateSearchResult rateSearchResult2)
        {
            ArrayList resList = new ArrayList();
            if (rateSearchResult1.CreateDateTime != rateSearchResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (rateSearchResult1.UpdateDateTime != rateSearchResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rateSearchResult1.EnterpriseCode != rateSearchResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rateSearchResult1.FileHeaderGuid != rateSearchResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rateSearchResult1.UpdEmployeeCode != rateSearchResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rateSearchResult1.UpdAssemblyId1 != rateSearchResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rateSearchResult1.UpdAssemblyId2 != rateSearchResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rateSearchResult1.LogicalDeleteCode != rateSearchResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rateSearchResult1.SectionCode != rateSearchResult2.SectionCode) resList.Add("SectionCode");
            if (rateSearchResult1.UnitRateSetDivCd != rateSearchResult2.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (rateSearchResult1.UnitPriceKind != rateSearchResult2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (rateSearchResult1.RateSettingDivide != rateSearchResult2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (rateSearchResult1.RateMngGoodsCd != rateSearchResult2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (rateSearchResult1.RateMngGoodsNm != rateSearchResult2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (rateSearchResult1.RateMngCustCd != rateSearchResult2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (rateSearchResult1.RateMngCustNm != rateSearchResult2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (rateSearchResult1.GoodsMakerCd != rateSearchResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rateSearchResult1.GoodsNo != rateSearchResult2.GoodsNo) resList.Add("GoodsNo");
            if (rateSearchResult1.GoodsRateRank != rateSearchResult2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rateSearchResult1.GoodsRateGrpCode != rateSearchResult2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (rateSearchResult1.BLGroupCode != rateSearchResult2.BLGroupCode) resList.Add("BLGroupCode");
            if (rateSearchResult1.BLGoodsCode != rateSearchResult2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rateSearchResult1.CustomerCode != rateSearchResult2.CustomerCode) resList.Add("CustomerCode");
            if (rateSearchResult1.CustRateGrpCode != rateSearchResult2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rateSearchResult1.SupplierCd != rateSearchResult2.SupplierCd) resList.Add("SupplierCd");
            if (rateSearchResult1.LotCount != rateSearchResult2.LotCount) resList.Add("LotCount");
            if (rateSearchResult1.PriceFl != rateSearchResult2.PriceFl) resList.Add("PriceFl");
            if (rateSearchResult1.RateVal != rateSearchResult2.RateVal) resList.Add("RateVal");
            if (rateSearchResult1.UpRate != rateSearchResult2.UpRate) resList.Add("UpRate");
            if (rateSearchResult1.GrsProfitSecureRate != rateSearchResult2.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");
            if (rateSearchResult1.UnPrcFracProcUnit != rateSearchResult2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (rateSearchResult1.UnPrcFracProcDiv != rateSearchResult2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (rateSearchResult1.PrmGoodsMGroup != rateSearchResult2.PrmGoodsMGroup) resList.Add("PrmGoodsMGroup");
            if (rateSearchResult1.PrmTbsPartsCode != rateSearchResult2.PrmTbsPartsCode) resList.Add("PrmTbsPartsCode");
            if (rateSearchResult1.BLGoodsHalfName != rateSearchResult2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (rateSearchResult1.PrmPartsMakerCd != rateSearchResult2.PrmPartsMakerCd) resList.Add("PrmPartsMakerCd");
            if (rateSearchResult1.MakerName != rateSearchResult2.MakerName) resList.Add("MakerName");
            if (rateSearchResult1.GoodsSupplierCd != rateSearchResult2.GoodsSupplierCd) resList.Add("GoodsSupplierCd");
            if (rateSearchResult1.EnterpriseName != rateSearchResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (rateSearchResult1.UpdEmployeeName != rateSearchResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (rateSearchResult1.BLGoodsName != rateSearchResult2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}

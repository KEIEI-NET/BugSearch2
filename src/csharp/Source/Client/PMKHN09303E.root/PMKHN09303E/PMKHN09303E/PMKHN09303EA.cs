using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Rate
    /// <summary>
    ///                      掛率マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class Rate
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
        /// <remarks>単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>単価種類</summary>
        /// <remarks>1:売上単価　2:売上原価　3:仕入単価 4:定価</remarks>
        private string _unitPriceKind = "1";

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
        private string _goodsRateRank = "";

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
        /// <remarks>ずばり値</remarks>
        private Double _priceFl;

        /// <summary>掛率</summary>
        /// <remarks>掛率</remarks>
        private Double _rateVal;

        /// <summary>単価端数処理単位</summary>
        private Double _unPrcFracProcUnit;

        /// <summary>単価端数処理区分</summary>
        private Int32 _unPrcFracProcDiv;

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>UP率</summary>
        private Double _upRate;

        /// <summary>粗利確保率</summary>
        private Double _grsProfitSecureRate;

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
        /// <value>単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）</value>
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
        /// <value>1:売上単価　2:売上原価　3:仕入単価 4:定価</value>
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
        /// <value>ずばり値</value>
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

        /// public property name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
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

        /// public property name  :  BLGroupCode
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

        /// public property name  :  UpRate
        /// <summary>UP率プロパティ</summary>
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

        /// public property name  :  GrsProfitSecureRate
        /// <summary>粗利確保率プロパティ</summary>
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

        /// <summary>
        /// 掛率マスタコンストラクタ
        /// </summary>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate()
        {
        }

        /// <summary>
        /// 掛率マスタコンストラクタ
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
        /// <param name="unitRateSetDivCd">単価掛率設定区分(単価種類＋掛率設定区分＋新旧区分（1A10,2A21等）)</param>
        /// <param name="unitPriceKind">単価種類(1:売上単価　2:売上原価　3:仕入単価 4:定価)</param>
        /// <param name="rateSettingDivide">掛率設定区分(A1,A2等)</param>
        /// <param name="rateMngGoodsCd">掛率設定区分（商品）(A～O)</param>
        /// <param name="rateMngGoodsNm">掛率設定名称（商品）(A： "メーカー＋商品")</param>
        /// <param name="rateMngCustCd">掛率設定区分（得意先）(1～9)</param>
        /// <param name="rateMngCustNm">掛率設定名称（得意先）(1： "得意先＋仕入先")</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsRateRank">商品掛率ランク</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="customerCode">>得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="lotCount">ロット数(表示順位はロット数の昇順とする)</param>
        /// <param name="priceFl">価格（浮動）(ずばり値)</param>
        /// <param name="rateVal">掛率</param>
        /// <param name="unPrcFracProcUnit">単価端数処理単位</param>
        /// <param name="unPrcFracProcDiv">単価端数処理区分</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="upRate">UP率</param>
        /// <param name="grsProfitSecureRate">粗利確保率</param>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate(
                            DateTime createDateTime,
                            DateTime updateDateTime,
                            string enterpriseCode,
                            Guid fileHeaderGuid,
                            string updEmployeeCode,
                            string updAssemblyId1,
                            string updAssemblyId2,
                            Int32 logicalDeleteCode,
                            string sectionCode,
                            string unitRateSetDivCd,
                            string unitPriceKind,
                            string rateSettingDivide,
                            string rateMngGoodsCd,
                            string rateMngGoodsNm,
                            string rateMngCustCd,
                            string rateMngCustNm,
                            Int32 goodsMakerCd,
                            string goodsNo,
                            string goodsRateRank,
                            Int32 bLGoodsCode,
                            Int32 customerCode,
                            Int32 custRateGrpCode,
                            Int32 supplierCd,
                            Double lotCount,
                            Double priceFl,
                            Double rateVal,
                            Double unPrcFracProcUnit,
                            Int32 goodsRateGrpCode,
                            Int32 bLGroupCode,
                            Double upRate,
                            Double grsProfitSecureRate,
                            Int32 unPrcFracProcDiv)
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
            this._bLGoodsCode = bLGoodsCode;
            this._customerCode = customerCode;
            this._custRateGrpCode = custRateGrpCode;
            this._supplierCd = supplierCd;
            this._lotCount = lotCount;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._unPrcFracProcUnit = unPrcFracProcUnit;
            this._unPrcFracProcDiv = unPrcFracProcDiv;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._bLGroupCode = bLGroupCode;
            this._upRate = upRate;
            this._grsProfitSecureRate = grsProfitSecureRate;
        }

        /// <summary>
        /// 掛率マスタ複製処理
        /// </summary>
        /// <returns>Rateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRateクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Rate Clone()
        {
            return new Rate(
                                    this._createDateTime,
                                    this._updateDateTime,
                                    this._enterpriseCode,
                                    this._fileHeaderGuid,
                                    this._updEmployeeCode,
                                    this._updAssemblyId1,
                                    this._updAssemblyId2,
                                    this._logicalDeleteCode,
                                    this._sectionCode,
                                    this._unitRateSetDivCd,
                                    this._unitPriceKind,
                                    this._rateSettingDivide,
                                    this._rateMngGoodsCd,
                                    this._rateMngGoodsNm,
                                    this._rateMngCustCd,
                                    this._rateMngCustNm,
                                    this._goodsMakerCd,
                                    this._goodsNo,
                                    this._goodsRateRank,
                                    this._bLGoodsCode,
                                    this._customerCode,
                                    this._custRateGrpCode,
                                    this._supplierCd,
                                    this._lotCount,
                                    this._priceFl,
                                    this._rateVal,
                                    this._unPrcFracProcUnit,
                                    this._goodsRateGrpCode,
                                    this._bLGroupCode,
                                    this._upRate,
                                    this._grsProfitSecureRate,
                                    this._unPrcFracProcDiv);
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Rate target)
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
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.CustomerCode == target.CustomerCode)
                && (this.CustRateGrpCode == target.CustRateGrpCode)
                && (this.SupplierCd == target.SupplierCd)
                && (this.LotCount == target.LotCount)
                && (this.PriceFl == target.PriceFl)
                && (this.RateVal == target.RateVal)
                && (this.UnPrcFracProcUnit == target.UnPrcFracProcUnit)
                && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                && (this.BLGroupCode == target.BLGroupCode)
                && (this.UpRate == target.UpRate)
                && (this.GrsProfitSecureRate == target.GrsProfitSecureRate)
                && (this.UnPrcFracProcDiv == target.UnPrcFracProcDiv));
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="rate1">
        ///                    比較するRateクラスのインスタンス
        /// </param>
        /// <param name="rate2">比較するRateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Rate rate1, Rate rate2)
        {
            return ((rate1.CreateDateTime == rate2.CreateDateTime)
                && (rate1.UpdateDateTime == rate2.UpdateDateTime)
                && (rate1.EnterpriseCode == rate2.EnterpriseCode)
                && (rate1.FileHeaderGuid == rate2.FileHeaderGuid)
                && (rate1.UpdEmployeeCode == rate2.UpdEmployeeCode)
                && (rate1.UpdAssemblyId1 == rate2.UpdAssemblyId1)
                && (rate1.UpdAssemblyId2 == rate2.UpdAssemblyId2)
                && (rate1.LogicalDeleteCode == rate2.LogicalDeleteCode)
                && (rate1.SectionCode == rate2.SectionCode)
                && (rate1.UnitRateSetDivCd == rate2.UnitRateSetDivCd)
                && (rate1.UnitPriceKind == rate2.UnitPriceKind)
                && (rate1.RateSettingDivide == rate2.RateSettingDivide)
                && (rate1.RateMngGoodsCd == rate2.RateMngGoodsCd)
                && (rate1.RateMngGoodsNm == rate2.RateMngGoodsNm)
                && (rate1.RateMngCustCd == rate2.RateMngCustCd)
                && (rate1.RateMngCustNm == rate2.RateMngCustNm)
                && (rate1.GoodsMakerCd == rate2.GoodsMakerCd)
                && (rate1.GoodsNo == rate2.GoodsNo)
                && (rate1.GoodsRateRank == rate2.GoodsRateRank)
                && (rate1.BLGoodsCode == rate2.BLGoodsCode)
                && (rate1.CustomerCode == rate2.CustomerCode)
                && (rate1.CustRateGrpCode == rate2.CustRateGrpCode)
                && (rate1.SupplierCd == rate2.SupplierCd)
                && (rate1.LotCount == rate2.LotCount)
                && (rate1.PriceFl == rate2.PriceFl)
                && (rate1.RateVal == rate2.RateVal)
                && (rate1.UnPrcFracProcUnit == rate2.UnPrcFracProcUnit)
                && (rate1.GoodsRateGrpCode == rate2.GoodsRateGrpCode)
                && (rate1.BLGroupCode == rate2.BLGroupCode)
                && (rate1.UpRate == rate2.UpRate)
                && (rate1.GrsProfitSecureRate == rate2.GrsProfitSecureRate)
                && (rate1.UnPrcFracProcDiv == rate2.UnPrcFracProcDiv));
        }
        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Rate target)
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
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.LotCount != target.LotCount) resList.Add("LotCount");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.UpRate != target.UpRate) resList.Add("UpRate");
            if (this.GrsProfitSecureRate != target.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");

            return resList;
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="rate1">比較するRateクラスのインスタンス</param>
        /// <param name="rate2">比較するRateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Rateクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Rate rate1, Rate rate2)
        {
            ArrayList resList = new ArrayList();
            if (rate1.CreateDateTime != rate2.CreateDateTime) resList.Add("CreateDateTime");
            if (rate1.UpdateDateTime != rate2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rate1.EnterpriseCode != rate2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rate1.FileHeaderGuid != rate2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rate1.UpdEmployeeCode != rate2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rate1.UpdAssemblyId1 != rate2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rate1.UpdAssemblyId2 != rate2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rate1.LogicalDeleteCode != rate2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rate1.SectionCode != rate2.SectionCode) resList.Add("SectionCode");
            if (rate1.UnitRateSetDivCd != rate2.UnitRateSetDivCd) resList.Add("UnitRateSetDivCd");
            if (rate1.UnitPriceKind != rate2.UnitPriceKind) resList.Add("UnitPriceKind");
            if (rate1.RateSettingDivide != rate2.RateSettingDivide) resList.Add("RateSettingDivide");
            if (rate1.RateMngGoodsCd != rate2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
            if (rate1.RateMngGoodsNm != rate2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
            if (rate1.RateMngCustCd != rate2.RateMngCustCd) resList.Add("RateMngCustCd");
            if (rate1.RateMngCustNm != rate2.RateMngCustNm) resList.Add("RateMngCustNm");
            if (rate1.GoodsMakerCd != rate2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (rate1.GoodsNo != rate2.GoodsNo) resList.Add("GoodsNo");
            if (rate1.GoodsRateRank != rate2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (rate1.BLGoodsCode != rate2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (rate1.CustomerCode != rate2.CustomerCode) resList.Add("CustomerCode");
            if (rate1.CustRateGrpCode != rate2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (rate1.SupplierCd != rate2.SupplierCd) resList.Add("SupplierCd");
            if (rate1.LotCount != rate2.LotCount) resList.Add("LotCount");
            if (rate1.PriceFl != rate2.PriceFl) resList.Add("PriceFl");
            if (rate1.RateVal != rate2.RateVal) resList.Add("RateVal");
            if (rate1.UnPrcFracProcUnit != rate2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
            if (rate1.UnPrcFracProcDiv != rate2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
            if (rate1.GoodsRateGrpCode != rate2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (rate1.BLGroupCode != rate2.BLGroupCode) resList.Add("BLGroupCode");
            if (rate1.UpRate != rate2.UpRate) resList.Add("UpRate");
            if (rate1.GrsProfitSecureRate != rate2.GrsProfitSecureRate) resList.Add("GrsProfitSecureRate");

            return resList;
        }
    }
}

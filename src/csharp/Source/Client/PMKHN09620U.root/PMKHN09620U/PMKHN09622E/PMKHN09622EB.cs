using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMng
    /// <summary>
    ///                      キャンペーン対象商品設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン対象商品設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/11  杉村</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   得意先コード</br>
    /// <br>                 :   仕入先コード</br>
    /// <br>                 :   BLグループコード</br>
    /// <br>Update Note      :    2009/5/13  杉村</br>
    /// <br>                 :   ○型変更</br>
    /// <br>                 :   キャンペーンコード</br>
    /// <br>                 :   nvarchar ⇒ Int32</br>
    /// <br>Update Note      :   2011/3/29  花原</br>
    /// <br>                 :   ○項目追加、ＫＥＹ変更</br>
    /// <br>                 :   BLグループコード～価格開始日</br>
    /// <br>                 :   3,9,10,11,12,13→3,9,17,22,10,20,11,21,12,13,24,25,26</br>
    /// </remarks>
    public class CampaignObjGoodsSt
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
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>売上目標金額</summary>
        private Int64 _salesTargetMoney;

        /// <summary>売上目標粗利額</summary>
        private Int64 _salesTargetProfit;

        /// <summary>売上目標数量</summary>
        private Double _salesTargetCount;

        /// <summary>キャンペーンコード</summary>
        /// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
        private Int32 _campaignCode;

        /// <summary>価格（浮動）</summary>
        /// <remarks>売上単価（品番単位のみ設定可）</remarks>
        private Double _priceFl;

        /// <summary>掛率</summary>
        /// <remarks>売価率</remarks>
        private Double _rateVal;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>販売区分コード</summary>
        /// <remarks>ユーザーガイド</remarks>
        private Int32 _salesCode;

        /// <summary>キャンペーン設定種別</summary>
        /// <remarks>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _campaignSettingKind;

        /// <summary>売価設定区分</summary>
        /// <remarks>0なし、1：あり</remarks>
        private Int32 _salesPriceSetDiv;

        /// <summary>得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>価格終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceEndDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>値引率</summary>
        private Double _discountRate;

        /// <summary>行数</summary>
        private Int32 _rowIndex;

        /// <summary>新規行フラグ</summary>
        private Boolean _isUpdRow;

        /// <summary>品名</summary>
        private string _goodsNameKana = "";

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
        /// <value>00は全社</value>
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

        /// public propaty name  :  SalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標粗利額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>売上目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>任意の無重複コードとする（自動付番はしない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>価格（浮動）プロパティ</summary>
        /// <value>売上単価（品番単位のみ設定可）</value>
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
        /// <value>売価率</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
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

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// <value>ユーザーガイド</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  CampaignSettingKind
        /// <summary>キャンペーン設定種別プロパティ</summary>
        /// <value>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン設定種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignSettingKind
        {
            get { return _campaignSettingKind; }
            set { _campaignSettingKind = value; }
        }

        /// public propaty name  :  SalesPriceSetDiv
        /// <summary>売価設定区分プロパティ</summary>
        /// <value>0なし、1：あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesPriceSetDiv
        {
            get { return _salesPriceSetDiv; }
            set { _salesPriceSetDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
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

        /// public propaty name  :  PriceEndDate
        /// <summary>価格終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceEndDate
        {
            get { return _priceEndDate; }
            set { _priceEndDate = value; }
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

        /// public propaty name  :  DiscountRate
        /// <summary>値引率プロパティ</summary>
        /// <value>値引率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  RowIndex
        /// <summary>行数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        /// public propaty name  :  IsUpdRow
        /// <summary>新規行フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新規行フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsUpdRow
        {
            get { return _isUpdRow; }
            set { _isUpdRow = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタコンストラクタ
        /// </summary>
        /// <returns>CampaignMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignObjGoodsSt()
        {
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="salesTargetMoney">売上目標金額</param>
        /// <param name="salesTargetProfit">売上目標粗利額</param>
        /// <param name="salesTargetCount">売上目標数量</param>
        /// <param name="campaignCode">キャンペーンコード(任意の無重複コードとする（自動付番はしない）)</param>
        /// <param name="priceFl">価格（浮動）(売上単価（品番単位のみ設定可）)</param>
        /// <param name="rateVal">掛率(売価率)</param>
        /// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
        /// <param name="salesCode">販売区分コード(ユーザーガイド)</param>
        /// <param name="campaignSettingKind">キャンペーン設定種別(1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="salesPriceSetDiv">売価設定区分(0なし、1：あり)</param>
        /// <param name="customerCode">得意先コード(0は全得意先)</param>
        /// <param name="priceStartDate">価格開始日(YYYYMMDD)</param>
        /// <param name="priceEndDate">価格終了日(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="discountRate">値引率</param>
        /// <param name="rowIndex">行数</param>
        /// <param name="isUpdRow">新規行フラグ</param>
        /// <param name="goodsNameKana">新規行フラグ</param>
        /// <returns>CampaignMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignObjGoodsSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 goodsMGroup, Int32 bLGoodsCode, Int32 goodsMakerCd, string goodsNo, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, Int32 campaignCode, Double priceFl, Double rateVal, Int32 bLGroupCode, Int32 salesCode, Int32 campaignSettingKind, Int32 salesPriceSetDiv, Int32 customerCode, Int32 priceStartDate, Int32 priceEndDate, string enterpriseName, string updEmployeeName, Int32 rowIndex, Double discountRate, Boolean isUpdRow, string goodsNameKana)
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
            this._goodsMGroup = goodsMGroup;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._campaignCode = campaignCode;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._bLGroupCode = bLGroupCode;
            this._salesCode = salesCode;
            this._campaignSettingKind = campaignSettingKind;
            this._salesPriceSetDiv = salesPriceSetDiv;
            this._customerCode = customerCode;
            this._priceStartDate = priceStartDate;
            this._priceEndDate = priceEndDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._discountRate = discountRate;
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
            this._goodsNameKana = goodsNameKana;

        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ複製処理
        /// </summary>
        /// <returns>CampaignMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignMngクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignObjGoodsSt Clone()
        {
            return new CampaignObjGoodsSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._goodsMGroup, this._bLGoodsCode, this._goodsMakerCd, this._goodsNo, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._campaignCode, this._priceFl, this._rateVal, this._bLGroupCode, this._salesCode, this._campaignSettingKind, this._salesPriceSetDiv, this._customerCode, this._priceStartDate, this._priceEndDate, this._enterpriseName, this._updEmployeeName, this._rowIndex, this._discountRate, this._isUpdRow, this._goodsNameKana);
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignMngクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CampaignObjGoodsSt target)
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
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.PriceFl == target.PriceFl)
                 && (this.RateVal == target.RateVal)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.SalesCode == target.SalesCode)
                 && (this.CampaignSettingKind == target.CampaignSettingKind)
                 && (this.SalesPriceSetDiv == target.SalesPriceSetDiv)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.PriceEndDate == target.PriceEndDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DiscountRate == target.DiscountRate)
                 && (this.RowIndex == target.RowIndex)
                 && (this.IsUpdRow == target.IsUpdRow)
                 && (this.GoodsNameKana == target.GoodsNameKana));
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="campaignMng1">
        ///                    比較するCampaignMngクラスのインスタンス
        /// </param>
        /// <param name="campaignMng2">比較するCampaignMngクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            return ((campaignMng1.CreateDateTime == campaignMng2.CreateDateTime)
                 && (campaignMng1.UpdateDateTime == campaignMng2.UpdateDateTime)
                 && (campaignMng1.EnterpriseCode == campaignMng2.EnterpriseCode)
                 && (campaignMng1.FileHeaderGuid == campaignMng2.FileHeaderGuid)
                 && (campaignMng1.UpdEmployeeCode == campaignMng2.UpdEmployeeCode)
                 && (campaignMng1.UpdAssemblyId1 == campaignMng2.UpdAssemblyId1)
                 && (campaignMng1.UpdAssemblyId2 == campaignMng2.UpdAssemblyId2)
                 && (campaignMng1.LogicalDeleteCode == campaignMng2.LogicalDeleteCode)
                 && (campaignMng1.SectionCode == campaignMng2.SectionCode)
                 && (campaignMng1.GoodsMGroup == campaignMng2.GoodsMGroup)
                 && (campaignMng1.BLGoodsCode == campaignMng2.BLGoodsCode)
                 && (campaignMng1.GoodsMakerCd == campaignMng2.GoodsMakerCd)
                 && (campaignMng1.GoodsNo == campaignMng2.GoodsNo)
                 && (campaignMng1.SalesTargetMoney == campaignMng2.SalesTargetMoney)
                 && (campaignMng1.SalesTargetProfit == campaignMng2.SalesTargetProfit)
                 && (campaignMng1.SalesTargetCount == campaignMng2.SalesTargetCount)
                 && (campaignMng1.CampaignCode == campaignMng2.CampaignCode)
                 && (campaignMng1.PriceFl == campaignMng2.PriceFl)
                 && (campaignMng1.RateVal == campaignMng2.RateVal)
                 && (campaignMng1.BLGroupCode == campaignMng2.BLGroupCode)
                 && (campaignMng1.SalesCode == campaignMng2.SalesCode)
                 && (campaignMng1.CampaignSettingKind == campaignMng2.CampaignSettingKind)
                 && (campaignMng1.SalesPriceSetDiv == campaignMng2.SalesPriceSetDiv)
                 && (campaignMng1.CustomerCode == campaignMng2.CustomerCode)
                 && (campaignMng1.PriceStartDate == campaignMng2.PriceStartDate)
                 && (campaignMng1.PriceEndDate == campaignMng2.PriceEndDate)
                 && (campaignMng1.EnterpriseName == campaignMng2.EnterpriseName)
                 && (campaignMng1.UpdEmployeeName == campaignMng2.UpdEmployeeName)
                 && (campaignMng1.DiscountRate == campaignMng2.DiscountRate)
                 && (campaignMng1.RowIndex == campaignMng2.RowIndex)
                 && (campaignMng1.IsUpdRow == campaignMng2.IsUpdRow)
                 && (campaignMng1.GoodsNameKana == campaignMng2.GoodsNameKana));
        }
        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignMngクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CampaignObjGoodsSt target)
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
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.CampaignSettingKind != target.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (this.SalesPriceSetDiv != target.SalesPriceSetDiv) resList.Add("SalesPriceSetDiv");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.PriceEndDate != target.PriceEndDate) resList.Add("PriceEndDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.DiscountRate != target.DiscountRate) resList.Add("DiscountRate");
            if (this.RowIndex != target.RowIndex) resList.Add("RowIndex");
            if (this.IsUpdRow != target.IsUpdRow) resList.Add("IsUpdRow");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");

            return resList;
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="campaignMng1">比較するCampaignMngクラスのインスタンス</param>
        /// <param name="campaignMng2">比較するCampaignMngクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            ArrayList resList = new ArrayList();
            if (campaignMng1.CreateDateTime != campaignMng2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignMng1.UpdateDateTime != campaignMng2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignMng1.EnterpriseCode != campaignMng2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignMng1.FileHeaderGuid != campaignMng2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignMng1.UpdEmployeeCode != campaignMng2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignMng1.UpdAssemblyId1 != campaignMng2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignMng1.UpdAssemblyId2 != campaignMng2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignMng1.LogicalDeleteCode != campaignMng2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignMng1.SectionCode != campaignMng2.SectionCode) resList.Add("SectionCode");
            if (campaignMng1.GoodsMGroup != campaignMng2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignMng1.GoodsNo != campaignMng2.GoodsNo) resList.Add("GoodsNo");
            if (campaignMng1.SalesTargetMoney != campaignMng2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (campaignMng1.SalesTargetProfit != campaignMng2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (campaignMng1.SalesTargetCount != campaignMng2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (campaignMng1.CampaignCode != campaignMng2.CampaignCode) resList.Add("CampaignCode");
            if (campaignMng1.PriceFl != campaignMng2.PriceFl) resList.Add("PriceFl");
            if (campaignMng1.RateVal != campaignMng2.RateVal) resList.Add("RateVal");
            if (campaignMng1.BLGroupCode != campaignMng2.BLGroupCode) resList.Add("BLGroupCode");
            if (campaignMng1.SalesCode != campaignMng2.SalesCode) resList.Add("SalesCode");
            if (campaignMng1.CampaignSettingKind != campaignMng2.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv) resList.Add("SalesPriceSetDiv");
            if (campaignMng1.CustomerCode != campaignMng2.CustomerCode) resList.Add("CustomerCode");
            if (campaignMng1.PriceStartDate != campaignMng2.PriceStartDate) resList.Add("PriceStartDate");
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate) resList.Add("PriceEndDate");
            if (campaignMng1.EnterpriseName != campaignMng2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignMng1.UpdEmployeeName != campaignMng2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (campaignMng1.DiscountRate != campaignMng2.DiscountRate) resList.Add("DiscountRate");
            if (campaignMng1.RowIndex != campaignMng2.RowIndex) resList.Add("RowIndex");
            if (campaignMng1.IsUpdRow != campaignMng2.IsUpdRow) resList.Add("IsUpdRow");
            if (campaignMng1.GoodsNameKana != campaignMng2.GoodsNameKana) resList.Add("GoodsNameKana");

            return resList;
        }
    }
}
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsU
    /// <summary>
    ///                      商品マスタ（ユーザー登録分）
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品マスタ（ユーザー登録分）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/07/22</br>
    /// <br>Genarated Date   :   2011/07/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   許雁波</br>
    /// <br>                 :   連番1029  新規</br>
    /// </remarks>
    public class GoodsU
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
        private Int32 _offerDate;

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
        private Int32 _updateDate;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ,1:提供データ</remarks>
        private Int32 _offerDataDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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
        public Int32 OfferDate
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
        public Int32 UpdateDate
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


        /// <summary>
        /// 商品マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <returns>GoodsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsU()
        {
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="jan">JANコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="goodsRateRank">商品掛率ランク(層別)</param>
        /// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="offerDate">提供日付(YYYYMMDD)</param>
        /// <param name="goodsKindCode">商品属性(0:純正　1:その他)</param>
        /// <param name="goodsNote1">商品備考１</param>
        /// <param name="goodsNote2">商品備考２</param>
        /// <param name="goodsSpecialNote">商品規格・特記事項</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="offerDataDiv">提供データ区分(0:ユーザデータ,1:提供データ)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>GoodsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, Int32 displayOrder, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, Int32 offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, Int32 updateDate, Int32 offerDataDiv, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._jan = jan;
            this._bLGoodsCode = bLGoodsCode;
            this._displayOrder = displayOrder;
            this._goodsRateRank = goodsRateRank;
            this._taxationDivCd = taxationDivCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._offerDate = offerDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsNote1 = goodsNote1;
            this._goodsNote2 = goodsNote2;
            this._goodsSpecialNote = goodsSpecialNote;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._updateDate = updateDate;
            this._offerDataDiv = offerDataDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）複製処理
        /// </summary>
        /// <returns>GoodsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsU Clone()
        {
            return new GoodsU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._displayOrder, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._updateDate, this._offerDataDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.Jan == target.Jan)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.OfferDate == target.OfferDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsNote1 == target.GoodsNote1)
                 && (this.GoodsNote2 == target.GoodsNote2)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="goodsU1">
        ///                    比較するGoodsUクラスのインスタンス
        /// </param>
        /// <param name="goodsU2">比較するGoodsUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsU goodsU1, GoodsU goodsU2)
        {
            return ((goodsU1.CreateDateTime == goodsU2.CreateDateTime)
                 && (goodsU1.UpdateDateTime == goodsU2.UpdateDateTime)
                 && (goodsU1.EnterpriseCode == goodsU2.EnterpriseCode)
                 && (goodsU1.FileHeaderGuid == goodsU2.FileHeaderGuid)
                 && (goodsU1.UpdEmployeeCode == goodsU2.UpdEmployeeCode)
                 && (goodsU1.UpdAssemblyId1 == goodsU2.UpdAssemblyId1)
                 && (goodsU1.UpdAssemblyId2 == goodsU2.UpdAssemblyId2)
                 && (goodsU1.LogicalDeleteCode == goodsU2.LogicalDeleteCode)
                 && (goodsU1.GoodsMakerCd == goodsU2.GoodsMakerCd)
                 && (goodsU1.GoodsNo == goodsU2.GoodsNo)
                 && (goodsU1.GoodsName == goodsU2.GoodsName)
                 && (goodsU1.GoodsNameKana == goodsU2.GoodsNameKana)
                 && (goodsU1.Jan == goodsU2.Jan)
                 && (goodsU1.BLGoodsCode == goodsU2.BLGoodsCode)
                 && (goodsU1.DisplayOrder == goodsU2.DisplayOrder)
                 && (goodsU1.GoodsRateRank == goodsU2.GoodsRateRank)
                 && (goodsU1.TaxationDivCd == goodsU2.TaxationDivCd)
                 && (goodsU1.GoodsNoNoneHyphen == goodsU2.GoodsNoNoneHyphen)
                 && (goodsU1.OfferDate == goodsU2.OfferDate)
                 && (goodsU1.GoodsKindCode == goodsU2.GoodsKindCode)
                 && (goodsU1.GoodsNote1 == goodsU2.GoodsNote1)
                 && (goodsU1.GoodsNote2 == goodsU2.GoodsNote2)
                 && (goodsU1.GoodsSpecialNote == goodsU2.GoodsSpecialNote)
                 && (goodsU1.EnterpriseGanreCode == goodsU2.EnterpriseGanreCode)
                 && (goodsU1.UpdateDate == goodsU2.UpdateDate)
                 && (goodsU1.OfferDataDiv == goodsU2.OfferDataDiv)
                 && (goodsU1.EnterpriseName == goodsU2.EnterpriseName)
                 && (goodsU1.UpdEmployeeName == goodsU2.UpdEmployeeName));
        }
        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsU target)
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
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsNote1 != target.GoodsNote1) resList.Add("GoodsNote1");
            if (this.GoodsNote2 != target.GoodsNote2) resList.Add("GoodsNote2");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="goodsU1">比較するGoodsUクラスのインスタンス</param>
        /// <param name="goodsU2">比較するGoodsUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsU goodsU1, GoodsU goodsU2)
        {
            ArrayList resList = new ArrayList();
            if (goodsU1.CreateDateTime != goodsU2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsU1.UpdateDateTime != goodsU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsU1.EnterpriseCode != goodsU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsU1.FileHeaderGuid != goodsU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsU1.UpdEmployeeCode != goodsU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsU1.UpdAssemblyId1 != goodsU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsU1.UpdAssemblyId2 != goodsU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsU1.LogicalDeleteCode != goodsU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsU1.GoodsMakerCd != goodsU2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsU1.GoodsNo != goodsU2.GoodsNo) resList.Add("GoodsNo");
            if (goodsU1.GoodsName != goodsU2.GoodsName) resList.Add("GoodsName");
            if (goodsU1.GoodsNameKana != goodsU2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (goodsU1.Jan != goodsU2.Jan) resList.Add("Jan");
            if (goodsU1.BLGoodsCode != goodsU2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsU1.DisplayOrder != goodsU2.DisplayOrder) resList.Add("DisplayOrder");
            if (goodsU1.GoodsRateRank != goodsU2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (goodsU1.TaxationDivCd != goodsU2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (goodsU1.GoodsNoNoneHyphen != goodsU2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (goodsU1.OfferDate != goodsU2.OfferDate) resList.Add("OfferDate");
            if (goodsU1.GoodsKindCode != goodsU2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (goodsU1.GoodsNote1 != goodsU2.GoodsNote1) resList.Add("GoodsNote1");
            if (goodsU1.GoodsNote2 != goodsU2.GoodsNote2) resList.Add("GoodsNote2");
            if (goodsU1.GoodsSpecialNote != goodsU2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (goodsU1.EnterpriseGanreCode != goodsU2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (goodsU1.UpdateDate != goodsU2.UpdateDate) resList.Add("UpdateDate");
            if (goodsU1.OfferDataDiv != goodsU2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsU1.EnterpriseName != goodsU2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsU1.UpdEmployeeName != goodsU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}

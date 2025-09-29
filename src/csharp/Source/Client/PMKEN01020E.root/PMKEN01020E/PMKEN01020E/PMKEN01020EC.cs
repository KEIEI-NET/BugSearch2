using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GenuinePartsRetWork
    /// <summary>
    ///                      純正結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   純正結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/08/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2013/02/12 30745 吉岡 孝憲</br>
    /// <br>                 :   2013/03/06配信 SCM障害№169対応 提供 特記事項 追加。それに伴う処理追加</br>
    /// </remarks>
    [Serializable]
    public class GenuinePartsRet
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

        /// <summary>商品メーカー名</summary>
        private string _goodsMakerNm = "";

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

        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>商品規格・特記事項（提供）</summary>
        private string _goodsSpecialNoteOffer = "";
        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>更新年月日</summary>
        private DateTime _updateDate;

        /// <summary>中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>カタログ品番</summary>
        private string _ctlgPartsNo = "";

        /// <summary>最新品番</summary>
        private string _newPartsNo = "";

        /// <summary>結合元品番</summary>
        private string _joinSrcPartsNo = "";

        /// <summary>QTY</summary>
        private Double _partsQty;

        /// <summary>部品オプション名称(特記事項)</summary>
        private string _partsOpNm = "";

        /// <summary>カタログ品番部品オプション名称(特記事項)</summary>
        private string _ctlgPartsOpNm = "";

        /// <summary>規格名称</summary>
        private string _standardName = "";

        /// <summary>価格リスト</summary>
        private List<GoodsPrice> _goodsPriceList = new List<GoodsPrice>();

        /// <summary>在庫リスト</summary>
        private List<Stock> _stockList = new List<Stock>();

        /// <summary>結合部品リスト</summary>
        private List<PrimePartsRet> _primePartsList = new List<PrimePartsRet>();

        /// public property name  :  CreateDateTime
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

        /// public property name  :  UpdateDateTime
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

        /// public property name  :  EnterpriseCode
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

        /// public property name  :  FileHeaderGuid
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

        /// public property name  :  UpdEmployeeCode
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

        /// public property name  :  UpdAssemblyId1
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

        /// public property name  :  UpdAssemblyId2
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

        /// public property name  :  LogicalDeleteCode
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

        /// public property name  :  GoodsMakerCd
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

        /// public property name  :  GoodsMakerNm
        /// <summary>商品メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public property name  :  GoodsNo
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

        /// public property name  :  GoodsName
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

        /// public property name  :  GoodsNameKana
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

        /// public property name  :  Jan
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

        /// public property name  :  BLGoodsCode
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

        /// public property name  :  DisplayOrder
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

        /// public property name  :  GoodsRateRank
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

        /// public property name  :  TaxationDivCd
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

        /// public property name  :  GoodsNoNoneHyphen
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

        /// public property name  :  OfferDate
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

        /// public property name  :  GoodsKindCode
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

        /// public property name  :  GoodsNote1
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

        /// public property name  :  GoodsNote2
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

        /// public property name  :  GoodsSpecialNote
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

        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public property name  :  GoodsSpecialNoteOffer
        /// <summary>商品規格・特記事項プロパティ（提供）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項（提供）プロパティ</br>
        /// <br>Programer        :   手動生成</br>
        /// </remarks>
        public string GoodsSpecialNoteOffer
        {
            get { return _goodsSpecialNoteOffer; }
            set { _goodsSpecialNoteOffer = value; }
        }
        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// public property name  :  EnterpriseGanreCode
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

        /// public property name  :  UpdateDate
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

        /// public property name  :  GoodsMGroup
        /// <summary>中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public property name  :  CtlgPartsNo
        /// <summary>カタログ品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CtlgPartsNo
        {
            get { return _ctlgPartsNo; }
            set { _ctlgPartsNo = value; }
        }

        /// public property name  :  NewPartsNo
        /// <summary>最新品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最新品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPartsNo
        {
            get { return _newPartsNo; }
            set { _newPartsNo = value; }
        }

        /// public property name  :  JoinSrcPartsNo
        /// <summary>結合元品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSrcPartsNo
        {
            get { return _joinSrcPartsNo; }
            set { _joinSrcPartsNo = value; }
        }

        /// public property name  :  PartsQty
        /// <summary>QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public property name  :  PartsOpNm
        /// <summary>部品オプション名称(特記事項)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品オプション名称(特記事項)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsOpNm
        {
            get { return _partsOpNm; }
            set { _partsOpNm = value; }
        }

        /// public property name  :  CtlgPartsOpNm
        /// <summary>カタログ品番部品オプション名称(特記事項)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ品番部品オプション名称(特記事項)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>_ctlgPartsOpNm
        public string CtlgPartsOpNm
        {
            get { return _ctlgPartsOpNm; }
            set { _ctlgPartsOpNm = value; }
        }

        /// public property name  :  StandardName
        /// <summary>規格名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StandardName
        {
            get { return _standardName; }
            set { _standardName = value; }
        }

        /// public property name  :  GoodsPriceList
        /// <summary>価格リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<GoodsPrice> GoodsPriceList
        {
            get { return _goodsPriceList; }
            set { _goodsPriceList = value; }
        }

        /// public property name  :  StockList
        /// <summary>在庫リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Stock> StockList
        {
            get { return _stockList; }
            set { _stockList = value; }
        }


        /// public property name  :  PrimePartsList
        /// <summary>結合部品リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合部品リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<PrimePartsRet> PrimePartsList
        {
            get { return _primePartsList; }
            set { _primePartsList = value; }
        }

        /// <summary>
        /// 純正結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>GenuinePartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GenuinePartsRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GenuinePartsRet()
        {
        }

    }
}

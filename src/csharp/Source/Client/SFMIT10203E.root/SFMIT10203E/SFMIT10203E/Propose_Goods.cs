using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Propose_Goods
    /// <summary>
    ///                      提案商品クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   提案商品クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2016/6/2  中村仁</br>
    /// <br>                 :   在庫数</br>
    /// <br>                 :   BL商品コード</br>
    /// <br>                 :   BL商品コード枝番</br>
    /// <br>                 :   を追加</br>
    /// </remarks>
    public class Propose_Goods
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品カテゴリ</summary>
        /// <remarks>1:タイヤ,2:バッテリー,3:オイル,</remarks>
        private long _goodsCategory;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名（カナ）</summary>
        private string _goodsName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>発売日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _releaseDate;

        /// <summary>在庫状況区分</summary>
        /// <remarks>0:入荷待ち,1:在庫不足,2:在庫残少,3:在庫豊富,4:入荷待ち(委託),5:在庫不足(委託),6:在庫残少(委託),7:在庫豊富(委託),8:該当なし</remarks>
        private Int16 _stockStatusDiv;

        /// <summary>商品説明</summary>
        /// <remarks>改行コードは\nに置換</remarks>
        private string _goodsNote = "";

        /// <summary>商品PR</summary>
        /// <remarks>改行コードは\nに置換</remarks>
        private string _goodsPR = "";

        /// <summary>希望小売価格</summary>
        private Double _suggestPrice;

        /// <summary>店頭価格</summary>
        private Double _shopPrice;

        /// <summary>卸値</summary>
        private Double _tradePrice;

        /// <summary>仕入原価</summary>
        private Double _purchaseCost;

        /// <summary>PM更新日時</summary>
        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _pMUpdateTime;

        /// <summary>検索タグ1</summary>
        private string _searchTag1 = "";

        /// <summary>検索タグ2</summary>
        private string _searchTag2 = "";

        /// <summary>検索タグ3</summary>
        private string _searchTag3 = "";

        /// <summary>検索タグ4</summary>
        private string _searchTag4 = "";

        /// <summary>検索タグ5</summary>
        private string _searchTag5 = "";

        /// <summary>検索タグ6</summary>
        private string _searchTag6 = "";

        /// <summary>検索タグ7</summary>
        private string _searchTag7 = "";

        /// <summary>検索タグ8</summary>
        private string _searchTag8 = "";

        /// <summary>検索タグ9</summary>
        private string _searchTag9 = "";

        /// <summary>検索タグ10</summary>
        private string _searchTag10 = "";

        /// <summary>在庫数</summary>
        private Double _stockCnt;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード枝番</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>公開</summary>
        public int release;

        /// <summary>オススメ</summary>
        public int recommend;

        /// <summary>公開開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shopSaleBeginDate;

        /// <summary>公開終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shopSaleEndDate;


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

        /// public propaty name  :  GoodsCategory
        /// <summary>商品カテゴリプロパティ</summary>
        /// <value>1:タイヤ,2:バッテリー,3:オイル,</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品カテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public long GoodsCategory
        {
            get { return _goodsCategory; }
            set { _goodsCategory = value; }
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
        /// <summary>商品名（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
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

        /// public propaty name  :  ReleaseDate
        /// <summary>発売日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発売日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        /// public propaty name  :  StockStatusDiv
        /// <summary>在庫状況区分プロパティ</summary>
        /// <value>0:入荷待ち,1:在庫不足,2:在庫残少,3:在庫豊富,4:入荷待ち(委託),5:在庫不足(委託),6:在庫残少(委託),7:在庫豊富(委託),8:該当なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }

        /// public propaty name  :  GoodsNote
        /// <summary>商品説明プロパティ</summary>
        /// <value>改行コードは\nに置換</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品説明プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote
        {
            get { return _goodsNote; }
            set { _goodsNote = value; }
        }

        /// public propaty name  :  GoodsPR
        /// <summary>商品PRプロパティ</summary>
        /// <value>改行コードは\nに置換</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品PRプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsPR
        {
            get { return _goodsPR; }
            set { _goodsPR = value; }
        }

        /// public propaty name  :  SuggestPrice
        /// <summary>希望小売価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望小売価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SuggestPrice
        {
            get { return _suggestPrice; }
            set { _suggestPrice = value; }
        }

        /// public propaty name  :  ShopPrice
        /// <summary>店頭価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   店頭価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShopPrice
        {
            get { return _shopPrice; }
            set { _shopPrice = value; }
        }

        /// public propaty name  :  TradePrice
        /// <summary>卸値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TradePrice
        {
            get { return _tradePrice; }
            set { _tradePrice = value; }
        }

        /// public propaty name  :  PurchaseCost
        /// <summary>仕入原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PurchaseCost
        {
            get { return _purchaseCost; }
            set { _purchaseCost = value; }
        }

        /// public propaty name  :  PMUpdateTime
        /// <summary>PM更新日時プロパティ</summary>
        /// <value>（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PMUpdateTime
        {
            get { return _pMUpdateTime; }
            set { _pMUpdateTime = value; }
        }

        /// public propaty name  :  SearchTag1
        /// <summary>検索タグ1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag1
        {
            get { return _searchTag1; }
            set { _searchTag1 = value; }
        }

        /// public propaty name  :  SearchTag2
        /// <summary>検索タグ2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag2
        {
            get { return _searchTag2; }
            set { _searchTag2 = value; }
        }

        /// public propaty name  :  SearchTag3
        /// <summary>検索タグ3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag3
        {
            get { return _searchTag3; }
            set { _searchTag3 = value; }
        }

        /// public propaty name  :  SearchTag4
        /// <summary>検索タグ4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag4
        {
            get { return _searchTag4; }
            set { _searchTag4 = value; }
        }

        /// public propaty name  :  SearchTag5
        /// <summary>検索タグ5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag5
        {
            get { return _searchTag5; }
            set { _searchTag5 = value; }
        }

        /// public propaty name  :  SearchTag6
        /// <summary>検索タグ6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag6
        {
            get { return _searchTag6; }
            set { _searchTag6 = value; }
        }

        /// public propaty name  :  SearchTag7
        /// <summary>検索タグ7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag7
        {
            get { return _searchTag7; }
            set { _searchTag7 = value; }
        }

        /// public propaty name  :  SearchTag8
        /// <summary>検索タグ8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag8
        {
            get { return _searchTag8; }
            set { _searchTag8 = value; }
        }

        /// public propaty name  :  SearchTag9
        /// <summary>検索タグ9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag9
        {
            get { return _searchTag9; }
            set { _searchTag9 = value; }
        }

        /// public propaty name  :  SearchTag10
        /// <summary>検索タグ10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag10
        {
            get { return _searchTag10; }
            set { _searchTag10 = value; }
        }

        /// public propaty name  :  StockCnt
        /// <summary>在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockCnt
        {
            get { return _stockCnt; }
            set { _stockCnt = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
        }

        /// public propaty name  :  ShopSaleBeginDate
        /// <summary>B公開開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShopSaleBeginDate
        {
            get { return _shopSaleBeginDate; }
            set { _shopSaleBeginDate = value; }
        }

        /// public propaty name  :  ShopSaleEndDate
        /// <summary>公開終了日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShopSaleEndDate
        {
            get { return _shopSaleEndDate; }
            set { _shopSaleEndDate = value; }
        }

        /// <summary>
        /// 提案商品クラスコンストラクタ
        /// </summary>
        /// <returns>Propose_Goodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Goods()
        {
        }

        /// <summary>
        /// 提案商品クラスコンストラクタ
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsCategory">商品カテゴリ(1:タイヤ,2:バッテリー,3:オイル,)</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名（カナ）</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="releaseDate">発売日(YYYYMM)</param>
        /// <param name="stockStatusDiv">在庫状況区分(0:入荷待ち,1:在庫不足,2:在庫残少,3:在庫豊富,4:入荷待ち(委託),5:在庫不足(委託),6:在庫残少(委託),7:在庫豊富(委託),8:該当なし)</param>
        /// <param name="goodsNote">商品説明(改行コードは\nに置換)</param>
        /// <param name="goodsPR">商品PR(改行コードは\nに置換)</param>
        /// <param name="suggestPrice">希望小売価格</param>
        /// <param name="shopPrice">店頭価格</param>
        /// <param name="tradePrice">卸値</param>
        /// <param name="purchaseCost">仕入原価</param>
        /// <param name="pMUpdateTime">PM更新日時(（DateTime:精度は100ナノ秒）)</param>
        /// <param name="searchTag1">検索タグ1</param>
        /// <param name="searchTag2">検索タグ2</param>
        /// <param name="searchTag3">検索タグ3</param>
        /// <param name="searchTag4">検索タグ4</param>
        /// <param name="searchTag5">検索タグ5</param>
        /// <param name="searchTag6">検索タグ6</param>
        /// <param name="searchTag7">検索タグ7</param>
        /// <param name="searchTag8">検索タグ8</param>
        /// <param name="searchTag9">検索タグ9</param>
        /// <param name="searchTag10">検索タグ10</param>
        /// <param name="stockCnt">在庫数</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsDrCode">BL商品コード枝番</param>
        /// <param name="shopSaleBeginDate">公開開始日</param>
        /// <param name="shopSaleEndDate">公開終了日</param>
        /// 
        /// <returns>Propose_Goodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Goods(string sectionCode, long goodsCategory, string goodsNo, string goodsName, Int32 goodsMakerCd, string makerName, Int32 releaseDate, Int16 stockStatusDiv, string goodsNote, string goodsPR, Double suggestPrice, Double shopPrice, Double tradePrice, Double purchaseCost, Int64 pMUpdateTime, string searchTag1, string searchTag2, string searchTag3, string searchTag4, string searchTag5, string searchTag6, string searchTag7, string searchTag8, string searchTag9, string searchTag10, Double stockCnt, Int32 bLGoodsCode, Int32 bLGoodsDrCode, Int32 shopSaleBeginDate, Int32 shopSaleEndDate)
        {
            this._sectionCode = sectionCode;
            this._goodsCategory = goodsCategory;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._releaseDate = releaseDate;
            this._stockStatusDiv = stockStatusDiv;
            this._goodsNote = goodsNote;
            this._goodsPR = goodsPR;
            this._suggestPrice = suggestPrice;
            this._shopPrice = shopPrice;
            this._tradePrice = tradePrice;
            this._purchaseCost = purchaseCost;
            this._pMUpdateTime = pMUpdateTime;
            this._searchTag1 = searchTag1;
            this._searchTag2 = searchTag2;
            this._searchTag3 = searchTag3;
            this._searchTag4 = searchTag4;
            this._searchTag5 = searchTag5;
            this._searchTag6 = searchTag6;
            this._searchTag7 = searchTag7;
            this._searchTag8 = searchTag8;
            this._searchTag9 = searchTag9;
            this._searchTag10 = searchTag10;
            this._stockCnt = stockCnt;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsDrCode = bLGoodsDrCode;
            this._shopSaleBeginDate = shopSaleBeginDate;
            this._shopSaleEndDate = shopSaleEndDate;
        }

        /// <summary>
        /// 提案商品クラス複製処理
        /// </summary>
        /// <returns>Propose_Goodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPropose_Goodsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Goods Clone()
        {
            return new Propose_Goods(this._sectionCode, this._goodsCategory, this._goodsNo, this._goodsName, this._goodsMakerCd, this._makerName, this._releaseDate, this._stockStatusDiv, this._goodsNote, this._goodsPR, this._suggestPrice, this._shopPrice, this._tradePrice, this._purchaseCost, this._pMUpdateTime, this._searchTag1, this._searchTag2, this._searchTag3, this._searchTag4, this._searchTag5, this._searchTag6, this._searchTag7, this._searchTag8, this._searchTag9, this._searchTag10, this._stockCnt, this._bLGoodsCode, this._bLGoodsDrCode, this._shopSaleBeginDate, this._shopSaleEndDate);
        }

        /// <summary>
        /// 提案商品クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のPropose_Goodsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Propose_Goods target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.GoodsCategory == target.GoodsCategory)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.ReleaseDate == target.ReleaseDate)
                 && (this.StockStatusDiv == target.StockStatusDiv)
                 && (this.GoodsNote == target.GoodsNote)
                 && (this.GoodsPR == target.GoodsPR)
                 && (this.SuggestPrice == target.SuggestPrice)
                 && (this.ShopPrice == target.ShopPrice)
                 && (this.TradePrice == target.TradePrice)
                 && (this.PurchaseCost == target.PurchaseCost)
                 && (this.PMUpdateTime == target.PMUpdateTime)
                 && (this.SearchTag1 == target.SearchTag1)
                 && (this.SearchTag2 == target.SearchTag2)
                 && (this.SearchTag3 == target.SearchTag3)
                 && (this.SearchTag4 == target.SearchTag4)
                 && (this.SearchTag5 == target.SearchTag5)
                 && (this.SearchTag6 == target.SearchTag6)
                 && (this.SearchTag7 == target.SearchTag7)
                 && (this.SearchTag8 == target.SearchTag8)
                 && (this.SearchTag9 == target.SearchTag9)
                 && (this.SearchTag10 == target.SearchTag10)
                 && (this.StockCnt == target.StockCnt)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.ShopSaleBeginDate == target.ShopSaleBeginDate)
                 && (this.ShopSaleEndDate == target.ShopSaleEndDate)
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode));
        }

        /// <summary>
        /// 提案商品クラス比較処理
        /// </summary>
        /// <param name="propose_Goods1">
        ///                    比較するPropose_Goodsクラスのインスタンス
        /// </param>
        /// <param name="propose_Goods2">比較するPropose_Goodsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Propose_Goods propose_Goods1, Propose_Goods propose_Goods2)
        {
            return ((propose_Goods1.SectionCode == propose_Goods2.SectionCode)
                 && (propose_Goods1.GoodsCategory == propose_Goods2.GoodsCategory)
                 && (propose_Goods1.GoodsNo == propose_Goods2.GoodsNo)
                 && (propose_Goods1.GoodsName == propose_Goods2.GoodsName)
                 && (propose_Goods1.GoodsMakerCd == propose_Goods2.GoodsMakerCd)
                 && (propose_Goods1.MakerName == propose_Goods2.MakerName)
                 && (propose_Goods1.ReleaseDate == propose_Goods2.ReleaseDate)
                 && (propose_Goods1.StockStatusDiv == propose_Goods2.StockStatusDiv)
                 && (propose_Goods1.GoodsNote == propose_Goods2.GoodsNote)
                 && (propose_Goods1.GoodsPR == propose_Goods2.GoodsPR)
                 && (propose_Goods1.SuggestPrice == propose_Goods2.SuggestPrice)
                 && (propose_Goods1.ShopPrice == propose_Goods2.ShopPrice)
                 && (propose_Goods1.TradePrice == propose_Goods2.TradePrice)
                 && (propose_Goods1.PurchaseCost == propose_Goods2.PurchaseCost)
                 && (propose_Goods1.PMUpdateTime == propose_Goods2.PMUpdateTime)
                 && (propose_Goods1.SearchTag1 == propose_Goods2.SearchTag1)
                 && (propose_Goods1.SearchTag2 == propose_Goods2.SearchTag2)
                 && (propose_Goods1.SearchTag3 == propose_Goods2.SearchTag3)
                 && (propose_Goods1.SearchTag4 == propose_Goods2.SearchTag4)
                 && (propose_Goods1.SearchTag5 == propose_Goods2.SearchTag5)
                 && (propose_Goods1.SearchTag6 == propose_Goods2.SearchTag6)
                 && (propose_Goods1.SearchTag7 == propose_Goods2.SearchTag7)
                 && (propose_Goods1.SearchTag8 == propose_Goods2.SearchTag8)
                 && (propose_Goods1.SearchTag9 == propose_Goods2.SearchTag9)
                 && (propose_Goods1.SearchTag10 == propose_Goods2.SearchTag10)
                 && (propose_Goods1.StockCnt == propose_Goods2.StockCnt)
                 && (propose_Goods1.BLGoodsCode == propose_Goods2.BLGoodsCode)
                 && (propose_Goods1.ShopSaleBeginDate == propose_Goods2.ShopSaleBeginDate)
                 && (propose_Goods1.ShopSaleEndDate == propose_Goods2.ShopSaleEndDate)
                 && (propose_Goods1.BLGoodsDrCode == propose_Goods2.BLGoodsDrCode));
        }
        /// <summary>
        /// 提案商品クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のPropose_Goodsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Propose_Goods target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsCategory != target.GoodsCategory) resList.Add("GoodsCategory");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.ReleaseDate != target.ReleaseDate) resList.Add("ReleaseDate");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            if (this.GoodsNote != target.GoodsNote) resList.Add("GoodsNote");
            if (this.GoodsPR != target.GoodsPR) resList.Add("GoodsPR");
            if (this.SuggestPrice != target.SuggestPrice) resList.Add("SuggestPrice");
            if (this.ShopPrice != target.ShopPrice) resList.Add("ShopPrice");
            if (this.TradePrice != target.TradePrice) resList.Add("TradePrice");
            if (this.PurchaseCost != target.PurchaseCost) resList.Add("PurchaseCost");
            if (this.PMUpdateTime != target.PMUpdateTime) resList.Add("PMUpdateTime");
            if (this.SearchTag1 != target.SearchTag1) resList.Add("SearchTag1");
            if (this.SearchTag2 != target.SearchTag2) resList.Add("SearchTag2");
            if (this.SearchTag3 != target.SearchTag3) resList.Add("SearchTag3");
            if (this.SearchTag4 != target.SearchTag4) resList.Add("SearchTag4");
            if (this.SearchTag5 != target.SearchTag5) resList.Add("SearchTag5");
            if (this.SearchTag6 != target.SearchTag6) resList.Add("SearchTag6");
            if (this.SearchTag7 != target.SearchTag7) resList.Add("SearchTag7");
            if (this.SearchTag8 != target.SearchTag8) resList.Add("SearchTag8");
            if (this.SearchTag9 != target.SearchTag9) resList.Add("SearchTag9");
            if (this.SearchTag10 != target.SearchTag10) resList.Add("SearchTag10");
            if (this.StockCnt != target.StockCnt) resList.Add("StockCnt");
            if (this.ShopSaleBeginDate != target.ShopSaleBeginDate) resList.Add("ShopSaleBeginDate");
            if (this.ShopSaleEndDate != target.ShopSaleEndDate) resList.Add("ShopSaleEndDate");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");

            return resList;
        }

        /// <summary>
        /// 提案商品クラス比較処理
        /// </summary>
        /// <param name="propose_Goods1">比較するPropose_Goodsクラスのインスタンス</param>
        /// <param name="propose_Goods2">比較するPropose_Goodsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Goodsクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Propose_Goods propose_Goods1, Propose_Goods propose_Goods2)
        {
            ArrayList resList = new ArrayList();
            if (propose_Goods1.SectionCode != propose_Goods2.SectionCode) resList.Add("SectionCode");
            if (propose_Goods1.GoodsCategory != propose_Goods2.GoodsCategory) resList.Add("GoodsCategory");
            if (propose_Goods1.GoodsNo != propose_Goods2.GoodsNo) resList.Add("GoodsNo");
            if (propose_Goods1.GoodsName != propose_Goods2.GoodsName) resList.Add("GoodsName");
            if (propose_Goods1.GoodsMakerCd != propose_Goods2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (propose_Goods1.MakerName != propose_Goods2.MakerName) resList.Add("MakerName");
            if (propose_Goods1.ReleaseDate != propose_Goods2.ReleaseDate) resList.Add("ReleaseDate");
            if (propose_Goods1.StockStatusDiv != propose_Goods2.StockStatusDiv) resList.Add("StockStatusDiv");
            if (propose_Goods1.GoodsNote != propose_Goods2.GoodsNote) resList.Add("GoodsNote");
            if (propose_Goods1.GoodsPR != propose_Goods2.GoodsPR) resList.Add("GoodsPR");
            if (propose_Goods1.SuggestPrice != propose_Goods2.SuggestPrice) resList.Add("SuggestPrice");
            if (propose_Goods1.ShopPrice != propose_Goods2.ShopPrice) resList.Add("ShopPrice");
            if (propose_Goods1.TradePrice != propose_Goods2.TradePrice) resList.Add("TradePrice");
            if (propose_Goods1.PurchaseCost != propose_Goods2.PurchaseCost) resList.Add("PurchaseCost");
            if (propose_Goods1.PMUpdateTime != propose_Goods2.PMUpdateTime) resList.Add("PMUpdateTime");
            if (propose_Goods1.SearchTag1 != propose_Goods2.SearchTag1) resList.Add("SearchTag1");
            if (propose_Goods1.SearchTag2 != propose_Goods2.SearchTag2) resList.Add("SearchTag2");
            if (propose_Goods1.SearchTag3 != propose_Goods2.SearchTag3) resList.Add("SearchTag3");
            if (propose_Goods1.SearchTag4 != propose_Goods2.SearchTag4) resList.Add("SearchTag4");
            if (propose_Goods1.SearchTag5 != propose_Goods2.SearchTag5) resList.Add("SearchTag5");
            if (propose_Goods1.SearchTag6 != propose_Goods2.SearchTag6) resList.Add("SearchTag6");
            if (propose_Goods1.SearchTag7 != propose_Goods2.SearchTag7) resList.Add("SearchTag7");
            if (propose_Goods1.SearchTag8 != propose_Goods2.SearchTag8) resList.Add("SearchTag8");
            if (propose_Goods1.SearchTag9 != propose_Goods2.SearchTag9) resList.Add("SearchTag9");
            if (propose_Goods1.SearchTag10 != propose_Goods2.SearchTag10) resList.Add("SearchTag10");
            if (propose_Goods1.StockCnt != propose_Goods2.StockCnt) resList.Add("StockCnt");
            if (propose_Goods1.ShopSaleBeginDate != propose_Goods2.ShopSaleBeginDate) resList.Add("ShopSaleBeginDate");
            if (propose_Goods1.ShopSaleEndDate != propose_Goods2.ShopSaleEndDate) resList.Add("ShopSaleEndDate");
            if (propose_Goods1.BLGoodsCode != propose_Goods2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (propose_Goods1.BLGoodsDrCode != propose_Goods2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");

            return resList;
        }
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品（テキスト変換結果）
// プログラム概要   : 商品（テキスト変換結果）ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : 高陽
// 作 成 日  K2013/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsTextExpRetWork
    /// <summary>
    ///                      商品（テキスト変換結果）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品（テキスト変換結果）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/8/9</br>
    /// <br>Genarated Date   :   2013/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsTextExpRetWork
    {
        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

        /// <summary>BLグループコードカナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>定価</summary>
        private Double _listPrice;

        /// <summary>仕入率</summary>
        private Double _stockRate;

        /// <summary>原価単価</summary>
        /// <remarks>仕入単価 ＝ 売上原価で統一</remarks>
        private Double _salesUnitCost;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>適用の価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _setPriceStartDate;


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
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
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

        /// public propaty name  :  BLGroupCode
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

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>仕入率プロパティ</summary>
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

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>仕入単価 ＝ 売上原価で統一</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
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

        /// public propaty name  :  SetPriceStartDate
        /// <summary>適用の価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用の価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPriceStartDate
        {
            get { return _setPriceStartDate; }
            set { _setPriceStartDate = value; }
        }


        /// <summary>
        /// 商品（テキスト変換結果）ワークコンストラクタ
        /// </summary>
        /// <returns>GoodsTextExpRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpRetWork()
        {
        }

        /// <summary>
        /// 商品（テキスト変換結果）ワークコンストラクタ
        /// </summary>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="bLGroupName">BLグループコード名称</param>
        /// <param name="bLGroupKanaName">BLグループコードカナ名称(半角カナ)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="listPrice">定価</param>
        /// <param name="stockRate">仕入率</param>
        /// <param name="salesUnitCost">原価単価(仕入単価 ＝ 売上原価で統一)</param>
        /// <param name="goodsMGroup">商品中分類コード(※中分類)</param>
        /// <param name="priceStartDate">価格開始日(YYYYMMDD)</param>
        /// <param name="setPriceStartDate">適用の価格開始日(YYYYMMDD)</param>
        /// <returns>GoodsTextExpRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpRetWork(string goodsNo, Int32 goodsMakerCd, Int32 bLGoodsCode, string bLGoodsFullName, string bLGoodsHalfName, Int32 bLGroupCode, string bLGroupName, string bLGroupKanaName, Int32 supplierCd, string goodsName, Double listPrice, Double stockRate, Double salesUnitCost, Int32 goodsMGroup, Int32 priceStartDate, Int32 setPriceStartDate)
        {
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGroupKanaName = bLGroupKanaName;
            this._supplierCd = supplierCd;
            this._goodsName = goodsName;
            this._listPrice = listPrice;
            this._stockRate = stockRate;
            this._salesUnitCost = salesUnitCost;
            this._goodsMGroup = goodsMGroup;
            this._priceStartDate = priceStartDate;
            this._setPriceStartDate = setPriceStartDate;

        }

        /// <summary>
        /// 商品（テキスト変換結果）ワーク複製処理
        /// </summary>
        /// <returns>GoodsTextExpRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsTextExpRetWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpRetWork Clone()
        {
            return new GoodsTextExpRetWork(this._goodsNo, this._goodsMakerCd, this._bLGoodsCode, this._bLGoodsFullName, this._bLGoodsHalfName, this._bLGroupCode, this._bLGroupName, this._bLGroupKanaName, this._supplierCd, this._goodsName, this._listPrice, this._stockRate, this._salesUnitCost, this._goodsMGroup, this._priceStartDate, this._setPriceStartDate);
        }

        /// <summary>
        /// 商品（テキスト変換結果）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsTextExpRetWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsTextExpRetWork target)
        {
            return ((this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGroupKanaName == target.BLGroupKanaName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.GoodsName == target.GoodsName)
                 && (this.ListPrice == target.ListPrice)
                 && (this.StockRate == target.StockRate)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.SetPriceStartDate == target.SetPriceStartDate));
        }

        /// <summary>
        /// 商品（テキスト変換結果）ワーク比較処理
        /// </summary>
        /// <param name="goodsTextExpRet1">
        ///                    比較するGoodsTextExpRetWorkクラスのインスタンス
        /// </param>
        /// <param name="goodsTextExpRet2">比較するGoodsTextExpRetWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsTextExpRetWork goodsTextExpRet1, GoodsTextExpRetWork goodsTextExpRet2)
        {
            return ((goodsTextExpRet1.GoodsNo == goodsTextExpRet2.GoodsNo)
                 && (goodsTextExpRet1.GoodsMakerCd == goodsTextExpRet2.GoodsMakerCd)
                 && (goodsTextExpRet1.BLGoodsCode == goodsTextExpRet2.BLGoodsCode)
                 && (goodsTextExpRet1.BLGoodsFullName == goodsTextExpRet2.BLGoodsFullName)
                 && (goodsTextExpRet1.BLGoodsHalfName == goodsTextExpRet2.BLGoodsHalfName)
                 && (goodsTextExpRet1.BLGroupCode == goodsTextExpRet2.BLGroupCode)
                 && (goodsTextExpRet1.BLGroupName == goodsTextExpRet2.BLGroupName)
                 && (goodsTextExpRet1.BLGroupKanaName == goodsTextExpRet2.BLGroupKanaName)
                 && (goodsTextExpRet1.SupplierCd == goodsTextExpRet2.SupplierCd)
                 && (goodsTextExpRet1.GoodsName == goodsTextExpRet2.GoodsName)
                 && (goodsTextExpRet1.ListPrice == goodsTextExpRet2.ListPrice)
                 && (goodsTextExpRet1.StockRate == goodsTextExpRet2.StockRate)
                 && (goodsTextExpRet1.SalesUnitCost == goodsTextExpRet2.SalesUnitCost)
                 && (goodsTextExpRet1.GoodsMGroup == goodsTextExpRet2.GoodsMGroup)
                 && (goodsTextExpRet1.PriceStartDate == goodsTextExpRet2.PriceStartDate)
                 && (goodsTextExpRet1.SetPriceStartDate == goodsTextExpRet2.SetPriceStartDate));
        }
        /// <summary>
        /// 商品（テキスト変換結果）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsTextExpRetWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsTextExpRetWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGroupKanaName != target.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.StockRate != target.StockRate) resList.Add("StockRate");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SetPriceStartDate != target.SetPriceStartDate) resList.Add("SetPriceStartDate");

            return resList;
        }

        /// <summary>
        /// 商品（テキスト変換結果）ワーク比較処理
        /// </summary>
        /// <param name="goodsTextExpRet1">比較するGoodsTextExpRetWorkクラスのインスタンス</param>
        /// <param name="goodsTextExpRet2">比較するGoodsTextExpRetWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsTextExpRetWork goodsTextExpRet1, GoodsTextExpRetWork goodsTextExpRet2)
        {
            ArrayList resList = new ArrayList();
            if (goodsTextExpRet1.GoodsNo != goodsTextExpRet2.GoodsNo) resList.Add("GoodsNo");
            if (goodsTextExpRet1.GoodsMakerCd != goodsTextExpRet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsTextExpRet1.BLGoodsCode != goodsTextExpRet2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsTextExpRet1.BLGoodsFullName != goodsTextExpRet2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (goodsTextExpRet1.BLGoodsHalfName != goodsTextExpRet2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (goodsTextExpRet1.BLGroupCode != goodsTextExpRet2.BLGroupCode) resList.Add("BLGroupCode");
            if (goodsTextExpRet1.BLGroupName != goodsTextExpRet2.BLGroupName) resList.Add("BLGroupName");
            if (goodsTextExpRet1.BLGroupKanaName != goodsTextExpRet2.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (goodsTextExpRet1.SupplierCd != goodsTextExpRet2.SupplierCd) resList.Add("SupplierCd");
            if (goodsTextExpRet1.GoodsName != goodsTextExpRet2.GoodsName) resList.Add("GoodsName");
            if (goodsTextExpRet1.ListPrice != goodsTextExpRet2.ListPrice) resList.Add("ListPrice");
            if (goodsTextExpRet1.StockRate != goodsTextExpRet2.StockRate) resList.Add("StockRate");
            if (goodsTextExpRet1.SalesUnitCost != goodsTextExpRet2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (goodsTextExpRet1.GoodsMGroup != goodsTextExpRet2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsTextExpRet1.PriceStartDate != goodsTextExpRet2.PriceStartDate) resList.Add("PriceStartDate");
            if (goodsTextExpRet1.SetPriceStartDate != goodsTextExpRet2.SetPriceStartDate) resList.Add("SetPriceStartDate");

            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsTextExpRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsTextExpRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsTextExpRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsTextExpRetWork || graph is ArrayList || graph is GoodsTextExpRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsTextExpRetWork).FullName));

            if (graph != null && graph is GoodsTextExpRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsTextExpRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsTextExpRetWork[])graph).Length;
            }
            else if (graph is GoodsTextExpRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコード名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BLグループコードカナ名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //定価
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //仕入率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //適用の価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPriceStartDate


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsTextExpRetWork)
            {
                GoodsTextExpRetWork temp = (GoodsTextExpRetWork)graph;

                SetGoodsTextExpRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsTextExpRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsTextExpRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsTextExpRetWork temp in lst)
                {
                    SetGoodsTextExpRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsTextExpRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  GoodsTextExpRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsTextExpRetWork(System.IO.BinaryWriter writer, GoodsTextExpRetWork temp)
        {
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコード名称
            writer.Write(temp.BLGroupName);
            //BLグループコードカナ名称
            writer.Write(temp.BLGroupKanaName);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //商品名称
            writer.Write(temp.GoodsName);
            //定価
            writer.Write(temp.ListPrice);
            //仕入率
            writer.Write(temp.StockRate);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //適用の価格開始日
            writer.Write(temp.SetPriceStartDate);

        }

        /// <summary>
        ///  GoodsTextExpRetWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsTextExpRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsTextExpRetWork GetGoodsTextExpRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsTextExpRetWork temp = new GoodsTextExpRetWork();

            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコード名称
            temp.BLGroupName = reader.ReadString();
            //BLグループコードカナ名称
            temp.BLGroupKanaName = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //定価
            temp.ListPrice = reader.ReadDouble();
            //仕入率
            temp.StockRate = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //適用の価格開始日
            temp.SetPriceStartDate = reader.ReadInt32();


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
        /// <returns>GoodsTextExpRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsTextExpRetWork temp = GetGoodsTextExpRetWork(reader, serInfo);
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
                    retValue = (GoodsTextExpRetWork[])lst.ToArray(typeof(GoodsTextExpRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


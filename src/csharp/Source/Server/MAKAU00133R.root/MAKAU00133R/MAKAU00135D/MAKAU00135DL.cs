using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryWork2
    /// <summary>
    ///                      在庫履歴データワーク2
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫履歴データワークヘッダファイル</br>
    /// <br>Date             :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockHistoryWork2 : System.IComparable
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>仕入単価（税抜，浮動）</summary>
        /// <remarks>棚卸評価単価</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>在庫総数</summary>
        /// <remarks>入荷、出荷を含む在庫数（入出荷日ベース）</remarks>
        private Double _stockTotal;

        /// <summary>マシン在庫額</summary>
        /// <remarks>入荷、出荷を含む在庫金額</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>自社在庫数</summary>
        /// <remarks>自社の資産の在庫数（計上日ベース）</remarks>
        private Double _propertyStockCnt;

        /// <summary>自社在庫金額</summary>
        /// <remarks>自社の資産の在庫金額</remarks>
        private Int64 _propertyStockPrice;

        /// <summary>マッチング状態</summary>
        /// <remarks>0:unmatched、1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜，浮動）プロパティ</summary>
        /// <value>棚卸評価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>在庫総数プロパティ</summary>
        /// <value>入荷、出荷を含む在庫数（入出荷日ベース）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫総数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>マシン在庫額プロパティ</summary>
        /// <value>入荷、出荷を含む在庫金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マシン在庫額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockMashinePrice
        {
            get { return _stockMashinePrice; }
            set { _stockMashinePrice = value; }
        }

        /// public propaty name  :  PropertyStockCnt
        /// <summary>自社在庫数プロパティ</summary>
        /// <value>自社の資産の在庫数（計上日ベース）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PropertyStockCnt
        {
            get { return _propertyStockCnt; }
            set { _propertyStockCnt = value; }
        }

        /// public propaty name  :  PropertyStockPrice
        /// <summary>自社在庫金額プロパティ</summary>
        /// <value>自社の資産の在庫金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社在庫金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PropertyStockPrice
        {
            get { return _propertyStockPrice; }
            set { _propertyStockPrice = value; }
        }

        /// public propaty name  :  MatchingStatus
        /// <summary>マッチング状態プロパティ</summary>
        /// <value>0:unmatched、1:matched</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マッチング状態プロパティ</br>
        /// </remarks>
        public Int32 MatchingStatus
        {
            get { return _matchingStatus; }
            set { _matchingStatus = value; }
        }

        /// <summary>
        /// 在庫履歴データワーク2コンストラクタ
        /// </summary>
        /// <returns>StockHistoryWork2クラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryWork2クラスの新しいインスタンスを生成します</br>
        /// </remarks>
        public StockHistoryWork2()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>
        /// System.IComparableのCompareToメソッドの実装
        /// </remarks>
        public int CompareTo(object obj)
        {
            // this > object	:	正の値を返す。
            // this == object	:	0を返す。
            // this < object	:	負の値を返す
            int result;
            if ((result = this.WarehouseCode.CompareTo(((StockHistoryWork2)obj).WarehouseCode)) != 0) return result;
            if ((result = this.SectionCode.CompareTo(((StockHistoryWork2)obj).SectionCode)) != 0) return result;
            if ((result = this.GoodsNo.CompareTo(((StockHistoryWork2)obj).GoodsNo)) != 0) return result;
            return this.GoodsMakerCd - ((StockHistoryWork2)obj).GoodsMakerCd;
        }
    }
}


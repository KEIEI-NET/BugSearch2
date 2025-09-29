using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ParentGoods
    /// <summary>
    ///                      在庫組立・分解処理親商品情報クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫組立・分解処理親商品情報クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/12/15 金沢 貞義</br>
    /// <br>                       親在庫情報追加</br>
    /// <br>Update Note      :   2009/01/28 金沢 貞義</br>
    /// <br>                       価格マスタ情報追加（定価、原価単価、オープン価格区分）</br>
    /// </remarks>
    public class ParentGoods
    {
        /// <summary>親商品番号</summary>
        private string _parentGoodsNo = "";

        /// <summary>親商品名称</summary>
        private string _parentGoodsName = "";

        /// <summary>親商品名称カナ</summary>
        private string _parentGoodsNameKana = "";

        /// <summary>親商品メーカーコード</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>親メーカー名称</summary>
        private string _parentMakerName = "";

        /// <summary>親メーカー略称</summary>
        private string _parentMakerShortName = "";

        /// <summary>親倉庫コード</summary>
        /// <remarks>拠点毎の倉庫優先順位1</remarks>
        private string _parentWarehouseCode = "";

        /// <summary>親倉庫名称</summary>
        private string _parentWarehouseName = "";

        /// <summary>親現在在庫数</summary>
        /// <remarks>仕入在庫数</remarks>
        private Double _parentSupplierStock;

        /// <summary>親最高在庫数</summary>
        private Double _parentMaximumStockCnt;

        /// <summary>親最低在庫数</summary>
        private Double _parentMinimumStockCnt;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _shipmentPosCnt;

        /// <summary>定価（浮動）</summary>
        private Double _listPrice;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>親在庫情報</summary>
        private List<Stock> _parentStockList;


        /// public propaty name  :  ParentGoodsNo
        /// <summary>親商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  ParentGoodsName
        /// <summary>親商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsName
        {
            get { return _parentGoodsName; }
            set { _parentGoodsName = value; }
        }

        /// public propaty name  :  ParentGoodsNameKana
        /// <summary>親商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNameKana
        {
            get { return _parentGoodsNameKana; }
            set { _parentGoodsNameKana = value; }
        }

        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>親商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentMakerName
        /// <summary>親メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentMakerName
        {
            get { return _parentMakerName; }
            set { _parentMakerName = value; }
        }

        /// public propaty name  :  ParentMakerShortName
        /// <summary>親メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentMakerShortName
        {
            get { return _parentMakerShortName; }
            set { _parentMakerShortName = value; }
        }

        /// public propaty name  :  ParentWarehouseCode
        /// <summary>親倉庫コードプロパティ</summary>
        /// <value>拠点毎の倉庫優先順位1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentWarehouseCode
        {
            get { return _parentWarehouseCode; }
            set { _parentWarehouseCode = value; }
        }

        /// public propaty name  :  ParentWarehouseName
        /// <summary>親倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentWarehouseName
        {
            get { return _parentWarehouseName; }
            set { _parentWarehouseName = value; }
        }

        /// public propaty name  :  ParentSupplierStock
        /// <summary>親現在在庫数プロパティ</summary>
        /// <value>仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親現在在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentSupplierStock
        {
            get { return _parentSupplierStock; }
            set { _parentSupplierStock = value; }
        }

        /// public propaty name  :  ParentMaximumStockCnt
        /// <summary>親最高在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentMaximumStockCnt
        {
            get { return _parentMaximumStockCnt; }
            set { _parentMaximumStockCnt = value; }
        }

        /// public propaty name  :  ParentMinimumStockCnt
        /// <summary>親最低在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親最低在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentMinimumStockCnt
        {
            get { return _parentMinimumStockCnt; }
            set { _parentMinimumStockCnt = value; }
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

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
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

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  ParentStockList
        /// <summary>親在庫情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親在庫情報プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public List<Stock> ParentStockList
        {
            get { return _parentStockList; }
            set { _parentStockList = value; }
        }


        /// <summary>
        /// 在庫組立・分解処理親商品情報クラスコンストラクタ
        /// </summary>
        /// <returns>ParentGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ParentGoods()
        {
        }

        /// <summary>
        /// 在庫組立・分解処理親商品情報クラスコンストラクタ
        /// </summary>
        /// <param name="parentGoodsNo">親商品番号</param>
        /// <param name="parentGoodsName">親商品名称</param>
        /// <param name="parentGoodsNameKana">親商品名称カナ</param>
        /// <param name="parentGoodsMakerCd">親商品メーカーコード</param>
        /// <param name="parentMakerName">親メーカー名称</param>
        /// <param name="parentMakerShortName">親メーカー略称</param>
        /// <param name="parentWarehouseCode">親倉庫コード(拠点毎の倉庫優先順位1)</param>
        /// <param name="parentWarehouseName">親倉庫名称</param>
        /// <param name="parentSupplierStock">親現在在庫数(仕入在庫数)</param>
        /// <param name="parentMaximumStockCnt">親最高在庫数</param>
        /// <param name="parentMinimumStockCnt">親最低在庫数</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
        /// <param name="listPrice">定価（浮動）</param>
        /// <param name="salesUnitCost">原価単価</param>
        /// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
        /// <returns>ParentGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ParentGoods(string parentGoodsNo, string parentGoodsName, string parentGoodsNameKana, Int32 parentGoodsMakerCd, string parentMakerName, string parentMakerShortName, string parentWarehouseCode, string parentWarehouseName, Double parentSupplierStock, Double parentMaximumStockCnt, Double parentMinimumStockCnt, Int32 bLGoodsCode, string bLGoodsFullName, Double shipmentPosCnt, Double listPrice, Double salesUnitCost, Int32 openPriceDiv)
        {
            this._parentGoodsNo = parentGoodsNo;
            this._parentGoodsName = parentGoodsName;
            this._parentGoodsNameKana = parentGoodsNameKana;
            this._parentGoodsMakerCd = parentGoodsMakerCd;
            this._parentMakerName = parentMakerName;
            this._parentMakerShortName = parentMakerShortName;
            this._parentWarehouseCode = parentWarehouseCode;
            this._parentWarehouseName = parentWarehouseName;
            this._parentSupplierStock = parentSupplierStock;
            this._parentMaximumStockCnt = parentMaximumStockCnt;
            this._parentMinimumStockCnt = parentMinimumStockCnt;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._shipmentPosCnt = shipmentPosCnt;
            this._listPrice = listPrice;
            this._salesUnitCost = salesUnitCost;
            this._openPriceDiv = openPriceDiv;

        }

        /// <summary>
        /// 在庫組立・分解処理親商品情報クラス複製処理
        /// </summary>
        /// <returns>ParentGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいParentGoodsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ParentGoods Clone()
        {
            return new ParentGoods(this._parentGoodsNo, this._parentGoodsName, this._parentGoodsNameKana, this._parentGoodsMakerCd, this._parentMakerName, this._parentMakerShortName, this._parentWarehouseCode, this._parentWarehouseName, this._parentSupplierStock, this._parentMaximumStockCnt, this._parentMinimumStockCnt, this._bLGoodsCode, this._bLGoodsFullName, this._shipmentPosCnt, this._listPrice, this._salesUnitCost, this._openPriceDiv);
        }

        /// <summary>
        /// 在庫組立・分解処理親商品情報クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のParentGoodsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ParentGoods target)
        {
            return ((this.ParentGoodsNo == target.ParentGoodsNo)
                 && (this.ParentGoodsName == target.ParentGoodsName)
                 && (this.ParentGoodsNameKana == target.ParentGoodsNameKana)
                 && (this.ParentGoodsMakerCd == target.ParentGoodsMakerCd)
                 && (this.ParentMakerName == target.ParentMakerName)
                 && (this.ParentMakerShortName == target.ParentMakerShortName)
                 && (this.ParentWarehouseCode == target.ParentWarehouseCode)
                 && (this.ParentWarehouseName == target.ParentWarehouseName)
                 && (this.ParentSupplierStock == target.ParentSupplierStock)
                 && (this.ParentMaximumStockCnt == target.ParentMaximumStockCnt)
                 && (this.ParentMinimumStockCnt == target.ParentMinimumStockCnt)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.ListPrice == target.ListPrice)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.OpenPriceDiv == target.OpenPriceDiv));
        }

        /// <summary>
        /// 在庫組立・分解処理親商品情報クラス比較処理
        /// </summary>
        /// <param name="parentGoods1">
        ///                    比較するParentGoodsクラスのインスタンス
        /// </param>
        /// <param name="parentGoods2">比較するParentGoodsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ParentGoods parentGoods1, ParentGoods parentGoods2)
        {
            return ((parentGoods1.ParentGoodsNo == parentGoods2.ParentGoodsNo)
                 && (parentGoods1.ParentGoodsName == parentGoods2.ParentGoodsName)
                 && (parentGoods1.ParentGoodsNameKana == parentGoods2.ParentGoodsNameKana)
                 && (parentGoods1.ParentGoodsMakerCd == parentGoods2.ParentGoodsMakerCd)
                 && (parentGoods1.ParentMakerName == parentGoods2.ParentMakerName)
                 && (parentGoods1.ParentMakerShortName == parentGoods2.ParentMakerShortName)
                 && (parentGoods1.ParentWarehouseCode == parentGoods2.ParentWarehouseCode)
                 && (parentGoods1.ParentWarehouseName == parentGoods2.ParentWarehouseName)
                 && (parentGoods1.ParentSupplierStock == parentGoods2.ParentSupplierStock)
                 && (parentGoods1.ParentMaximumStockCnt == parentGoods2.ParentMaximumStockCnt)
                 && (parentGoods1.ParentMinimumStockCnt == parentGoods2.ParentMinimumStockCnt)
                 && (parentGoods1.BLGoodsCode == parentGoods2.BLGoodsCode)
                 && (parentGoods1.BLGoodsFullName == parentGoods2.BLGoodsFullName)
                 && (parentGoods1.ShipmentPosCnt == parentGoods2.ShipmentPosCnt)
				 && (parentGoods1.ListPrice == parentGoods2.ListPrice)
				 && (parentGoods1.SalesUnitCost == parentGoods2.SalesUnitCost)
				 && (parentGoods1.OpenPriceDiv == parentGoods2.OpenPriceDiv));
        }
        /// <summary>
        /// 在庫組立・分解処理親商品情報クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のParentGoodsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ParentGoods target)
        {
            ArrayList resList = new ArrayList();
            if (this.ParentGoodsNo != target.ParentGoodsNo) resList.Add("ParentGoodsNo");
            if (this.ParentGoodsName != target.ParentGoodsName) resList.Add("ParentGoodsName");
            if (this.ParentGoodsNameKana != target.ParentGoodsNameKana) resList.Add("ParentGoodsNameKana");
            if (this.ParentGoodsMakerCd != target.ParentGoodsMakerCd) resList.Add("ParentGoodsMakerCd");
            if (this.ParentMakerName != target.ParentMakerName) resList.Add("ParentMakerName");
            if (this.ParentMakerShortName != target.ParentMakerShortName) resList.Add("ParentMakerShortName");
            if (this.ParentWarehouseCode != target.ParentWarehouseCode) resList.Add("ParentWarehouseCode");
            if (this.ParentWarehouseName != target.ParentWarehouseName) resList.Add("ParentWarehouseName");
            if (this.ParentSupplierStock != target.ParentSupplierStock) resList.Add("ParentSupplierStock");
            if (this.ParentMaximumStockCnt != target.ParentMaximumStockCnt) resList.Add("ParentMaximumStockCnt");
            if (this.ParentMinimumStockCnt != target.ParentMinimumStockCnt) resList.Add("ParentMinimumStockCnt");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.ShipmentPosCnt != target.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");

            return resList;
        }

        /// <summary>
        /// 在庫組立・分解処理親商品情報クラス比較処理
        /// </summary>
        /// <param name="parentGoods1">比較するParentGoodsクラスのインスタンス</param>
        /// <param name="parentGoods2">比較するParentGoodsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ParentGoodsクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ParentGoods parentGoods1, ParentGoods parentGoods2)
        {
            ArrayList resList = new ArrayList();
            if (parentGoods1.ParentGoodsNo != parentGoods2.ParentGoodsNo) resList.Add("ParentGoodsNo");
            if (parentGoods1.ParentGoodsName != parentGoods2.ParentGoodsName) resList.Add("ParentGoodsName");
            if (parentGoods1.ParentGoodsNameKana != parentGoods2.ParentGoodsNameKana) resList.Add("ParentGoodsNameKana");
            if (parentGoods1.ParentGoodsMakerCd != parentGoods2.ParentGoodsMakerCd) resList.Add("ParentGoodsMakerCd");
            if (parentGoods1.ParentMakerName != parentGoods2.ParentMakerName) resList.Add("ParentMakerName");
            if (parentGoods1.ParentMakerShortName != parentGoods2.ParentMakerShortName) resList.Add("ParentMakerShortName");
            if (parentGoods1.ParentWarehouseCode != parentGoods2.ParentWarehouseCode) resList.Add("ParentWarehouseCode");
            if (parentGoods1.ParentWarehouseName != parentGoods2.ParentWarehouseName) resList.Add("ParentWarehouseName");
            if (parentGoods1.ParentSupplierStock != parentGoods2.ParentSupplierStock) resList.Add("ParentSupplierStock");
            if (parentGoods1.ParentMaximumStockCnt != parentGoods2.ParentMaximumStockCnt) resList.Add("ParentMaximumStockCnt");
            if (parentGoods1.ParentMinimumStockCnt != parentGoods2.ParentMinimumStockCnt) resList.Add("ParentMinimumStockCnt");
            if (parentGoods1.BLGoodsCode != parentGoods2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (parentGoods1.BLGoodsFullName != parentGoods2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (parentGoods1.ShipmentPosCnt != parentGoods2.ShipmentPosCnt) resList.Add("ShipmentPosCnt");
            if (parentGoods1.ListPrice != parentGoods2.ListPrice) resList.Add("ListPrice");
            if (parentGoods1.SalesUnitCost != parentGoods2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (parentGoods1.OpenPriceDiv != parentGoods2.OpenPriceDiv) resList.Add("OpenPriceDiv");

            return resList;
        }
    }
}

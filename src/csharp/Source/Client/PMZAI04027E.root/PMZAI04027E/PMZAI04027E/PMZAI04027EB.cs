using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SubGoodsSet
	/// <summary>
	///                      在庫組立・分解処理子商品情報クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫組立・分解処理子商品情報クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/12/15 金沢 貞義</br>
    /// <br>                       子在庫情報追加</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SubGoodsSet
	{
		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>子商品番号</summary>
		private string _subGoodsNo = "";

		/// <summary>子商品名称</summary>
		private string _subGoodsName = "";

		/// <summary>子商品名称カナ</summary>
		private string _subGoodsNameKana = "";

		/// <summary>子商品メーカーコード</summary>
		private Int32 _subGoodsMakerCd;

		/// <summary>子メーカー名称</summary>
		private string _subMakerName = "";

		/// <summary>子倉庫コード</summary>
		/// <remarks>拠点毎の倉庫優先順位1</remarks>
		private string _subWarehouseCd = "";

		/// <summary>子倉庫名称</summary>
		private string _subWarehouseName = "";

		/// <summary>子現在在庫数</summary>
		/// <remarks>仕入在庫数</remarks>
		private Double _subSupplierStock;

		/// <summary>QTY</summary>
		/// <remarks>数量（浮動）</remarks>
		private Double _cntFl;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>出荷可能数</summary>
		/// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
		private Double _shipmentPosCnt;

		/// <summary>提供区分</summary>
		private string _division = "";

        /// <summary>定価（浮動）</summary>
        private Double _listPrice;

        /// <summary>原価単価</summary>
        private Double _salesUnitCost;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>子在庫情報</summary>
        private List<Stock> _subStockList;


		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  SubGoodsNo
		/// <summary>子商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubGoodsNo
		{
			get{return _subGoodsNo;}
			set{_subGoodsNo = value;}
		}

		/// public propaty name  :  SubGoodsName
		/// <summary>子商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubGoodsName
		{
			get{return _subGoodsName;}
			set{_subGoodsName = value;}
		}

		/// public propaty name  :  SubGoodsNameKana
		/// <summary>子商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubGoodsNameKana
		{
			get{return _subGoodsNameKana;}
			set{_subGoodsNameKana = value;}
		}

		/// public propaty name  :  SubGoodsMakerCd
		/// <summary>子商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubGoodsMakerCd
		{
			get{return _subGoodsMakerCd;}
			set{_subGoodsMakerCd = value;}
		}

		/// public propaty name  :  SubMakerName
		/// <summary>子メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubMakerName
		{
			get{return _subMakerName;}
			set{_subMakerName = value;}
		}

		/// public propaty name  :  SubWarehouseCd
		/// <summary>子倉庫コードプロパティ</summary>
		/// <value>拠点毎の倉庫優先順位1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubWarehouseCd
		{
			get{return _subWarehouseCd;}
			set{_subWarehouseCd = value;}
		}

		/// public propaty name  :  SubWarehouseName
		/// <summary>子倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubWarehouseName
		{
			get{return _subWarehouseName;}
			set{_subWarehouseName = value;}
		}

		/// public propaty name  :  SubSupplierStock
		/// <summary>子現在在庫数プロパティ</summary>
		/// <value>仕入在庫数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   子現在在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SubSupplierStock
		{
			get{return _subSupplierStock;}
			set{_subSupplierStock = value;}
		}

		/// public propaty name  :  CntFl
		/// <summary>QTYプロパティ</summary>
		/// <value>数量（浮動）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   QTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double CntFl
		{
			get{return _cntFl;}
			set{_cntFl = value;}
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
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
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
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
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
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  Division
		/// <summary>提供区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Division
		{
			get{return _division;}
			set{_division = value;}
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

        /// public propaty name  :  SubStockList
        /// <summary>子在庫情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子在庫情報プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public List<Stock> SubStockList
        {
            get { return _subStockList; }
            set { _subStockList = value; }
        }


		/// <summary>
		/// 在庫組立・分解処理子商品情報クラスコンストラクタ
		/// </summary>
		/// <returns>SubGoodsSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SubGoodsSet()
		{
		}

		/// <summary>
		/// 在庫組立・分解処理子商品情報クラスコンストラクタ
		/// </summary>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="subGoodsNo">子商品番号</param>
		/// <param name="subGoodsName">子商品名称</param>
		/// <param name="subGoodsNameKana">子商品名称カナ</param>
		/// <param name="subGoodsMakerCd">子商品メーカーコード</param>
		/// <param name="subMakerName">子メーカー名称</param>
		/// <param name="subWarehouseCd">子倉庫コード(拠点毎の倉庫優先順位1)</param>
		/// <param name="subWarehouseName">子倉庫名称</param>
		/// <param name="subSupplierStock">子現在在庫数(仕入在庫数)</param>
		/// <param name="cntFl">QTY(数量（浮動）)</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
		/// <param name="division">提供区分</param>
        /// <param name="listPrice">定価（浮動）</param>
        /// <param name="salesUnitCost">原価単価</param>
        /// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
        /// <returns>SubGoodsSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SubGoodsSet(Int32 displayOrder, string subGoodsNo, string subGoodsName, string subGoodsNameKana, Int32 subGoodsMakerCd, string subMakerName, string subWarehouseCd, string subWarehouseName, Double subSupplierStock, Double cntFl, Int32 bLGoodsCode, string bLGoodsFullName, Double shipmentPosCnt, string division, Double listPrice, Double salesUnitCost, Int32 openPriceDiv)
		{
			this._displayOrder = displayOrder;
			this._subGoodsNo = subGoodsNo;
			this._subGoodsName = subGoodsName;
			this._subGoodsNameKana = subGoodsNameKana;
			this._subGoodsMakerCd = subGoodsMakerCd;
			this._subMakerName = subMakerName;
			this._subWarehouseCd = subWarehouseCd;
			this._subWarehouseName = subWarehouseName;
			this._subSupplierStock = subSupplierStock;
			this._cntFl = cntFl;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._shipmentPosCnt = shipmentPosCnt;
			this._division = division;
            this._listPrice = listPrice;
            this._salesUnitCost = salesUnitCost;
            this._openPriceDiv = openPriceDiv;

		}

		/// <summary>
		/// 在庫組立・分解処理子商品情報クラス複製処理
		/// </summary>
		/// <returns>SubGoodsSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSubGoodsSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SubGoodsSet Clone()
		{
            return new SubGoodsSet(this._displayOrder, this._subGoodsNo, this._subGoodsName, this._subGoodsNameKana, this._subGoodsMakerCd, this._subMakerName, this._subWarehouseCd, this._subWarehouseName, this._subSupplierStock, this._cntFl, this._bLGoodsCode, this._bLGoodsFullName, this._shipmentPosCnt, this._division, this._listPrice, this._salesUnitCost, this._openPriceDiv);
		}

		/// <summary>
		/// 在庫組立・分解処理子商品情報クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSubGoodsSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SubGoodsSet target)
		{
			return ((this.DisplayOrder == target.DisplayOrder)
				 && (this.SubGoodsNo == target.SubGoodsNo)
				 && (this.SubGoodsName == target.SubGoodsName)
				 && (this.SubGoodsNameKana == target.SubGoodsNameKana)
				 && (this.SubGoodsMakerCd == target.SubGoodsMakerCd)
				 && (this.SubMakerName == target.SubMakerName)
				 && (this.SubWarehouseCd == target.SubWarehouseCd)
				 && (this.SubWarehouseName == target.SubWarehouseName)
				 && (this.SubSupplierStock == target.SubSupplierStock)
				 && (this.CntFl == target.CntFl)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.Division == target.Division)
				 && (this.ListPrice == target.ListPrice)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.OpenPriceDiv == target.OpenPriceDiv));
		}

		/// <summary>
		/// 在庫組立・分解処理子商品情報クラス比較処理
		/// </summary>
		/// <param name="subGoodsSet1">
		///                    比較するSubGoodsSetクラスのインスタンス
		/// </param>
		/// <param name="subGoodsSet2">比較するSubGoodsSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SubGoodsSet subGoodsSet1, SubGoodsSet subGoodsSet2)
		{
			return ((subGoodsSet1.DisplayOrder == subGoodsSet2.DisplayOrder)
				 && (subGoodsSet1.SubGoodsNo == subGoodsSet2.SubGoodsNo)
				 && (subGoodsSet1.SubGoodsName == subGoodsSet2.SubGoodsName)
				 && (subGoodsSet1.SubGoodsNameKana == subGoodsSet2.SubGoodsNameKana)
				 && (subGoodsSet1.SubGoodsMakerCd == subGoodsSet2.SubGoodsMakerCd)
				 && (subGoodsSet1.SubMakerName == subGoodsSet2.SubMakerName)
				 && (subGoodsSet1.SubWarehouseCd == subGoodsSet2.SubWarehouseCd)
				 && (subGoodsSet1.SubWarehouseName == subGoodsSet2.SubWarehouseName)
				 && (subGoodsSet1.SubSupplierStock == subGoodsSet2.SubSupplierStock)
				 && (subGoodsSet1.CntFl == subGoodsSet2.CntFl)
				 && (subGoodsSet1.BLGoodsCode == subGoodsSet2.BLGoodsCode)
				 && (subGoodsSet1.BLGoodsFullName == subGoodsSet2.BLGoodsFullName)
				 && (subGoodsSet1.ShipmentPosCnt == subGoodsSet2.ShipmentPosCnt)
				 && (subGoodsSet1.Division == subGoodsSet2.Division)
				 && (subGoodsSet1.ListPrice == subGoodsSet2.ListPrice)
				 && (subGoodsSet1.SalesUnitCost == subGoodsSet2.SalesUnitCost)
				 && (subGoodsSet1.OpenPriceDiv == subGoodsSet2.OpenPriceDiv));
		}
		/// <summary>
		/// 在庫組立・分解処理子商品情報クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSubGoodsSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SubGoodsSet target)
		{
			ArrayList resList = new ArrayList();
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.SubGoodsNo != target.SubGoodsNo)resList.Add("SubGoodsNo");
			if(this.SubGoodsName != target.SubGoodsName)resList.Add("SubGoodsName");
			if(this.SubGoodsNameKana != target.SubGoodsNameKana)resList.Add("SubGoodsNameKana");
			if(this.SubGoodsMakerCd != target.SubGoodsMakerCd)resList.Add("SubGoodsMakerCd");
			if(this.SubMakerName != target.SubMakerName)resList.Add("SubMakerName");
			if(this.SubWarehouseCd != target.SubWarehouseCd)resList.Add("SubWarehouseCd");
			if(this.SubWarehouseName != target.SubWarehouseName)resList.Add("SubWarehouseName");
			if(this.SubSupplierStock != target.SubSupplierStock)resList.Add("SubSupplierStock");
			if(this.CntFl != target.CntFl)resList.Add("CntFl");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.ShipmentPosCnt != target.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(this.Division != target.Division)resList.Add("Division");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");

			return resList;
		}

		/// <summary>
		/// 在庫組立・分解処理子商品情報クラス比較処理
		/// </summary>
		/// <param name="subGoodsSet1">比較するSubGoodsSetクラスのインスタンス</param>
		/// <param name="subGoodsSet2">比較するSubGoodsSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SubGoodsSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SubGoodsSet subGoodsSet1, SubGoodsSet subGoodsSet2)
		{
			ArrayList resList = new ArrayList();
			if(subGoodsSet1.DisplayOrder != subGoodsSet2.DisplayOrder)resList.Add("DisplayOrder");
			if(subGoodsSet1.SubGoodsNo != subGoodsSet2.SubGoodsNo)resList.Add("SubGoodsNo");
			if(subGoodsSet1.SubGoodsName != subGoodsSet2.SubGoodsName)resList.Add("SubGoodsName");
			if(subGoodsSet1.SubGoodsNameKana != subGoodsSet2.SubGoodsNameKana)resList.Add("SubGoodsNameKana");
			if(subGoodsSet1.SubGoodsMakerCd != subGoodsSet2.SubGoodsMakerCd)resList.Add("SubGoodsMakerCd");
			if(subGoodsSet1.SubMakerName != subGoodsSet2.SubMakerName)resList.Add("SubMakerName");
			if(subGoodsSet1.SubWarehouseCd != subGoodsSet2.SubWarehouseCd)resList.Add("SubWarehouseCd");
			if(subGoodsSet1.SubWarehouseName != subGoodsSet2.SubWarehouseName)resList.Add("SubWarehouseName");
			if(subGoodsSet1.SubSupplierStock != subGoodsSet2.SubSupplierStock)resList.Add("SubSupplierStock");
			if(subGoodsSet1.CntFl != subGoodsSet2.CntFl)resList.Add("CntFl");
			if(subGoodsSet1.BLGoodsCode != subGoodsSet2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(subGoodsSet1.BLGoodsFullName != subGoodsSet2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(subGoodsSet1.ShipmentPosCnt != subGoodsSet2.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(subGoodsSet1.Division != subGoodsSet2.Division)resList.Add("Division");
            if (subGoodsSet1.ListPrice != subGoodsSet2.ListPrice) resList.Add("ListPrice");
            if (subGoodsSet1.SalesUnitCost != subGoodsSet2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (subGoodsSet1.OpenPriceDiv != subGoodsSet2.OpenPriceDiv) resList.Add("OpenPriceDiv");

			return resList;
		}
	}
}

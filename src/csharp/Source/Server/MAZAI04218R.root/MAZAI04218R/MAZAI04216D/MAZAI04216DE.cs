using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockAcPayHistWork
	/// <summary>
	///                      在庫受払履歴データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫受払履歴データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2010/02/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/30  長内</br>
	/// <br>                 :   ＤＤ名修正</br>
	/// <br>                 :   BL商品コード名称（全角）</br>
	/// <br>                 :   BLGoodsFullName → BLGoodsFullNameRF</br>
	/// <br>Update Note      :   2008/6/30  杉村</br>
	/// <br>                 :   受払元取引区分の補足に</br>
	/// <br>                 :   「42:マスタメンテ」追加</br>
	/// <br>Update Note      :   2008/8/22  長内</br>
	/// <br>                 :   受払元伝票区分の補足に</br>
	/// <br>                 :   「13:在庫仕入」追加</br>
	/// <br>Update Note      :   2008/10/09  杉村</br>
	/// <br>                 :   受払元伝票区分の補足に</br>
	/// <br>                 :   「60:組立,61:分解,70:補充」追加</br>
	/// <br>Update Note      :   2008/10/14  杉村</br>
	/// <br>                 :   受払元伝票区分の補足変更</br>
	/// <br>                 :   「70:補充」⇒「70:補充入庫,70:補充出庫」</br>
	/// <br>Update Note      :   2008/10/30  長内</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,11,12,13,14 → 3,11,12,13,14,24,26,32</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockAcPayHistWork
	{
		/// <summary>入出荷日</summary>
        private DateTime _ioGoodsDay;

		/// <summary>計上日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpADate;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>提供範囲はプロダクト毎で定義</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>倉庫コード</summary>
		/// <remarks>出荷、入荷が発生する倉庫</remarks>
		private string _warehouseCode = "";

		/// <summary>入荷数</summary>
		/// <remarks>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</remarks>
		private Double _arrivalCnt;

		/// <summary>出荷数</summary>
		/// <remarks>売上入力、在庫移動（出荷）時にセット</remarks>
		private Double _shipmentCnt;

		/// public propaty name  :  IoGoodsDay
		/// <summary>入出荷日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime IoGoodsDay
		{
			get{return _ioGoodsDay;}
			set{_ioGoodsDay = value;}
		}

		/// public propaty name  :  AddUpADate
		/// <summary>計上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>提供範囲はプロダクト毎で定義</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
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
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// <value>出荷、入荷が発生する倉庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  ArrivalCnt
		/// <summary>入荷数プロパティ</summary>
		/// <value>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数プロパティ</summary>
		/// <value>売上入力、在庫移動（出荷）時にセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// <summary>
		/// 在庫受払履歴データワークコンストラクタ
		/// </summary>
		/// <returns>StockAcPayHistWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHistWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAcPayHistWork()
		{
		}

	}
}

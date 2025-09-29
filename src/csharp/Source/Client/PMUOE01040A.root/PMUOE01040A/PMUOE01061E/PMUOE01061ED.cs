using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OrderLstInputDtl
	/// <summary>
	///                      注文一覧明細(手入力)クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   注文一覧明細(手入力)クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OrderLstInputDtl
	{
		/// <summary>お客様名</summary>
		private String _userName;

		/// <summary>お客様CD</summary>
		/// <remarks>部販へ発注する際、部販から拠点事に割り当てられたコード</remarks>
		private String _userCode;

		/// <summary>アイテム</summary>
		private String _itemCode;

		/// <summary>注文日</summary>
		private DateTime _orderDate;

		/// <summary>注文時間</summary>
		private Int32 _orderTime;

		/// <summary>伝票番号(ヘッダー部)</summary>
		private String _slipNoHead;

		/// <summary>メモ欄</summary>
		private String _memo;

		/// <summary>発注部品番号</summary>
		private String _orderGoodsNo;

		/// <summary>出荷部品番号</summary>
		private String _shipmGoodsNo;

		/// <summary>出荷部品名</summary>
		private String _goodsName;

		/// <summary>引当数量</summary>
		private Double _shipmentCnt;

		/// <summary>発注残数量</summary>
		private Double _orderRemCnt;

		/// <summary>希望小売価格</summary>
		private Double _answerListPrice;

		/// <summary>出荷元名</summary>
		private String _sourceShipment;

		/// <summary>お届予定日</summary>
		private DateTime _planDate;

		/// <summary>伝票番号(明細部)</summary>
		private String _slipNoDtl;

		/// <summary>仕入れ価格</summary>
		private Double _answerSalesUnitCost;


		/// public propaty name  :  UserName
		/// <summary>お客様名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お客様名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String UserName
		{
			get{return _userName;}
			set{_userName = value;}
		}

		/// public propaty name  :  UserCode
		/// <summary>お客様CDプロパティ</summary>
		/// <value>部販へ発注する際、部販から拠点事に割り当てられたコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お客様CDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String UserCode
		{
			get{return _userCode;}
			set{_userCode = value;}
		}

		/// public propaty name  :  ItemCode
		/// <summary>アイテムプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   アイテムプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String ItemCode
		{
			get{return _itemCode;}
			set{_itemCode = value;}
		}

		/// public propaty name  :  OrderDate
		/// <summary>注文日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime OrderDate
		{
			get{return _orderDate;}
			set{_orderDate = value;}
		}

		/// public propaty name  :  OrderTime
		/// <summary>注文時間プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderTime
		{
			get{return _orderTime;}
			set{_orderTime = value;}
		}

		/// public propaty name  :  SlipNoHead
		/// <summary>伝票番号(ヘッダー部)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号(ヘッダー部)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String SlipNoHead
		{
			get{return _slipNoHead;}
			set{_slipNoHead = value;}
		}

		/// public propaty name  :  Memo
		/// <summary>メモ欄プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メモ欄プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String Memo
		{
			get{return _memo;}
			set{_memo = value;}
		}

		/// public propaty name  :  OrderGoodsNo
		/// <summary>発注部品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注部品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String OrderGoodsNo
		{
			get{return _orderGoodsNo;}
			set{_orderGoodsNo = value;}
		}

		/// public propaty name  :  ShipmGoodsNo
		/// <summary>出荷部品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷部品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String ShipmGoodsNo
		{
			get{return _shipmGoodsNo;}
			set{_shipmGoodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>出荷部品名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷部品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>引当数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  OrderRemCnt
		/// <summary>発注残数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注残数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double OrderRemCnt
		{
			get{return _orderRemCnt;}
			set{_orderRemCnt = value;}
		}

		/// public propaty name  :  AnswerListPrice
		/// <summary>希望小売価格プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望小売価格プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AnswerListPrice
		{
			get{return _answerListPrice;}
			set{_answerListPrice = value;}
		}

		/// public propaty name  :  SourceShipment
		/// <summary>出荷元名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷元名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String SourceShipment
		{
			get{return _sourceShipment;}
			set{_sourceShipment = value;}
		}

		/// public propaty name  :  PlanDate
		/// <summary>お届予定日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お届予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PlanDate
		{
			get{return _planDate;}
			set{_planDate = value;}
		}

		/// public propaty name  :  SlipNoDtl
		/// <summary>伝票番号(明細部)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号(明細部)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String SlipNoDtl
		{
			get{return _slipNoDtl;}
			set{_slipNoDtl = value;}
		}

		/// public propaty name  :  AnswerSalesUnitCost
		/// <summary>仕入れ価格プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入れ価格プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AnswerSalesUnitCost
		{
			get{return _answerSalesUnitCost;}
			set{_answerSalesUnitCost = value;}
		}


		/// <summary>
		/// 注文一覧明細(手入力)クラスコンストラクタ
		/// </summary>
		/// <returns>OrderLstInputDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLstInputDtl()
		{
		}

		/// <summary>
		/// 注文一覧明細(手入力)クラスコンストラクタ
		/// </summary>
		/// <param name="userName">お客様名</param>
		/// <param name="userCode">お客様CD(部販へ発注する際、部販から拠点事に割り当てられたコード)</param>
		/// <param name="itemCode">アイテム</param>
		/// <param name="orderDate">注文日</param>
		/// <param name="orderTime">注文時間</param>
		/// <param name="slipNoHead">伝票番号(ヘッダー部)</param>
		/// <param name="memo">メモ欄</param>
		/// <param name="orderGoodsNo">発注部品番号</param>
		/// <param name="shipmGoodsNo">出荷部品番号</param>
		/// <param name="goodsName">出荷部品名</param>
		/// <param name="shipmentCnt">引当数量</param>
		/// <param name="orderRemCnt">発注残数量</param>
		/// <param name="answerListPrice">希望小売価格</param>
		/// <param name="sourceShipment">出荷元名</param>
		/// <param name="planDate">お届予定日</param>
		/// <param name="slipNoDtl">伝票番号(明細部)</param>
		/// <param name="answerSalesUnitCost">仕入れ価格</param>
		/// <returns>OrderLstInputDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLstInputDtl(String userName,String userCode,String itemCode,DateTime orderDate,Int32 orderTime,String slipNoHead,String memo,String orderGoodsNo,String shipmGoodsNo,String goodsName,Double shipmentCnt,Double orderRemCnt,Double answerListPrice,String sourceShipment,DateTime planDate,String slipNoDtl,Double answerSalesUnitCost)
		{
			this._userName = userName;
			this._userCode = userCode;
			this._itemCode = itemCode;
			this._orderDate = orderDate;
			this._orderTime = orderTime;
			this._slipNoHead = slipNoHead;
			this._memo = memo;
			this._orderGoodsNo = orderGoodsNo;
			this._shipmGoodsNo = shipmGoodsNo;
			this._goodsName = goodsName;
			this._shipmentCnt = shipmentCnt;
			this._orderRemCnt = orderRemCnt;
			this._answerListPrice = answerListPrice;
			this._sourceShipment = sourceShipment;
			this._planDate = planDate;
			this._slipNoDtl = slipNoDtl;
			this._answerSalesUnitCost = answerSalesUnitCost;

		}

		/// <summary>
		/// 注文一覧明細(手入力)クラス複製処理
		/// </summary>
		/// <returns>OrderLstInputDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいOrderLstInputDtlクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLstInputDtl Clone()
		{
			return new OrderLstInputDtl(this._userName,this._userCode,this._itemCode,this._orderDate,this._orderTime,this._slipNoHead,this._memo,this._orderGoodsNo,this._shipmGoodsNo,this._goodsName,this._shipmentCnt,this._orderRemCnt,this._answerListPrice,this._sourceShipment,this._planDate,this._slipNoDtl,this._answerSalesUnitCost);
		}

		/// <summary>
		/// 注文一覧明細(手入力)クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のOrderLstInputDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(OrderLstInputDtl target)
		{
			return ((this.UserName == target.UserName)
				 && (this.UserCode == target.UserCode)
				 && (this.ItemCode == target.ItemCode)
				 && (this.OrderDate == target.OrderDate)
				 && (this.OrderTime == target.OrderTime)
				 && (this.SlipNoHead == target.SlipNoHead)
				 && (this.Memo == target.Memo)
				 && (this.OrderGoodsNo == target.OrderGoodsNo)
				 && (this.ShipmGoodsNo == target.ShipmGoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.OrderRemCnt == target.OrderRemCnt)
				 && (this.AnswerListPrice == target.AnswerListPrice)
				 && (this.SourceShipment == target.SourceShipment)
				 && (this.PlanDate == target.PlanDate)
				 && (this.SlipNoDtl == target.SlipNoDtl)
				 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost));
		}

		/// <summary>
		/// 注文一覧明細(手入力)クラス比較処理
		/// </summary>
		/// <param name="orderLstInputDtl1">
		///                    比較するOrderLstInputDtlクラスのインスタンス
		/// </param>
		/// <param name="orderLstInputDtl2">比較するOrderLstInputDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(OrderLstInputDtl orderLstInputDtl1, OrderLstInputDtl orderLstInputDtl2)
		{
			return ((orderLstInputDtl1.UserName == orderLstInputDtl2.UserName)
				 && (orderLstInputDtl1.UserCode == orderLstInputDtl2.UserCode)
				 && (orderLstInputDtl1.ItemCode == orderLstInputDtl2.ItemCode)
				 && (orderLstInputDtl1.OrderDate == orderLstInputDtl2.OrderDate)
				 && (orderLstInputDtl1.OrderTime == orderLstInputDtl2.OrderTime)
				 && (orderLstInputDtl1.SlipNoHead == orderLstInputDtl2.SlipNoHead)
				 && (orderLstInputDtl1.Memo == orderLstInputDtl2.Memo)
				 && (orderLstInputDtl1.OrderGoodsNo == orderLstInputDtl2.OrderGoodsNo)
				 && (orderLstInputDtl1.ShipmGoodsNo == orderLstInputDtl2.ShipmGoodsNo)
				 && (orderLstInputDtl1.GoodsName == orderLstInputDtl2.GoodsName)
				 && (orderLstInputDtl1.ShipmentCnt == orderLstInputDtl2.ShipmentCnt)
				 && (orderLstInputDtl1.OrderRemCnt == orderLstInputDtl2.OrderRemCnt)
				 && (orderLstInputDtl1.AnswerListPrice == orderLstInputDtl2.AnswerListPrice)
				 && (orderLstInputDtl1.SourceShipment == orderLstInputDtl2.SourceShipment)
				 && (orderLstInputDtl1.PlanDate == orderLstInputDtl2.PlanDate)
				 && (orderLstInputDtl1.SlipNoDtl == orderLstInputDtl2.SlipNoDtl)
				 && (orderLstInputDtl1.AnswerSalesUnitCost == orderLstInputDtl2.AnswerSalesUnitCost));
		}
		/// <summary>
		/// 注文一覧明細(手入力)クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のOrderLstInputDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(OrderLstInputDtl target)
		{
			ArrayList resList = new ArrayList();
			if(this.UserName != target.UserName)resList.Add("UserName");
			if(this.UserCode != target.UserCode)resList.Add("UserCode");
			if(this.ItemCode != target.ItemCode)resList.Add("ItemCode");
			if(this.OrderDate != target.OrderDate)resList.Add("OrderDate");
			if(this.OrderTime != target.OrderTime)resList.Add("OrderTime");
			if(this.SlipNoHead != target.SlipNoHead)resList.Add("SlipNoHead");
			if(this.Memo != target.Memo)resList.Add("Memo");
			if(this.OrderGoodsNo != target.OrderGoodsNo)resList.Add("OrderGoodsNo");
			if(this.ShipmGoodsNo != target.ShipmGoodsNo)resList.Add("ShipmGoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.OrderRemCnt != target.OrderRemCnt)resList.Add("OrderRemCnt");
			if(this.AnswerListPrice != target.AnswerListPrice)resList.Add("AnswerListPrice");
			if(this.SourceShipment != target.SourceShipment)resList.Add("SourceShipment");
			if(this.PlanDate != target.PlanDate)resList.Add("PlanDate");
			if(this.SlipNoDtl != target.SlipNoDtl)resList.Add("SlipNoDtl");
			if(this.AnswerSalesUnitCost != target.AnswerSalesUnitCost)resList.Add("AnswerSalesUnitCost");

			return resList;
		}

		/// <summary>
		/// 注文一覧明細(手入力)クラス比較処理
		/// </summary>
		/// <param name="orderLstInputDtl1">比較するOrderLstInputDtlクラスのインスタンス</param>
		/// <param name="orderLstInputDtl2">比較するOrderLstInputDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstInputDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(OrderLstInputDtl orderLstInputDtl1, OrderLstInputDtl orderLstInputDtl2)
		{
			ArrayList resList = new ArrayList();
			if(orderLstInputDtl1.UserName != orderLstInputDtl2.UserName)resList.Add("UserName");
			if(orderLstInputDtl1.UserCode != orderLstInputDtl2.UserCode)resList.Add("UserCode");
			if(orderLstInputDtl1.ItemCode != orderLstInputDtl2.ItemCode)resList.Add("ItemCode");
			if(orderLstInputDtl1.OrderDate != orderLstInputDtl2.OrderDate)resList.Add("OrderDate");
			if(orderLstInputDtl1.OrderTime != orderLstInputDtl2.OrderTime)resList.Add("OrderTime");
			if(orderLstInputDtl1.SlipNoHead != orderLstInputDtl2.SlipNoHead)resList.Add("SlipNoHead");
			if(orderLstInputDtl1.Memo != orderLstInputDtl2.Memo)resList.Add("Memo");
			if(orderLstInputDtl1.OrderGoodsNo != orderLstInputDtl2.OrderGoodsNo)resList.Add("OrderGoodsNo");
			if(orderLstInputDtl1.ShipmGoodsNo != orderLstInputDtl2.ShipmGoodsNo)resList.Add("ShipmGoodsNo");
			if(orderLstInputDtl1.GoodsName != orderLstInputDtl2.GoodsName)resList.Add("GoodsName");
			if(orderLstInputDtl1.ShipmentCnt != orderLstInputDtl2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(orderLstInputDtl1.OrderRemCnt != orderLstInputDtl2.OrderRemCnt)resList.Add("OrderRemCnt");
			if(orderLstInputDtl1.AnswerListPrice != orderLstInputDtl2.AnswerListPrice)resList.Add("AnswerListPrice");
			if(orderLstInputDtl1.SourceShipment != orderLstInputDtl2.SourceShipment)resList.Add("SourceShipment");
			if(orderLstInputDtl1.PlanDate != orderLstInputDtl2.PlanDate)resList.Add("PlanDate");
			if(orderLstInputDtl1.SlipNoDtl != orderLstInputDtl2.SlipNoDtl)resList.Add("SlipNoDtl");
			if(orderLstInputDtl1.AnswerSalesUnitCost != orderLstInputDtl2.AnswerSalesUnitCost)resList.Add("AnswerSalesUnitCost");

			return resList;
		}
	}
}

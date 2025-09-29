using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BuyOutLstDtl
	/// <summary>
	///                      買上一覧明細クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   買上一覧明細クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BuyOutLstDtl
	{
		/// <summary>通番</summary>
		private Int32 _no;

		/// <summary>注文月日</summary>
		private DateTime _orderDate;

		/// <summary>お買上日</summary>
		private DateTime _buyOutDate;

		/// <summary>部番</summary>
		private String _goodsNo;

		/// <summary>品名</summary>
		private String _goodsName;

		/// <summary>数量</summary>
		private Double _shipmentCnt;

		/// <summary>希望小売価格</summary>
		private Double _answerListPrice;

		/// <summary>お買上単価</summary>
		private Double _buyOutCost;

		/// <summary>お買上額合計</summary>
		private Double _buyOutTotalCost;

		/// <summary>伝票番号</summary>
		private String _buyOutSlipNo;

		/// <summary>注文時伝票番号</summary>
		private String _orderSlipNo;

		/// <summary>コメント(特記事項)</summary>
		/// <remarks>カタログのコメントや単位・カラーが格納</remarks>
		private String _comment;

		/// <summary>注文時単価</summary>
		/// <remarks>戻値</remarks>
		private Double _orderCost;

		/// <summary>更新結果</summary>
		/// <remarks>1:引当正常 2:該当無 3:明細不一致 9:引当済 4:締次更新処理済 5:月次更新処理済 6:仕入データ作成 7:単価変更</remarks>
		private Int32 _updRsl;


		/// public propaty name  :  No
		/// <summary>通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 No
		{
			get{return _no;}
			set{_no = value;}
		}

		/// public propaty name  :  OrderDate
		/// <summary>注文月日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime OrderDate
		{
			get{return _orderDate;}
			set{_orderDate = value;}
		}

		/// public propaty name  :  BuyOutDate
		/// <summary>お買上日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime BuyOutDate
		{
			get{return _buyOutDate;}
			set{_buyOutDate = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>部番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>品名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
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

		/// public propaty name  :  BuyOutCost
		/// <summary>お買上単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買上単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BuyOutCost
		{
			get{return _buyOutCost;}
			set{_buyOutCost = value;}
		}

		/// public propaty name  :  BuyOutTotalCost
		/// <summary>お買上額合計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買上額合計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BuyOutTotalCost
		{
			get{return _buyOutTotalCost;}
			set{_buyOutTotalCost = value;}
		}

		/// public propaty name  :  BuyOutSlipNo
		/// <summary>伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String BuyOutSlipNo
		{
			get{return _buyOutSlipNo;}
			set{_buyOutSlipNo = value;}
		}

		/// public propaty name  :  OrderSlipNo
		/// <summary>注文時伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文時伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String OrderSlipNo
		{
			get{return _orderSlipNo;}
			set{_orderSlipNo = value;}
		}

		/// public propaty name  :  Comment
		/// <summary>コメント(特記事項)プロパティ</summary>
		/// <value>カタログのコメントや単位・カラーが格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   コメント(特記事項)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  OrderCost
		/// <summary>注文時単価プロパティ</summary>
		/// <value>戻値</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文時単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double OrderCost
		{
			get{return _orderCost;}
			set{_orderCost = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>更新結果プロパティ</summary>
		/// <value>1:引当正常 2:該当無 3:明細不一致 9:引当済 4:締次更新処理済 5:月次更新処理済 6:仕入データ作成 7:単価変更</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新結果プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdRsl
		{
			get{return _updRsl;}
			set{_updRsl = value;}
		}


		/// <summary>
		/// 買上一覧明細クラスコンストラクタ
		/// </summary>
		/// <returns>BuyOutLstDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLstDtl()
		{
		}

		/// <summary>
		/// 買上一覧明細クラスコンストラクタ
		/// </summary>
		/// <param name="no">通番</param>
		/// <param name="orderDate">注文月日</param>
		/// <param name="buyOutDate">お買上日</param>
		/// <param name="goodsNo">部番</param>
		/// <param name="goodsName">品名</param>
		/// <param name="shipmentCnt">数量</param>
		/// <param name="answerListPrice">希望小売価格</param>
		/// <param name="buyOutCost">お買上単価</param>
		/// <param name="buyOutTotalCost">お買上額合計</param>
		/// <param name="buyOutSlipNo">伝票番号</param>
		/// <param name="orderSlipNo">注文時伝票番号</param>
		/// <param name="comment">コメント(特記事項)(カタログのコメントや単位・カラーが格納)</param>
		/// <param name="orderCost">注文時単価(戻値)</param>
		/// <param name="updRsl">更新結果(1:引当正常 2:該当無 3:明細不一致 9:引当済 4:締次更新処理済 5:月次更新処理済 6:仕入データ作成 7:単価変更)</param>
		/// <returns>BuyOutLstDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLstDtl(Int32 no,DateTime orderDate,DateTime buyOutDate,String goodsNo,String goodsName,Double shipmentCnt,Double answerListPrice,Double buyOutCost,Double buyOutTotalCost,String buyOutSlipNo,String orderSlipNo,String comment,Double orderCost,Int32 updRsl)
		{
			this._no = no;
			this._orderDate = orderDate;
			this._buyOutDate = buyOutDate;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._shipmentCnt = shipmentCnt;
			this._answerListPrice = answerListPrice;
			this._buyOutCost = buyOutCost;
			this._buyOutTotalCost = buyOutTotalCost;
			this._buyOutSlipNo = buyOutSlipNo;
			this._orderSlipNo = orderSlipNo;
			this._comment = comment;
			this._orderCost = orderCost;
			this._updRsl = updRsl;

		}

		/// <summary>
		/// 買上一覧明細クラス複製処理
		/// </summary>
		/// <returns>BuyOutLstDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいBuyOutLstDtlクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLstDtl Clone()
		{
			return new BuyOutLstDtl(this._no,this._orderDate,this._buyOutDate,this._goodsNo,this._goodsName,this._shipmentCnt,this._answerListPrice,this._buyOutCost,this._buyOutTotalCost,this._buyOutSlipNo,this._orderSlipNo,this._comment,this._orderCost,this._updRsl);
		}

		/// <summary>
		/// 買上一覧明細クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBuyOutLstDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(BuyOutLstDtl target)
		{
			return ((this.No == target.No)
				 && (this.OrderDate == target.OrderDate)
				 && (this.BuyOutDate == target.BuyOutDate)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.AnswerListPrice == target.AnswerListPrice)
				 && (this.BuyOutCost == target.BuyOutCost)
				 && (this.BuyOutTotalCost == target.BuyOutTotalCost)
				 && (this.BuyOutSlipNo == target.BuyOutSlipNo)
				 && (this.OrderSlipNo == target.OrderSlipNo)
				 && (this.Comment == target.Comment)
				 && (this.OrderCost == target.OrderCost)
				 && (this.UpdRsl == target.UpdRsl));
		}

		/// <summary>
		/// 買上一覧明細クラス比較処理
		/// </summary>
		/// <param name="buyOutLstDtl1">
		///                    比較するBuyOutLstDtlクラスのインスタンス
		/// </param>
		/// <param name="buyOutLstDtl2">比較するBuyOutLstDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(BuyOutLstDtl buyOutLstDtl1, BuyOutLstDtl buyOutLstDtl2)
		{
			return ((buyOutLstDtl1.No == buyOutLstDtl2.No)
				 && (buyOutLstDtl1.OrderDate == buyOutLstDtl2.OrderDate)
				 && (buyOutLstDtl1.BuyOutDate == buyOutLstDtl2.BuyOutDate)
				 && (buyOutLstDtl1.GoodsNo == buyOutLstDtl2.GoodsNo)
				 && (buyOutLstDtl1.GoodsName == buyOutLstDtl2.GoodsName)
				 && (buyOutLstDtl1.ShipmentCnt == buyOutLstDtl2.ShipmentCnt)
				 && (buyOutLstDtl1.AnswerListPrice == buyOutLstDtl2.AnswerListPrice)
				 && (buyOutLstDtl1.BuyOutCost == buyOutLstDtl2.BuyOutCost)
				 && (buyOutLstDtl1.BuyOutTotalCost == buyOutLstDtl2.BuyOutTotalCost)
				 && (buyOutLstDtl1.BuyOutSlipNo == buyOutLstDtl2.BuyOutSlipNo)
				 && (buyOutLstDtl1.OrderSlipNo == buyOutLstDtl2.OrderSlipNo)
				 && (buyOutLstDtl1.Comment == buyOutLstDtl2.Comment)
				 && (buyOutLstDtl1.OrderCost == buyOutLstDtl2.OrderCost)
				 && (buyOutLstDtl1.UpdRsl == buyOutLstDtl2.UpdRsl));
		}
		/// <summary>
		/// 買上一覧明細クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBuyOutLstDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(BuyOutLstDtl target)
		{
			ArrayList resList = new ArrayList();
			if(this.No != target.No)resList.Add("No");
			if(this.OrderDate != target.OrderDate)resList.Add("OrderDate");
			if(this.BuyOutDate != target.BuyOutDate)resList.Add("BuyOutDate");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.AnswerListPrice != target.AnswerListPrice)resList.Add("AnswerListPrice");
			if(this.BuyOutCost != target.BuyOutCost)resList.Add("BuyOutCost");
			if(this.BuyOutTotalCost != target.BuyOutTotalCost)resList.Add("BuyOutTotalCost");
			if(this.BuyOutSlipNo != target.BuyOutSlipNo)resList.Add("BuyOutSlipNo");
			if(this.OrderSlipNo != target.OrderSlipNo)resList.Add("OrderSlipNo");
			if(this.Comment != target.Comment)resList.Add("Comment");
			if(this.OrderCost != target.OrderCost)resList.Add("OrderCost");
			if(this.UpdRsl != target.UpdRsl)resList.Add("UpdRsl");

			return resList;
		}

		/// <summary>
		/// 買上一覧明細クラス比較処理
		/// </summary>
		/// <param name="buyOutLstDtl1">比較するBuyOutLstDtlクラスのインスタンス</param>
		/// <param name="buyOutLstDtl2">比較するBuyOutLstDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(BuyOutLstDtl buyOutLstDtl1, BuyOutLstDtl buyOutLstDtl2)
		{
			ArrayList resList = new ArrayList();
			if(buyOutLstDtl1.No != buyOutLstDtl2.No)resList.Add("No");
			if(buyOutLstDtl1.OrderDate != buyOutLstDtl2.OrderDate)resList.Add("OrderDate");
			if(buyOutLstDtl1.BuyOutDate != buyOutLstDtl2.BuyOutDate)resList.Add("BuyOutDate");
			if(buyOutLstDtl1.GoodsNo != buyOutLstDtl2.GoodsNo)resList.Add("GoodsNo");
			if(buyOutLstDtl1.GoodsName != buyOutLstDtl2.GoodsName)resList.Add("GoodsName");
			if(buyOutLstDtl1.ShipmentCnt != buyOutLstDtl2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(buyOutLstDtl1.AnswerListPrice != buyOutLstDtl2.AnswerListPrice)resList.Add("AnswerListPrice");
			if(buyOutLstDtl1.BuyOutCost != buyOutLstDtl2.BuyOutCost)resList.Add("BuyOutCost");
			if(buyOutLstDtl1.BuyOutTotalCost != buyOutLstDtl2.BuyOutTotalCost)resList.Add("BuyOutTotalCost");
			if(buyOutLstDtl1.BuyOutSlipNo != buyOutLstDtl2.BuyOutSlipNo)resList.Add("BuyOutSlipNo");
			if(buyOutLstDtl1.OrderSlipNo != buyOutLstDtl2.OrderSlipNo)resList.Add("OrderSlipNo");
			if(buyOutLstDtl1.Comment != buyOutLstDtl2.Comment)resList.Add("Comment");
			if(buyOutLstDtl1.OrderCost != buyOutLstDtl2.OrderCost)resList.Add("OrderCost");
			if(buyOutLstDtl1.UpdRsl != buyOutLstDtl2.UpdRsl)resList.Add("UpdRsl");

			return resList;
		}
	}
}

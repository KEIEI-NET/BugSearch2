using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderLstPmDtl
    /// <summary>
    ///                      注文一覧明細(PM連動)クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   注文一覧明細(PM連動)クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OrderLstPmDtl
    {
        /// <summary>販売店様名</summary>
        private String _userName;

        /// <summary>販売店様コード</summary>
        /// <remarks>部販へ発注する際、部販から拠点事に割り当てられたコード</remarks>
        private String _userCode;

        /// <summary>伝票番号(ヘッダー部)</summary>
        private String _slipNoHead;

        /// <summary>発注日</summary>
        private DateTime _orderDate;

        /// <summary>発注時間</summary>
        private Int32 _orderTime;

        /// <summary>アイテム</summary>
        private String _itemCode;

        /// <summary>メッセージ</summary>
        private String _msg;

        /// <summary>ｵﾝﾗｲﾝ番号(連携番号)</summary>
        private Int32 _linkNo;

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

        /// <summary>メモ欄</summary>
        private String _memo;

        /// <summary>仕入れ価格</summary>
        private Double _answerSalesUnitCost;


        /// public propaty name  :  UserName
        /// <summary>販売店様名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売店様名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// public propaty name  :  UserCode
        /// <summary>販売店様コードプロパティ</summary>
        /// <value>部販へ発注する際、部販から拠点事に割り当てられたコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売店様コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
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
            get { return _slipNoHead; }
            set { _slipNoHead = value; }
        }

        /// public propaty name  :  OrderDate
        /// <summary>発注日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        /// public propaty name  :  OrderTime
        /// <summary>発注時間プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
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
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        /// public propaty name  :  Msg
        /// <summary>メッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// public propaty name  :  LinkNo
        /// <summary>ｵﾝﾗｲﾝ番号(連携番号)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ｵﾝﾗｲﾝ番号(連携番号)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LinkNo
        {
            get { return _linkNo; }
            set { _linkNo = value; }
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
            get { return _orderGoodsNo; }
            set { _orderGoodsNo = value; }
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
            get { return _shipmGoodsNo; }
            set { _shipmGoodsNo = value; }
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
            get { return _goodsName; }
            set { _goodsName = value; }
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
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
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
            get { return _orderRemCnt; }
            set { _orderRemCnt = value; }
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
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
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
            get { return _sourceShipment; }
            set { _sourceShipment = value; }
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
            get { return _planDate; }
            set { _planDate = value; }
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
            get { return _slipNoDtl; }
            set { _slipNoDtl = value; }
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
            get { return _memo; }
            set { _memo = value; }
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
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }


        /// <summary>
        /// 注文一覧明細(PM連動)クラスコンストラクタ
        /// </summary>
        /// <returns>OrderLstPmDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderLstPmDtl()
        {
        }

        /// <summary>
        /// 注文一覧明細(PM連動)クラスコンストラクタ
        /// </summary>
        /// <param name="userName">販売店様名</param>
        /// <param name="userCode">販売店様コード(部販へ発注する際、部販から拠点事に割り当てられたコード)</param>
        /// <param name="slipNoHead">伝票番号(ヘッダー部)</param>
        /// <param name="orderDate">発注日</param>
        /// <param name="orderTime">発注時間</param>
        /// <param name="itemCode">アイテム</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="linkNo">ｵﾝﾗｲﾝ番号(連携番号)</param>
        /// <param name="orderGoodsNo">発注部品番号</param>
        /// <param name="shipmGoodsNo">出荷部品番号</param>
        /// <param name="goodsName">出荷部品名</param>
        /// <param name="shipmentCnt">引当数量</param>
        /// <param name="orderRemCnt">発注残数量</param>
        /// <param name="answerListPrice">希望小売価格</param>
        /// <param name="sourceShipment">出荷元名</param>
        /// <param name="planDate">お届予定日</param>
        /// <param name="slipNoDtl">伝票番号(明細部)</param>
        /// <param name="memo">メモ欄</param>
        /// <param name="answerSalesUnitCost">仕入れ価格</param>
        /// <returns>OrderLstPmDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderLstPmDtl(String userName, String userCode, String slipNoHead, DateTime orderDate, Int32 orderTime, String itemCode, String msg, Int32 linkNo, String orderGoodsNo, String shipmGoodsNo, String goodsName, Double shipmentCnt, Double orderRemCnt, Double answerListPrice, String sourceShipment, DateTime planDate, String slipNoDtl, String memo, Double answerSalesUnitCost)
        {
            this._userName = userName;
            this._userCode = userCode;
            this._slipNoHead = slipNoHead;
            this._orderDate = orderDate;
            this._orderTime = orderTime;
            this._itemCode = itemCode;
            this._msg = msg;
            this._linkNo = linkNo;
            this._orderGoodsNo = orderGoodsNo;
            this._shipmGoodsNo = shipmGoodsNo;
            this._goodsName = goodsName;
            this._shipmentCnt = shipmentCnt;
            this._orderRemCnt = orderRemCnt;
            this._answerListPrice = answerListPrice;
            this._sourceShipment = sourceShipment;
            this._planDate = planDate;
            this._slipNoDtl = slipNoDtl;
            this._memo = memo;
            this._answerSalesUnitCost = answerSalesUnitCost;

        }

        /// <summary>
        /// 注文一覧明細(PM連動)クラス複製処理
        /// </summary>
        /// <returns>OrderLstPmDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOrderLstPmDtlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderLstPmDtl Clone()
        {
            return new OrderLstPmDtl(this._userName, this._userCode, this._slipNoHead, this._orderDate, this._orderTime, this._itemCode, this._msg, this._linkNo, this._orderGoodsNo, this._shipmGoodsNo, this._goodsName, this._shipmentCnt, this._orderRemCnt, this._answerListPrice, this._sourceShipment, this._planDate, this._slipNoDtl, this._memo, this._answerSalesUnitCost);
        }

        /// <summary>
        /// 注文一覧明細(PM連動)クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のOrderLstPmDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(OrderLstPmDtl target)
        {
            return ((this.UserName == target.UserName)
                 && (this.UserCode == target.UserCode)
                 && (this.SlipNoHead == target.SlipNoHead)
                 && (this.OrderDate == target.OrderDate)
                 && (this.OrderTime == target.OrderTime)
                 && (this.ItemCode == target.ItemCode)
                 && (this.Msg == target.Msg)
                 && (this.LinkNo == target.LinkNo)
                 && (this.OrderGoodsNo == target.OrderGoodsNo)
                 && (this.ShipmGoodsNo == target.ShipmGoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.ShipmentCnt == target.ShipmentCnt)
                 && (this.OrderRemCnt == target.OrderRemCnt)
                 && (this.AnswerListPrice == target.AnswerListPrice)
                 && (this.SourceShipment == target.SourceShipment)
                 && (this.PlanDate == target.PlanDate)
                 && (this.SlipNoDtl == target.SlipNoDtl)
                 && (this.Memo == target.Memo)
                 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost));
        }

        /// <summary>
        /// 注文一覧明細(PM連動)クラス比較処理
        /// </summary>
        /// <param name="orderLstPmDtl1">
        ///                    比較するOrderLstPmDtlクラスのインスタンス
        /// </param>
        /// <param name="orderLstPmDtl2">比較するOrderLstPmDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(OrderLstPmDtl orderLstPmDtl1, OrderLstPmDtl orderLstPmDtl2)
        {
            return ((orderLstPmDtl1.UserName == orderLstPmDtl2.UserName)
                 && (orderLstPmDtl1.UserCode == orderLstPmDtl2.UserCode)
                 && (orderLstPmDtl1.SlipNoHead == orderLstPmDtl2.SlipNoHead)
                 && (orderLstPmDtl1.OrderDate == orderLstPmDtl2.OrderDate)
                 && (orderLstPmDtl1.OrderTime == orderLstPmDtl2.OrderTime)
                 && (orderLstPmDtl1.ItemCode == orderLstPmDtl2.ItemCode)
                 && (orderLstPmDtl1.Msg == orderLstPmDtl2.Msg)
                 && (orderLstPmDtl1.LinkNo == orderLstPmDtl2.LinkNo)
                 && (orderLstPmDtl1.OrderGoodsNo == orderLstPmDtl2.OrderGoodsNo)
                 && (orderLstPmDtl1.ShipmGoodsNo == orderLstPmDtl2.ShipmGoodsNo)
                 && (orderLstPmDtl1.GoodsName == orderLstPmDtl2.GoodsName)
                 && (orderLstPmDtl1.ShipmentCnt == orderLstPmDtl2.ShipmentCnt)
                 && (orderLstPmDtl1.OrderRemCnt == orderLstPmDtl2.OrderRemCnt)
                 && (orderLstPmDtl1.AnswerListPrice == orderLstPmDtl2.AnswerListPrice)
                 && (orderLstPmDtl1.SourceShipment == orderLstPmDtl2.SourceShipment)
                 && (orderLstPmDtl1.PlanDate == orderLstPmDtl2.PlanDate)
                 && (orderLstPmDtl1.SlipNoDtl == orderLstPmDtl2.SlipNoDtl)
                 && (orderLstPmDtl1.Memo == orderLstPmDtl2.Memo)
                 && (orderLstPmDtl1.AnswerSalesUnitCost == orderLstPmDtl2.AnswerSalesUnitCost));
        }
        /// <summary>
        /// 注文一覧明細(PM連動)クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のOrderLstPmDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(OrderLstPmDtl target)
        {
            ArrayList resList = new ArrayList();
            if (this.UserName != target.UserName) resList.Add("UserName");
            if (this.UserCode != target.UserCode) resList.Add("UserCode");
            if (this.SlipNoHead != target.SlipNoHead) resList.Add("SlipNoHead");
            if (this.OrderDate != target.OrderDate) resList.Add("OrderDate");
            if (this.OrderTime != target.OrderTime) resList.Add("OrderTime");
            if (this.ItemCode != target.ItemCode) resList.Add("ItemCode");
            if (this.Msg != target.Msg) resList.Add("Msg");
            if (this.LinkNo != target.LinkNo) resList.Add("LinkNo");
            if (this.OrderGoodsNo != target.OrderGoodsNo) resList.Add("OrderGoodsNo");
            if (this.ShipmGoodsNo != target.ShipmGoodsNo) resList.Add("ShipmGoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.ShipmentCnt != target.ShipmentCnt) resList.Add("ShipmentCnt");
            if (this.OrderRemCnt != target.OrderRemCnt) resList.Add("OrderRemCnt");
            if (this.AnswerListPrice != target.AnswerListPrice) resList.Add("AnswerListPrice");
            if (this.SourceShipment != target.SourceShipment) resList.Add("SourceShipment");
            if (this.PlanDate != target.PlanDate) resList.Add("PlanDate");
            if (this.SlipNoDtl != target.SlipNoDtl) resList.Add("SlipNoDtl");
            if (this.Memo != target.Memo) resList.Add("Memo");
            if (this.AnswerSalesUnitCost != target.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");

            return resList;
        }

        /// <summary>
        /// 注文一覧明細(PM連動)クラス比較処理
        /// </summary>
        /// <param name="orderLstPmDtl1">比較するOrderLstPmDtlクラスのインスタンス</param>
        /// <param name="orderLstPmDtl2">比較するOrderLstPmDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderLstPmDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(OrderLstPmDtl orderLstPmDtl1, OrderLstPmDtl orderLstPmDtl2)
        {
            ArrayList resList = new ArrayList();
            if (orderLstPmDtl1.UserName != orderLstPmDtl2.UserName) resList.Add("UserName");
            if (orderLstPmDtl1.UserCode != orderLstPmDtl2.UserCode) resList.Add("UserCode");
            if (orderLstPmDtl1.SlipNoHead != orderLstPmDtl2.SlipNoHead) resList.Add("SlipNoHead");
            if (orderLstPmDtl1.OrderDate != orderLstPmDtl2.OrderDate) resList.Add("OrderDate");
            if (orderLstPmDtl1.OrderTime != orderLstPmDtl2.OrderTime) resList.Add("OrderTime");
            if (orderLstPmDtl1.ItemCode != orderLstPmDtl2.ItemCode) resList.Add("ItemCode");
            if (orderLstPmDtl1.Msg != orderLstPmDtl2.Msg) resList.Add("Msg");
            if (orderLstPmDtl1.LinkNo != orderLstPmDtl2.LinkNo) resList.Add("LinkNo");
            if (orderLstPmDtl1.OrderGoodsNo != orderLstPmDtl2.OrderGoodsNo) resList.Add("OrderGoodsNo");
            if (orderLstPmDtl1.ShipmGoodsNo != orderLstPmDtl2.ShipmGoodsNo) resList.Add("ShipmGoodsNo");
            if (orderLstPmDtl1.GoodsName != orderLstPmDtl2.GoodsName) resList.Add("GoodsName");
            if (orderLstPmDtl1.ShipmentCnt != orderLstPmDtl2.ShipmentCnt) resList.Add("ShipmentCnt");
            if (orderLstPmDtl1.OrderRemCnt != orderLstPmDtl2.OrderRemCnt) resList.Add("OrderRemCnt");
            if (orderLstPmDtl1.AnswerListPrice != orderLstPmDtl2.AnswerListPrice) resList.Add("AnswerListPrice");
            if (orderLstPmDtl1.SourceShipment != orderLstPmDtl2.SourceShipment) resList.Add("SourceShipment");
            if (orderLstPmDtl1.PlanDate != orderLstPmDtl2.PlanDate) resList.Add("PlanDate");
            if (orderLstPmDtl1.SlipNoDtl != orderLstPmDtl2.SlipNoDtl) resList.Add("SlipNoDtl");
            if (orderLstPmDtl1.Memo != orderLstPmDtl2.Memo) resList.Add("Memo");
            if (orderLstPmDtl1.AnswerSalesUnitCost != orderLstPmDtl2.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");

            return resList;
        }
    }
}

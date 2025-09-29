using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OrderLstInputDtl
	/// <summary>
	///                      �����ꗗ����(�����)�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����ꗗ����(�����)�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OrderLstInputDtl
	{
		/// <summary>���q�l��</summary>
		private String _userName;

		/// <summary>���q�lCD</summary>
		/// <remarks>���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h</remarks>
		private String _userCode;

		/// <summary>�A�C�e��</summary>
		private String _itemCode;

		/// <summary>������</summary>
		private DateTime _orderDate;

		/// <summary>��������</summary>
		private Int32 _orderTime;

		/// <summary>�`�[�ԍ�(�w�b�_�[��)</summary>
		private String _slipNoHead;

		/// <summary>������</summary>
		private String _memo;

		/// <summary>�������i�ԍ�</summary>
		private String _orderGoodsNo;

		/// <summary>�o�ו��i�ԍ�</summary>
		private String _shipmGoodsNo;

		/// <summary>�o�ו��i��</summary>
		private String _goodsName;

		/// <summary>��������</summary>
		private Double _shipmentCnt;

		/// <summary>�����c����</summary>
		private Double _orderRemCnt;

		/// <summary>��]�������i</summary>
		private Double _answerListPrice;

		/// <summary>�o�׌���</summary>
		private String _sourceShipment;

		/// <summary>���͗\���</summary>
		private DateTime _planDate;

		/// <summary>�`�[�ԍ�(���ו�)</summary>
		private String _slipNoDtl;

		/// <summary>�d���ꉿ�i</summary>
		private Double _answerSalesUnitCost;


		/// public propaty name  :  UserName
		/// <summary>���q�l���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���q�l���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String UserName
		{
			get{return _userName;}
			set{_userName = value;}
		}

		/// public propaty name  :  UserCode
		/// <summary>���q�lCD�v���p�e�B</summary>
		/// <value>���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���q�lCD�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String UserCode
		{
			get{return _userCode;}
			set{_userCode = value;}
		}

		/// public propaty name  :  ItemCode
		/// <summary>�A�C�e���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�C�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String ItemCode
		{
			get{return _itemCode;}
			set{_itemCode = value;}
		}

		/// public propaty name  :  OrderDate
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime OrderDate
		{
			get{return _orderDate;}
			set{_orderDate = value;}
		}

		/// public propaty name  :  OrderTime
		/// <summary>�������ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderTime
		{
			get{return _orderTime;}
			set{_orderTime = value;}
		}

		/// public propaty name  :  SlipNoHead
		/// <summary>�`�[�ԍ�(�w�b�_�[��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ�(�w�b�_�[��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String SlipNoHead
		{
			get{return _slipNoHead;}
			set{_slipNoHead = value;}
		}

		/// public propaty name  :  Memo
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String Memo
		{
			get{return _memo;}
			set{_memo = value;}
		}

		/// public propaty name  :  OrderGoodsNo
		/// <summary>�������i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String OrderGoodsNo
		{
			get{return _orderGoodsNo;}
			set{_orderGoodsNo = value;}
		}

		/// public propaty name  :  ShipmGoodsNo
		/// <summary>�o�ו��i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ו��i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String ShipmGoodsNo
		{
			get{return _shipmGoodsNo;}
			set{_shipmGoodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>�o�ו��i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ו��i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>�������ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  OrderRemCnt
		/// <summary>�����c���ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����c���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double OrderRemCnt
		{
			get{return _orderRemCnt;}
			set{_orderRemCnt = value;}
		}

		/// public propaty name  :  AnswerListPrice
		/// <summary>��]�������i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��]�������i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AnswerListPrice
		{
			get{return _answerListPrice;}
			set{_answerListPrice = value;}
		}

		/// public propaty name  :  SourceShipment
		/// <summary>�o�׌����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׌����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String SourceShipment
		{
			get{return _sourceShipment;}
			set{_sourceShipment = value;}
		}

		/// public propaty name  :  PlanDate
		/// <summary>���͗\����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͗\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PlanDate
		{
			get{return _planDate;}
			set{_planDate = value;}
		}

		/// public propaty name  :  SlipNoDtl
		/// <summary>�`�[�ԍ�(���ו�)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ�(���ו�)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String SlipNoDtl
		{
			get{return _slipNoDtl;}
			set{_slipNoDtl = value;}
		}

		/// public propaty name  :  AnswerSalesUnitCost
		/// <summary>�d���ꉿ�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���ꉿ�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double AnswerSalesUnitCost
		{
			get{return _answerSalesUnitCost;}
			set{_answerSalesUnitCost = value;}
		}


		/// <summary>
		/// �����ꗗ����(�����)�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>OrderLstInputDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderLstInputDtl()
		{
		}

		/// <summary>
		/// �����ꗗ����(�����)�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="userName">���q�l��</param>
		/// <param name="userCode">���q�lCD(���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h)</param>
		/// <param name="itemCode">�A�C�e��</param>
		/// <param name="orderDate">������</param>
		/// <param name="orderTime">��������</param>
		/// <param name="slipNoHead">�`�[�ԍ�(�w�b�_�[��)</param>
		/// <param name="memo">������</param>
		/// <param name="orderGoodsNo">�������i�ԍ�</param>
		/// <param name="shipmGoodsNo">�o�ו��i�ԍ�</param>
		/// <param name="goodsName">�o�ו��i��</param>
		/// <param name="shipmentCnt">��������</param>
		/// <param name="orderRemCnt">�����c����</param>
		/// <param name="answerListPrice">��]�������i</param>
		/// <param name="sourceShipment">�o�׌���</param>
		/// <param name="planDate">���͗\���</param>
		/// <param name="slipNoDtl">�`�[�ԍ�(���ו�)</param>
		/// <param name="answerSalesUnitCost">�d���ꉿ�i</param>
		/// <returns>OrderLstInputDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// �����ꗗ����(�����)�N���X��������
		/// </summary>
		/// <returns>OrderLstInputDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OrderLstInputDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OrderLstInputDtl Clone()
		{
			return new OrderLstInputDtl(this._userName,this._userCode,this._itemCode,this._orderDate,this._orderTime,this._slipNoHead,this._memo,this._orderGoodsNo,this._shipmGoodsNo,this._goodsName,this._shipmentCnt,this._orderRemCnt,this._answerListPrice,this._sourceShipment,this._planDate,this._slipNoDtl,this._answerSalesUnitCost);
		}

		/// <summary>
		/// �����ꗗ����(�����)�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�OrderLstInputDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// �����ꗗ����(�����)�N���X��r����
		/// </summary>
		/// <param name="orderLstInputDtl1">
		///                    ��r����OrderLstInputDtl�N���X�̃C���X�^���X
		/// </param>
		/// <param name="orderLstInputDtl2">��r����OrderLstInputDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// �����ꗗ����(�����)�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�OrderLstInputDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// �����ꗗ����(�����)�N���X��r����
		/// </summary>
		/// <param name="orderLstInputDtl1">��r����OrderLstInputDtl�N���X�̃C���X�^���X</param>
		/// <param name="orderLstInputDtl2">��r����OrderLstInputDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OrderLstInputDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
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

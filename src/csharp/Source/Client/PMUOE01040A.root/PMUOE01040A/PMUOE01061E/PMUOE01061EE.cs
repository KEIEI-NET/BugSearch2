using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BuyOutLstDtl
	/// <summary>
	///                      ����ꗗ���׃N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����ꗗ���׃N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BuyOutLstDtl
	{
		/// <summary>�ʔ�</summary>
		private Int32 _no;

		/// <summary>��������</summary>
		private DateTime _orderDate;

		/// <summary>�������</summary>
		private DateTime _buyOutDate;

		/// <summary>����</summary>
		private String _goodsNo;

		/// <summary>�i��</summary>
		private String _goodsName;

		/// <summary>����</summary>
		private Double _shipmentCnt;

		/// <summary>��]�������i</summary>
		private Double _answerListPrice;

		/// <summary>������P��</summary>
		private Double _buyOutCost;

		/// <summary>������z���v</summary>
		private Double _buyOutTotalCost;

		/// <summary>�`�[�ԍ�</summary>
		private String _buyOutSlipNo;

		/// <summary>�������`�[�ԍ�</summary>
		private String _orderSlipNo;

		/// <summary>�R�����g(���L����)</summary>
		/// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
		private String _comment;

		/// <summary>�������P��</summary>
		/// <remarks>�ߒl</remarks>
		private Double _orderCost;

		/// <summary>�X�V����</summary>
		/// <remarks>1:�������� 2:�Y���� 3:���וs��v 9:������ 4:�����X�V������ 5:�����X�V������ 6:�d���f�[�^�쐬 7:�P���ύX</remarks>
		private Int32 _updRsl;


		/// public propaty name  :  No
		/// <summary>�ʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 No
		{
			get{return _no;}
			set{_no = value;}
		}

		/// public propaty name  :  OrderDate
		/// <summary>���������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime OrderDate
		{
			get{return _orderDate;}
			set{_orderDate = value;}
		}

		/// public propaty name  :  BuyOutDate
		/// <summary>��������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime BuyOutDate
		{
			get{return _buyOutDate;}
			set{_buyOutDate = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>���ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>���ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
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

		/// public propaty name  :  BuyOutCost
		/// <summary>������P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BuyOutCost
		{
			get{return _buyOutCost;}
			set{_buyOutCost = value;}
		}

		/// public propaty name  :  BuyOutTotalCost
		/// <summary>������z���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double BuyOutTotalCost
		{
			get{return _buyOutTotalCost;}
			set{_buyOutTotalCost = value;}
		}

		/// public propaty name  :  BuyOutSlipNo
		/// <summary>�`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String BuyOutSlipNo
		{
			get{return _buyOutSlipNo;}
			set{_buyOutSlipNo = value;}
		}

		/// public propaty name  :  OrderSlipNo
		/// <summary>�������`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String OrderSlipNo
		{
			get{return _orderSlipNo;}
			set{_orderSlipNo = value;}
		}

		/// public propaty name  :  Comment
		/// <summary>�R�����g(���L����)�v���p�e�B</summary>
		/// <value>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �R�����g(���L����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  OrderCost
		/// <summary>�������P���v���p�e�B</summary>
		/// <value>�ߒl</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double OrderCost
		{
			get{return _orderCost;}
			set{_orderCost = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>�X�V���ʃv���p�e�B</summary>
		/// <value>1:�������� 2:�Y���� 3:���וs��v 9:������ 4:�����X�V������ 5:�����X�V������ 6:�d���f�[�^�쐬 7:�P���ύX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdRsl
		{
			get{return _updRsl;}
			set{_updRsl = value;}
		}


		/// <summary>
		/// ����ꗗ���׃N���X�R���X�g���N�^
		/// </summary>
		/// <returns>BuyOutLstDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BuyOutLstDtl()
		{
		}

		/// <summary>
		/// ����ꗗ���׃N���X�R���X�g���N�^
		/// </summary>
		/// <param name="no">�ʔ�</param>
		/// <param name="orderDate">��������</param>
		/// <param name="buyOutDate">�������</param>
		/// <param name="goodsNo">����</param>
		/// <param name="goodsName">�i��</param>
		/// <param name="shipmentCnt">����</param>
		/// <param name="answerListPrice">��]�������i</param>
		/// <param name="buyOutCost">������P��</param>
		/// <param name="buyOutTotalCost">������z���v</param>
		/// <param name="buyOutSlipNo">�`�[�ԍ�</param>
		/// <param name="orderSlipNo">�������`�[�ԍ�</param>
		/// <param name="comment">�R�����g(���L����)(�J�^���O�̃R�����g��P�ʁE�J���[���i�[)</param>
		/// <param name="orderCost">�������P��(�ߒl)</param>
		/// <param name="updRsl">�X�V����(1:�������� 2:�Y���� 3:���וs��v 9:������ 4:�����X�V������ 5:�����X�V������ 6:�d���f�[�^�쐬 7:�P���ύX)</param>
		/// <returns>BuyOutLstDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// ����ꗗ���׃N���X��������
		/// </summary>
		/// <returns>BuyOutLstDtl�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BuyOutLstDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BuyOutLstDtl Clone()
		{
			return new BuyOutLstDtl(this._no,this._orderDate,this._buyOutDate,this._goodsNo,this._goodsName,this._shipmentCnt,this._answerListPrice,this._buyOutCost,this._buyOutTotalCost,this._buyOutSlipNo,this._orderSlipNo,this._comment,this._orderCost,this._updRsl);
		}

		/// <summary>
		/// ����ꗗ���׃N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BuyOutLstDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// ����ꗗ���׃N���X��r����
		/// </summary>
		/// <param name="buyOutLstDtl1">
		///                    ��r����BuyOutLstDtl�N���X�̃C���X�^���X
		/// </param>
		/// <param name="buyOutLstDtl2">��r����BuyOutLstDtl�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// ����ꗗ���׃N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BuyOutLstDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
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
		/// ����ꗗ���׃N���X��r����
		/// </summary>
		/// <param name="buyOutLstDtl1">��r����BuyOutLstDtl�N���X�̃C���X�^���X</param>
		/// <param name="buyOutLstDtl2">��r����BuyOutLstDtl�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BuyOutLstDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
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

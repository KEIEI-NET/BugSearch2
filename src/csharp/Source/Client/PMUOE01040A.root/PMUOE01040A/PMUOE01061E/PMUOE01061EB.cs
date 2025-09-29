using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderLstPmDtl
    /// <summary>
    ///                      �����ꗗ����(PM�A��)�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����ꗗ����(PM�A��)�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OrderLstPmDtl
    {
        /// <summary>�̔��X�l��</summary>
        private String _userName;

        /// <summary>�̔��X�l�R�[�h</summary>
        /// <remarks>���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h</remarks>
        private String _userCode;

        /// <summary>�`�[�ԍ�(�w�b�_�[��)</summary>
        private String _slipNoHead;

        /// <summary>������</summary>
        private DateTime _orderDate;

        /// <summary>��������</summary>
        private Int32 _orderTime;

        /// <summary>�A�C�e��</summary>
        private String _itemCode;

        /// <summary>���b�Z�[�W</summary>
        private String _msg;

        /// <summary>��ײݔԍ�(�A�g�ԍ�)</summary>
        private Int32 _linkNo;

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

        /// <summary>������</summary>
        private String _memo;

        /// <summary>�d���ꉿ�i</summary>
        private Double _answerSalesUnitCost;


        /// public propaty name  :  UserName
        /// <summary>�̔��X�l���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��X�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// public propaty name  :  UserCode
        /// <summary>�̔��X�l�R�[�h�v���p�e�B</summary>
        /// <value>���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��X�l�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
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
            get { return _slipNoHead; }
            set { _slipNoHead = value; }
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
            get { return _orderDate; }
            set { _orderDate = value; }
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
            get { return _orderTime; }
            set { _orderTime = value; }
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
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        /// public propaty name  :  Msg
        /// <summary>���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// public propaty name  :  LinkNo
        /// <summary>��ײݔԍ�(�A�g�ԍ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ײݔԍ�(�A�g�ԍ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LinkNo
        {
            get { return _linkNo; }
            set { _linkNo = value; }
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
            get { return _orderGoodsNo; }
            set { _orderGoodsNo = value; }
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
            get { return _shipmGoodsNo; }
            set { _shipmGoodsNo = value; }
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
            get { return _goodsName; }
            set { _goodsName = value; }
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
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
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
            get { return _orderRemCnt; }
            set { _orderRemCnt = value; }
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
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
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
            get { return _sourceShipment; }
            set { _sourceShipment = value; }
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
            get { return _planDate; }
            set { _planDate = value; }
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
            get { return _slipNoDtl; }
            set { _slipNoDtl = value; }
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
            get { return _memo; }
            set { _memo = value; }
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
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }


        /// <summary>
        /// �����ꗗ����(PM�A��)�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>OrderLstPmDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderLstPmDtl()
        {
        }

        /// <summary>
        /// �����ꗗ����(PM�A��)�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="userName">�̔��X�l��</param>
        /// <param name="userCode">�̔��X�l�R�[�h(���̂֔�������ہA���̂��狒�_���Ɋ��蓖�Ă�ꂽ�R�[�h)</param>
        /// <param name="slipNoHead">�`�[�ԍ�(�w�b�_�[��)</param>
        /// <param name="orderDate">������</param>
        /// <param name="orderTime">��������</param>
        /// <param name="itemCode">�A�C�e��</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="linkNo">��ײݔԍ�(�A�g�ԍ�)</param>
        /// <param name="orderGoodsNo">�������i�ԍ�</param>
        /// <param name="shipmGoodsNo">�o�ו��i�ԍ�</param>
        /// <param name="goodsName">�o�ו��i��</param>
        /// <param name="shipmentCnt">��������</param>
        /// <param name="orderRemCnt">�����c����</param>
        /// <param name="answerListPrice">��]�������i</param>
        /// <param name="sourceShipment">�o�׌���</param>
        /// <param name="planDate">���͗\���</param>
        /// <param name="slipNoDtl">�`�[�ԍ�(���ו�)</param>
        /// <param name="memo">������</param>
        /// <param name="answerSalesUnitCost">�d���ꉿ�i</param>
        /// <returns>OrderLstPmDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
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
        /// �����ꗗ����(PM�A��)�N���X��������
        /// </summary>
        /// <returns>OrderLstPmDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OrderLstPmDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OrderLstPmDtl Clone()
        {
            return new OrderLstPmDtl(this._userName, this._userCode, this._slipNoHead, this._orderDate, this._orderTime, this._itemCode, this._msg, this._linkNo, this._orderGoodsNo, this._shipmGoodsNo, this._goodsName, this._shipmentCnt, this._orderRemCnt, this._answerListPrice, this._sourceShipment, this._planDate, this._slipNoDtl, this._memo, this._answerSalesUnitCost);
        }

        /// <summary>
        /// �����ꗗ����(PM�A��)�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OrderLstPmDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
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
        /// �����ꗗ����(PM�A��)�N���X��r����
        /// </summary>
        /// <param name="orderLstPmDtl1">
        ///                    ��r����OrderLstPmDtl�N���X�̃C���X�^���X
        /// </param>
        /// <param name="orderLstPmDtl2">��r����OrderLstPmDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
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
        /// �����ꗗ����(PM�A��)�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OrderLstPmDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
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
        /// �����ꗗ����(PM�A��)�N���X��r����
        /// </summary>
        /// <param name="orderLstPmDtl1">��r����OrderLstPmDtl�N���X�̃C���X�^���X</param>
        /// <param name="orderLstPmDtl2">��r����OrderLstPmDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OrderLstPmDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
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

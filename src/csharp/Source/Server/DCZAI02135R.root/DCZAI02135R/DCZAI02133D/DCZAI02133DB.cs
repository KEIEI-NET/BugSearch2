using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockShipArrivalListWork
    /// <summary>
    ///                      �݌ɓ��o�׈ꗗ�\�����[�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɓ��o�׈ꗗ�\�����[�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockShipArrivalListWork 
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�݌ɓo�^��</summary>
        private DateTime _stockCreateDate;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�݌ɔ�����R�[�h</remarks>
        private Int32 _stockSupplierCode;

        /// <summary>���o�א�1</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt1;

        /// <summary>�����א�1</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt1;

        /// <summary>���o�א�2</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt2;

        /// <summary>�����א�2</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt2;

        /// <summary>���o�א�3</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt3;

        /// <summary>�����א�3</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt3;

        /// <summary>���o�א�4</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt4;

        /// <summary>�����א�4</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt4;

        /// <summary>���o�א�5</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt5;

        /// <summary>�����א�5</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt5;

        /// <summary>���o�א�6</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt6;

        /// <summary>�����א�6</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt6;

        /// <summary>���o�א�7</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt7;

        /// <summary>�����א�7</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt7;

        /// <summary>���o�א�8</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt8;

        /// <summary>�����א�8</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt8;

        /// <summary>���o�א�9</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt9;

        /// <summary>�����א�9</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt9;

        /// <summary>���o�א�10</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt10;

        /// <summary>�����א�10</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt10;

        /// <summary>���o�א�11</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt11;

        /// <summary>�����א�11</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt11;

        /// <summary>���o�א�12</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _shipmentCnt12;

        /// <summary>�����א�12</summary>
        /// <remarks>�݌ɗ����f�[�^���擾</remarks>
        private Double _arrivalCnt12;

        /// <summary>���Ϗo�א�</summary>
        private Double _aVG_ShipmentCnt;

        /// <summary>���ϓ��א�</summary>
        private Double _aVG_ArrivalCnt;

        /// <summary>���v�o�א�</summary>
        private Double _sUM_ShipmentCnt;

        /// <summary>���v���א�</summary>
        private Double _sUM_ArrivalCnt;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i�敪</summary>
        private Int32 _enterpriseGanreCode;


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  StockSupplierCode
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�݌ɔ�����R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSupplierCode
        {
            get { return _stockSupplierCode; }
            set { _stockSupplierCode = value; }
        }

        /// public propaty name  :  ShipmentCnt1
        /// <summary>���o�א�1�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt1
        {
            get { return _shipmentCnt1; }
            set { _shipmentCnt1 = value; }
        }

        /// public propaty name  :  ArrivalCnt1
        /// <summary>�����א�1�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt1
        {
            get { return _arrivalCnt1; }
            set { _arrivalCnt1 = value; }
        }

        /// public propaty name  :  ShipmentCnt2
        /// <summary>���o�א�2�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt2
        {
            get { return _shipmentCnt2; }
            set { _shipmentCnt2 = value; }
        }

        /// public propaty name  :  ArrivalCnt2
        /// <summary>�����א�2�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt2
        {
            get { return _arrivalCnt2; }
            set { _arrivalCnt2 = value; }
        }

        /// public propaty name  :  ShipmentCnt3
        /// <summary>���o�א�3�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt3
        {
            get { return _shipmentCnt3; }
            set { _shipmentCnt3 = value; }
        }

        /// public propaty name  :  ArrivalCnt3
        /// <summary>�����א�3�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt3
        {
            get { return _arrivalCnt3; }
            set { _arrivalCnt3 = value; }
        }

        /// public propaty name  :  ShipmentCnt4
        /// <summary>���o�א�4�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt4
        {
            get { return _shipmentCnt4; }
            set { _shipmentCnt4 = value; }
        }

        /// public propaty name  :  ArrivalCnt4
        /// <summary>�����א�4�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt4
        {
            get { return _arrivalCnt4; }
            set { _arrivalCnt4 = value; }
        }

        /// public propaty name  :  ShipmentCnt5
        /// <summary>���o�א�5�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt5
        {
            get { return _shipmentCnt5; }
            set { _shipmentCnt5 = value; }
        }

        /// public propaty name  :  ArrivalCnt5
        /// <summary>�����א�5�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt5
        {
            get { return _arrivalCnt5; }
            set { _arrivalCnt5 = value; }
        }

        /// public propaty name  :  ShipmentCnt6
        /// <summary>���o�א�6�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt6
        {
            get { return _shipmentCnt6; }
            set { _shipmentCnt6 = value; }
        }

        /// public propaty name  :  ArrivalCnt6
        /// <summary>�����א�6�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt6
        {
            get { return _arrivalCnt6; }
            set { _arrivalCnt6 = value; }
        }

        /// public propaty name  :  ShipmentCnt7
        /// <summary>���o�א�7�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt7
        {
            get { return _shipmentCnt7; }
            set { _shipmentCnt7 = value; }
        }

        /// public propaty name  :  ArrivalCnt7
        /// <summary>�����א�7�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt7
        {
            get { return _arrivalCnt7; }
            set { _arrivalCnt7 = value; }
        }

        /// public propaty name  :  ShipmentCnt8
        /// <summary>���o�א�8�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt8
        {
            get { return _shipmentCnt8; }
            set { _shipmentCnt8 = value; }
        }

        /// public propaty name  :  ArrivalCnt8
        /// <summary>�����א�8�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt8
        {
            get { return _arrivalCnt8; }
            set { _arrivalCnt8 = value; }
        }

        /// public propaty name  :  ShipmentCnt9
        /// <summary>���o�א�9�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt9
        {
            get { return _shipmentCnt9; }
            set { _shipmentCnt9 = value; }
        }

        /// public propaty name  :  ArrivalCnt9
        /// <summary>�����א�9�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt9
        {
            get { return _arrivalCnt9; }
            set { _arrivalCnt9 = value; }
        }

        /// public propaty name  :  ShipmentCnt10
        /// <summary>���o�א�10�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt10
        {
            get { return _shipmentCnt10; }
            set { _shipmentCnt10 = value; }
        }

        /// public propaty name  :  ArrivalCnt10
        /// <summary>�����א�10�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt10
        {
            get { return _arrivalCnt10; }
            set { _arrivalCnt10 = value; }
        }

        /// public propaty name  :  ShipmentCnt11
        /// <summary>���o�א�11�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt11
        {
            get { return _shipmentCnt11; }
            set { _shipmentCnt11 = value; }
        }

        /// public propaty name  :  ArrivalCnt11
        /// <summary>�����א�11�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt11
        {
            get { return _arrivalCnt11; }
            set { _arrivalCnt11 = value; }
        }

        /// public propaty name  :  ShipmentCnt12
        /// <summary>���o�א�12�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�א�12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt12
        {
            get { return _shipmentCnt12; }
            set { _shipmentCnt12 = value; }
        }

        /// public propaty name  :  ArrivalCnt12
        /// <summary>�����א�12�v���p�e�B</summary>
        /// <value>�݌ɗ����f�[�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����א�12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt12
        {
            get { return _arrivalCnt12; }
            set { _arrivalCnt12 = value; }
        }

        /// public propaty name  :  AVG_ShipmentCnt
        /// <summary>���Ϗo�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗo�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AVG_ShipmentCnt
        {
            get { return _aVG_ShipmentCnt; }
            set { _aVG_ShipmentCnt = value; }
        }

        /// public propaty name  :  AVG_ArrivalCnt
        /// <summary>���ϓ��א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϓ��א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AVG_ArrivalCnt
        {
            get { return _aVG_ArrivalCnt; }
            set { _aVG_ArrivalCnt = value; }
        }

        /// public propaty name  :  SUM_ShipmentCnt
        /// <summary>���v�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SUM_ShipmentCnt
        {
            get { return _sUM_ShipmentCnt; }
            set { _sUM_ShipmentCnt = value; }
        }

        /// public propaty name  :  SUM_ArrivalCnt
        /// <summary>���v���א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SUM_ArrivalCnt
        {
            get { return _sUM_ArrivalCnt; }
            set { _sUM_ArrivalCnt = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }


        /// <summary>
        /// �݌ɓ��o�׈ꗗ�\�����[�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockShipArrivalListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockShipArrivalListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockShipArrivalListWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockShipArrivalListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockShipArrivalListWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockShipArrivalListWork || graph is ArrayList || graph is StockShipArrivalListWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockShipArrivalListWork).FullName));

            if (graph != null && graph is StockShipArrivalListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockShipArrivalListWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockShipArrivalListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockShipArrivalListWork[])graph).Length;
            }
            else if (graph is StockShipArrivalListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�݌ɓo�^��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCreateDate
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSupplierCode
            //���o�א�1
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt1
            //�����א�1
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt1
            //���o�א�2
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt2
            //�����א�2
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt2
            //���o�א�3
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt3
            //�����א�3
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt3
            //���o�א�4
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt4
            //�����א�4
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt4
            //���o�א�5
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt5
            //�����א�5
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt5
            //���o�א�6
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt6
            //�����א�6
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt6
            //���o�א�7
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt7
            //�����א�7
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt7
            //���o�א�8
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt8
            //�����א�8
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt8
            //���o�א�9
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt9
            //�����א�9
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt9
            //���o�א�10
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt10
            //�����א�10
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt10
            //���o�א�11
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt11
            //�����א�11
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt11
            //���o�א�12
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt12
            //�����א�12
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt12
            //���Ϗo�א�
            serInfo.MemberInfo.Add(typeof(Double)); //AVG_ShipmentCnt
            //���ϓ��א�
            serInfo.MemberInfo.Add(typeof(Double)); //AVG_ArrivalCnt
            //���v�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //SUM_ShipmentCnt
            //���v���א�
            serInfo.MemberInfo.Add(typeof(Double)); //SUM_ArrivalCnt
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode


            serInfo.Serialize(writer, serInfo);
            if (graph is StockShipArrivalListWork)
            {
                StockShipArrivalListWork temp = (StockShipArrivalListWork)graph;

                SetStockShipArrivalListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockShipArrivalListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockShipArrivalListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockShipArrivalListWork temp in lst)
                {
                    SetStockShipArrivalListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockShipArrivalListWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  StockShipArrivalListWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockShipArrivalListWork(System.IO.BinaryWriter writer, StockShipArrivalListWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�I��
            writer.Write(temp.WarehouseShelfNo);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�d����R�[�h
            writer.Write(temp.StockSupplierCode);
            //���o�א�1
            writer.Write(temp.ShipmentCnt1);
            //�����א�1
            writer.Write(temp.ArrivalCnt1);
            //���o�א�2
            writer.Write(temp.ShipmentCnt2);
            //�����א�2
            writer.Write(temp.ArrivalCnt2);
            //���o�א�3
            writer.Write(temp.ShipmentCnt3);
            //�����א�3
            writer.Write(temp.ArrivalCnt3);
            //���o�א�4
            writer.Write(temp.ShipmentCnt4);
            //�����א�4
            writer.Write(temp.ArrivalCnt4);
            //���o�א�5
            writer.Write(temp.ShipmentCnt5);
            //�����א�5
            writer.Write(temp.ArrivalCnt5);
            //���o�א�6
            writer.Write(temp.ShipmentCnt6);
            //�����א�6
            writer.Write(temp.ArrivalCnt6);
            //���o�א�7
            writer.Write(temp.ShipmentCnt7);
            //�����א�7
            writer.Write(temp.ArrivalCnt7);
            //���o�א�8
            writer.Write(temp.ShipmentCnt8);
            //�����א�8
            writer.Write(temp.ArrivalCnt8);
            //���o�א�9
            writer.Write(temp.ShipmentCnt9);
            //�����א�9
            writer.Write(temp.ArrivalCnt9);
            //���o�א�10
            writer.Write(temp.ShipmentCnt10);
            //�����א�10
            writer.Write(temp.ArrivalCnt10);
            //���o�א�11
            writer.Write(temp.ShipmentCnt11);
            //�����א�11
            writer.Write(temp.ArrivalCnt11);
            //���o�א�12
            writer.Write(temp.ShipmentCnt12);
            //�����א�12
            writer.Write(temp.ArrivalCnt12);
            //���Ϗo�א�
            writer.Write(temp.AVG_ShipmentCnt);
            //���ϓ��א�
            writer.Write(temp.AVG_ArrivalCnt);
            //���v�o�א�
            writer.Write(temp.SUM_ShipmentCnt);
            //���v���א�
            writer.Write(temp.SUM_ArrivalCnt);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i�敪
            writer.Write(temp.EnterpriseGanreCode);

        }

        /// <summary>
        ///  StockShipArrivalListWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockShipArrivalListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockShipArrivalListWork GetStockShipArrivalListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockShipArrivalListWork temp = new StockShipArrivalListWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�I��
            temp.WarehouseShelfNo = reader.ReadString();
            //�݌ɓo�^��
            temp.StockCreateDate = new DateTime(reader.ReadInt64());
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�d����R�[�h
            temp.StockSupplierCode = reader.ReadInt32();
            //���o�א�1
            temp.ShipmentCnt1 = reader.ReadDouble();
            //�����א�1
            temp.ArrivalCnt1 = reader.ReadDouble();
            //���o�א�2
            temp.ShipmentCnt2 = reader.ReadDouble();
            //�����א�2
            temp.ArrivalCnt2 = reader.ReadDouble();
            //���o�א�3
            temp.ShipmentCnt3 = reader.ReadDouble();
            //�����א�3
            temp.ArrivalCnt3 = reader.ReadDouble();
            //���o�א�4
            temp.ShipmentCnt4 = reader.ReadDouble();
            //�����א�4
            temp.ArrivalCnt4 = reader.ReadDouble();
            //���o�א�5
            temp.ShipmentCnt5 = reader.ReadDouble();
            //�����א�5
            temp.ArrivalCnt5 = reader.ReadDouble();
            //���o�א�6
            temp.ShipmentCnt6 = reader.ReadDouble();
            //�����א�6
            temp.ArrivalCnt6 = reader.ReadDouble();
            //���o�א�7
            temp.ShipmentCnt7 = reader.ReadDouble();
            //�����א�7
            temp.ArrivalCnt7 = reader.ReadDouble();
            //���o�א�8
            temp.ShipmentCnt8 = reader.ReadDouble();
            //�����א�8
            temp.ArrivalCnt8 = reader.ReadDouble();
            //���o�א�9
            temp.ShipmentCnt9 = reader.ReadDouble();
            //�����א�9
            temp.ArrivalCnt9 = reader.ReadDouble();
            //���o�א�10
            temp.ShipmentCnt10 = reader.ReadDouble();
            //�����א�10
            temp.ArrivalCnt10 = reader.ReadDouble();
            //���o�א�11
            temp.ShipmentCnt11 = reader.ReadDouble();
            //�����א�11
            temp.ArrivalCnt11 = reader.ReadDouble();
            //���o�א�12
            temp.ShipmentCnt12 = reader.ReadDouble();
            //�����א�12
            temp.ArrivalCnt12 = reader.ReadDouble();
            //���Ϗo�א�
            temp.AVG_ShipmentCnt = reader.ReadDouble();
            //���ϓ��א�
            temp.AVG_ArrivalCnt = reader.ReadDouble();
            //���v�o�א�
            temp.SUM_ShipmentCnt = reader.ReadDouble();
            //���v���א�
            temp.SUM_ArrivalCnt = reader.ReadDouble();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i�敪
            temp.EnterpriseGanreCode = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>StockShipArrivalListWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockShipArrivalListWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockShipArrivalListWork temp = GetStockShipArrivalListWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StockShipArrivalListWork[])lst.ToArray(typeof(StockShipArrivalListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

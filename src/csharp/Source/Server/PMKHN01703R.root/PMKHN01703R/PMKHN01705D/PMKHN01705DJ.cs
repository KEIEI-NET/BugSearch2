using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipmentChangeWork
    /// <summary>
    ///                      �ݏo�ϊ������������ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ݏo�ϊ������������ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2015/02/03  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipmentChangeWork
    {
        /// <summary>�X�V����</summary>
        private DateTime _updateDateTime;

        /// <summary>�ϊ��㏤�i�ԍ�</summary>
        private string _newGoodsNo = "";

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>���i�ԍ�</summary>
        private string _oldGoodsNo = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p</summary>
        private string _bLGoodsFullName = "";

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        private Double _listPriceTaxExcFl;

        /// <summary>�����P��</summary>
        private Double _salesUnitCost;

        /// <summary>����</summary>
        private Int64 _cost;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�d����R�[�h </summary>
        private Int32 _supplierCd;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�d���݌ɐ�</summary>
        private Double _supplierStock;

        /// <summary>�󒍐�</summary>
        private Double _acpOdrCount;

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�ړ����d���݌ɐ�</summary>
        private Double _movingSupliStock;

        /// <summary>�o�א��i���v��j</summary>
        private Double _shipmentNoAddCnt;

        /// <summary>���א��i���v��j</summary>
        private Double _arrivalCnt;

        /// <summary>�o�׉\��</summary>
        private Double _shipmentPosCnt;

        /// <summary>���b�Z�[�W</summary>
        private string _message = "";


        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  NewGoodsNo
        /// <summary>�ϊ��㏤�i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��㏤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewGoodsNo
        {
            get { return _newGoodsNo; }
            set { _newGoodsNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  OldGoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

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

        /// public propaty name  :  SectionGuideNmRF
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

        /// public propaty name  :  SupplierStock
        /// <summary>�d���݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierStock
        {
            get { return _supplierStock; }
            set { _supplierStock = value; }
        }

        /// public propaty name  :  AcpOdrCount
        /// <summary>�󒍐��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcpOdrCount
        {
            get { return _acpOdrCount; }
            set { _acpOdrCount = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  MovingSupliStock
        /// <summary>�ړ����d���݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����d���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MovingSupliStock
        {
            get { return _movingSupliStock; }
            set { _movingSupliStock = value; }
        }

        /// public propaty name  :  ShipmentNoAddCnt
        /// <summary>�o�א��i���v��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentNoAddCnt
        {
            get { return _shipmentNoAddCnt; }
            set { _shipmentNoAddCnt = value; }
        }

        /// public propaty name  :  ArrivalCnt
        /// <summary>���א��i���v��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���א��i���v��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ArrivalCnt
        {
            get { return _arrivalCnt; }
            set { _arrivalCnt = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  Message
        /// <summary>���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        /// <summary>
        /// �ݏo�ϊ������������ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ShipmentChangeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipmentChangeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ShipmentChangeWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ShipmentChangeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipmentChangeWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipmentChangeWork || graph is ArrayList || graph is ShipmentChangeWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ShipmentChangeWork).FullName));

            if (graph != null && graph is ShipmentChangeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipmentChangeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipmentChangeWork[])graph).Length;
            }
            else if (graph is ShipmentChangeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�ϊ��㏤�i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //NewGoodsNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //���㖾�גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //SupplierStock
            //�󒍐�
            serInfo.MemberInfo.Add(typeof(Double)); //AcpOdrCount
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�ړ����d���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MovingSupliStock
            //�o�א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentNoAddCnt
            //���א��i���v��j
            serInfo.MemberInfo.Add(typeof(Double)); //ArrivalCnt
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //Message


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipmentChangeWork)
            {
                ShipmentChangeWork temp = (ShipmentChangeWork)graph;

                SetShipmentChangeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipmentChangeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipmentChangeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipmentChangeWork temp in lst)
                {
                    SetShipmentChangeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipmentChangeWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  ShipmentChangeWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetShipmentChangeWork(System.IO.BinaryWriter writer, ShipmentChangeWork temp)
        {
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�ϊ��㏤�i�ԍ�
            writer.Write(temp.NewGoodsNo);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //���i�ԍ�
            writer.Write(temp.OldGoodsNo);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //���㖾�גʔ�
            writer.Write(temp.SalesSlipDtlNum);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i����
            writer.Write(temp.GoodsName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p
            writer.Write(temp.BLGoodsFullName);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //����
            writer.Write(temp.Cost);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�d���݌ɐ�
            writer.Write(temp.SupplierStock);
            //�󒍐�
            writer.Write(temp.AcpOdrCount);
            //������
            writer.Write(temp.SalesOrderCount);
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�א��i���v��j
            writer.Write(temp.ShipmentNoAddCnt);
            //���א��i���v��j
            writer.Write(temp.ArrivalCnt);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //���b�Z�[�W
            writer.Write(temp.Message);

        }

        /// <summary>
        ///  ShipmentChangeWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ShipmentChangeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ShipmentChangeWork GetShipmentChangeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ShipmentChangeWork temp = new ShipmentChangeWork();

            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�ϊ��㏤�i�ԍ�
            temp.NewGoodsNo = reader.ReadString();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //���i�ԍ�
            temp.OldGoodsNo = reader.ReadString();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //���㖾�גʔ�
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p
            temp.BLGoodsFullName = reader.ReadString();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //����
            temp.Cost = reader.ReadInt64();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�d���݌ɐ�
            temp.SupplierStock = reader.ReadDouble();
            //�󒍐�
            temp.AcpOdrCount = reader.ReadDouble();
            //������
            temp.SalesOrderCount = reader.ReadDouble();
            //�ړ����d���݌ɐ�
            temp.MovingSupliStock = reader.ReadDouble();
            //�o�א��i���v��j
            temp.ShipmentNoAddCnt = reader.ReadDouble();
            //���א��i���v��j
            temp.ArrivalCnt = reader.ReadDouble();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //���b�Z�[�W
            temp.Message = reader.ReadString();


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
        /// <returns>ShipmentChangeWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentChangeWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipmentChangeWork temp = GetShipmentChangeWork(reader, serInfo);
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
                    retValue = (ShipmentChangeWork[])lst.ToArray(typeof(ShipmentChangeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

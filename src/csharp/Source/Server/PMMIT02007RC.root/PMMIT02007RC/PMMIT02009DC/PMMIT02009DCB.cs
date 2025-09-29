//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ʌ��Ϗ��E�I���\
// �v���O�����T�v   : ���Ӑ�ʌ��Ϗ��E�I���\���o���ʃ��[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970531-00  �쐬�S�� : songg
// �� �� ��  K2013/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TakekawaQuotaInventResultWork
    /// <summary>
    ///                      ���Ӑ�ʌ��Ϗ��E�I���\���o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ʌ��Ϗ��E�I���\���o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2014/01/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TakekawaQuotaInventResultWork
    {
        /// <summary>�������t</summary>
        private string _oprDate = "";

        /// <summary>���_����</summary>
        private string _sectionNm = "";

        /// <summary>�h��</summary>
        private string _honorificTtl = "";

        /// <summary>���_�X�֔ԍ�</summary>
        private string _sectionPostNo = "";

        /// <summary>���_�Z��1</summary>
        private string _sectionAddress1 = "";

        /// <summary>���_�Z��2</summary>
        private string _sectionAddress2 = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseNm = "";

        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>�i��</summary>
        private string _goodsName = "";

        /// <summary>�艿</summary>
        private Double _listPrice;

        /// <summary>�P��</summary>
        private Double _salesUnitCost;

        /// <summary>�݌ɐ���</summary>
        private Double _stockCnt;

        /// <summary>���z</summary>
        private Double _money;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��1</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�I���݌ɐ�</summary>
        /// <remarks>�I����</remarks>
        private Double _inventoryStockCnt;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�������ނ��Z�b�g����</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>���Ӑ�̔���P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>���Ӑ�̔������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>������̓��Ӑ����œ]�ŕ����Q�Ƌ敪</summary>
        /// <remarks>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����|��</summary>
        private Double _salesRateVal;


        /// public propaty name  :  OprDate
        /// <summary>�������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OprDate
        {
            get { return _oprDate; }
            set { _oprDate = value; }
        }

        /// public propaty name  :  SectionNm
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  HonorificTtl
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTtl
        {
            get { return _honorificTtl; }
            set { _honorificTtl = value; }
        }

        /// public propaty name  :  SectionPostNo
        /// <summary>���_�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionPostNo
        {
            get { return _sectionPostNo; }
            set { _sectionPostNo = value; }
        }

        /// public propaty name  :  SectionAddress1
        /// <summary>���_�Z��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�Z��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionAddress1
        {
            get { return _sectionAddress1; }
            set { _sectionAddress1 = value; }
        }

        /// public propaty name  :  SectionAddress2
        /// <summary>���_�Z��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�Z��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionAddress2
        {
            get { return _sectionAddress2; }
            set { _sectionAddress2 = value; }
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

        /// public propaty name  :  WarehouseNm
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNm
        {
            get { return _warehouseNm; }
            set { _warehouseNm = value; }
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

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  StockCnt
        /// <summary>�݌ɐ��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCnt
        {
            get { return _stockCnt; }
            set { _stockCnt = value; }
        }

        /// public propaty name  :  Money
        /// <summary>���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Money
        {
            get { return _money; }
            set { _money = value; }
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

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  InventoryStockCnt
        /// <summary>�I���݌ɐ��v���p�e�B</summary>
        /// <value>�I����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InventoryStockCnt
        {
            get { return _inventoryStockCnt; }
            set { _inventoryStockCnt = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�������ނ��Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>���Ӑ�̔���P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�̔���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>���Ӑ�̔������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�̔������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>������̓��Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�ŗ��ݒ�}�X�^���Q�Ɓ@1:���Ӑ�}�X�^���Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������̓��Ӑ����œ]�ŕ����Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  SalesRateVal
        /// <summary>����|���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRateVal
        {
            get { return _salesRateVal; }
            set { _salesRateVal = value; }
        }


        /// <summary>
        /// ���Ӑ�ʌ��Ϗ��E�I���\���o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TakekawaQuotaInventResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TakekawaQuotaInventResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TakekawaQuotaInventResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TakekawaQuotaInventResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TakekawaQuotaInventResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TakekawaQuotaInventResultWork || graph is ArrayList || graph is TakekawaQuotaInventResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TakekawaQuotaInventResultWork).FullName));

            if (graph != null && graph is TakekawaQuotaInventResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TakekawaQuotaInventResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TakekawaQuotaInventResultWork[])graph).Length;
            }
            else if (graph is TakekawaQuotaInventResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�������t
            serInfo.MemberInfo.Add(typeof(string)); //OprDate
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionNm
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTtl
            //���_�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SectionPostNo
            //���_�Z��1
            serInfo.MemberInfo.Add(typeof(string)); //SectionAddress1
            //���_�Z��2
            serInfo.MemberInfo.Add(typeof(string)); //SectionAddress2
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNm
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�艿
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�݌ɐ���
            serInfo.MemberInfo.Add(typeof(Double)); //StockCnt
            //���z
            serInfo.MemberInfo.Add(typeof(Double)); //Money
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��1
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�I���݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //InventoryStockCnt
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //���Ӑ�̔���P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //���Ӑ�̔������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //������̓��Ӑ����œ]�ŕ����Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustCTaXLayRefCd
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //����|��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRateVal


            serInfo.Serialize(writer, serInfo);
            if (graph is TakekawaQuotaInventResultWork)
            {
                TakekawaQuotaInventResultWork temp = (TakekawaQuotaInventResultWork)graph;

                SetTakekawaQuotaInventResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TakekawaQuotaInventResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TakekawaQuotaInventResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TakekawaQuotaInventResultWork temp in lst)
                {
                    SetTakekawaQuotaInventResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TakekawaQuotaInventResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 32;

        /// <summary>
        ///  TakekawaQuotaInventResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTakekawaQuotaInventResultWork(System.IO.BinaryWriter writer, TakekawaQuotaInventResultWork temp)
        {
            //�������t
            writer.Write(temp.OprDate);
            //���_����
            writer.Write(temp.SectionNm);
            //�h��
            writer.Write(temp.HonorificTtl);
            //���_�X�֔ԍ�
            writer.Write(temp.SectionPostNo);
            //���_�Z��1
            writer.Write(temp.SectionAddress1);
            //���_�Z��2
            writer.Write(temp.SectionAddress2);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseNm);
            //�I��
            writer.Write(temp.WarehouseShelfNo);
            //�i��
            writer.Write(temp.GoodsNo);
            //�i��
            writer.Write(temp.GoodsName);
            //�艿
            writer.Write(temp.ListPrice);
            //�P��
            writer.Write(temp.SalesUnitCost);
            //�݌ɐ���
            writer.Write(temp.StockCnt);
            //���z
            writer.Write(temp.Money);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��1
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�I���݌ɐ�
            writer.Write(temp.InventoryStockCnt);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //���Ӑ�̔���P���[�������R�[�h
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //���Ӑ�̔������Œ[�������R�[�h
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //������̓��Ӑ����œ]�ŕ����Q�Ƌ敪
            writer.Write(temp.CustCTaXLayRefCd);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //����|��
            writer.Write(temp.SalesRateVal);

        }

        /// <summary>
        ///  TakekawaQuotaInventResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TakekawaQuotaInventResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TakekawaQuotaInventResultWork GetTakekawaQuotaInventResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TakekawaQuotaInventResultWork temp = new TakekawaQuotaInventResultWork();

            //�������t
            temp.OprDate = reader.ReadString();
            //���_����
            temp.SectionNm = reader.ReadString();
            //�h��
            temp.HonorificTtl = reader.ReadString();
            //���_�X�֔ԍ�
            temp.SectionPostNo = reader.ReadString();
            //���_�Z��1
            temp.SectionAddress1 = reader.ReadString();
            //���_�Z��2
            temp.SectionAddress2 = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseNm = reader.ReadString();
            //�I��
            temp.WarehouseShelfNo = reader.ReadString();
            //�i��
            temp.GoodsNo = reader.ReadString();
            //�i��
            temp.GoodsName = reader.ReadString();
            //�艿
            temp.ListPrice = reader.ReadDouble();
            //�P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�݌ɐ���
            temp.StockCnt = reader.ReadDouble();
            //���z
            temp.Money = reader.ReadDouble();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��1
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�I���݌ɐ�
            temp.InventoryStockCnt = reader.ReadDouble();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //���Ӑ�̔���P���[�������R�[�h
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //���Ӑ�̔������Œ[�������R�[�h
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //������̓��Ӑ����œ]�ŕ����Q�Ƌ敪
            temp.CustCTaXLayRefCd = reader.ReadInt32();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //����|��
            temp.SalesRateVal = reader.ReadDouble();


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
        /// <returns>TakekawaQuotaInventResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TakekawaQuotaInventResultWork temp = GetTakekawaQuotaInventResultWork(reader, serInfo);
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
                    retValue = (TakekawaQuotaInventResultWork[])lst.ToArray(typeof(TakekawaQuotaInventResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }






}


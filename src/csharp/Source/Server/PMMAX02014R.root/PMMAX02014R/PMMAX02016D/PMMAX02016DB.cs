//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O�����T�v   : �o�i�ꊇ�X�V���o���ʃ��[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : �v��
// �� �� ��  2016/01/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockUpdateResultWork
    /// <summary>
    ///                      �o�i�ꊇ�X�V���o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�i�ꊇ�X�V���o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2016/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockUpdateResultWork
    {
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseNm = "";

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>�i��</summary>
        private string _goodsName = "";

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

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�������ނ��Z�b�g����</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>���Ӑ�̔���P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>���Ӑ�̔������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>����|��</summary>
        private Double _salesRateVal;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>�艿</summary>
        private Double _listPrice;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>���i�}�X�^�̌����P��</summary>
        private Double _gpuSalesUnitCost;


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

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
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

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
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

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
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

        /// public propaty name  :  GpuSalesUnitCost
        /// <summary>���i�}�X�^�̌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�̌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GpuSalesUnitCost
        {
            get { return _gpuSalesUnitCost; }
            set { _gpuSalesUnitCost = value; }
        }


        /// <summary>
        /// �o�i�ꊇ�X�V���o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsMaxStockUpdateResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsMaxStockUpdateResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsMaxStockUpdateResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsMaxStockUpdateResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsMaxStockUpdateResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsMaxStockUpdateResultWork || graph is ArrayList || graph is PartsMaxStockUpdateResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsMaxStockUpdateResultWork).FullName));

            if (graph != null && graph is PartsMaxStockUpdateResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockUpdateResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsMaxStockUpdateResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsMaxStockUpdateResultWork[])graph).Length;
            }
            else if (graph is PartsMaxStockUpdateResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNm
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
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
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�̔���P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //���Ӑ�̔������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //����|��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRateVal
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //�艿
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //���i�}�X�^�̌����P��
            serInfo.MemberInfo.Add(typeof(Double)); //GpuSalesUnitCost


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsMaxStockUpdateResultWork)
            {
                PartsMaxStockUpdateResultWork temp = (PartsMaxStockUpdateResultWork)graph;

                SetPartsMaxStockUpdateResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsMaxStockUpdateResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsMaxStockUpdateResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsMaxStockUpdateResultWork temp in lst)
                {
                    SetPartsMaxStockUpdateResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsMaxStockUpdateResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  PartsMaxStockUpdateResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsMaxStockUpdateResultWork(System.IO.BinaryWriter writer, PartsMaxStockUpdateResultWork temp)
        {
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseNm);
            //�i��
            writer.Write(temp.GoodsNo);
            //�i��
            writer.Write(temp.GoodsName);
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
            //���[�J�[����
            writer.Write(temp.MakerName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�̔���P���[�������R�[�h
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //���Ӑ�̔������Œ[�������R�[�h
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //����|��
            writer.Write(temp.SalesRateVal);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //�艿
            writer.Write(temp.ListPrice);
            //�d����
            writer.Write(temp.StockRate);
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //�X�V�N����
            writer.Write(temp.UpdateDate);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //���i�}�X�^�̌����P��
            writer.Write(temp.GpuSalesUnitCost);

        }

        /// <summary>
        ///  PartsMaxStockUpdateResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsMaxStockUpdateResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsMaxStockUpdateResultWork GetPartsMaxStockUpdateResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsMaxStockUpdateResultWork temp = new PartsMaxStockUpdateResultWork();

            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseNm = reader.ReadString();
            //�i��
            temp.GoodsNo = reader.ReadString();
            //�i��
            temp.GoodsName = reader.ReadString();
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
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�̔���P���[�������R�[�h
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //���Ӑ�̔������Œ[�������R�[�h
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //����|��
            temp.SalesRateVal = reader.ReadDouble();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //�艿
            temp.ListPrice = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //�X�V�N����
            temp.UpdateDate = reader.ReadInt32();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //���i�}�X�^�̌����P��
            temp.GpuSalesUnitCost = reader.ReadDouble();


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
        /// <returns>PartsMaxStockUpdateResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockUpdateResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsMaxStockUpdateResultWork temp = GetPartsMaxStockUpdateResultWork(reader, serInfo);
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
                    retValue = (PartsMaxStockUpdateResultWork[])lst.ToArray(typeof(PartsMaxStockUpdateResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ���o���ʃN���X���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockRetPlnList
    /// <summary>
    ///                      �d���ԕi�\��ꗗ�\���o���ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���ԕi�\��ꗗ�\���o���ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockRetPlnList
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";
        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";
        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;
        /// <summary>�`�[���z�i�Ŕ��j</summary>
        private Int64 _stockTtlPricTaxExc;
        /// <summary>�`�[���z�i�ō��j</summary>
        private Int64 _stockTtlPricTaxInc;
        /// <summary>���͓�</summary>
        private DateTime _inputDay;
        /// <summary>�d����</summary>
        private DateTime _stockDate;
        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;
        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";
        /// <summary>�`�[����Ŋz</summary>
        private Int64 _DtlConsTax;
        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;
        /// <summary>���[�J�[����</summary>
        private string _makerName = "";
        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";
        /// <summary>���i����</summary>
        private string _goodsName = "";
        /// <summary>�d����</summary>
        private Double _stockCount;
        /// <summary>�艿�i�Ŕ��j</summary>
        private Double _ListPriceTaxExc;
        /// <summary>�艿�i�ō��j</summary>
        private Double _ListPriceTaxInc;
        /// <summary>�d���P���i�Ŕ��j</summary>
        private Double _stockUnitPriceFl;
        /// <summary>�d���P���i�ō��j</summary>
        private Double _stockUnitTaxPriceFl;
        /// <summary>�d�����z�i�Ŕ��j</summary>
        private Int64 _stockPriceTaxExc;
        /// <summary>�d�����z�i�ō��j</summary>
        private Int64 _stockPriceTaxInc;
        /// <summary>�ېŋ敪</summary>
        private Int32 _taxationCode;
        /// <summary>�d���`�[���l1</summary>
        private string _supplierSlipNote1 = "";
        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        private Int32 _suppCTaxLayCd;
        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;
        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";
        /// <summary>���׏���Ŋz</summary>
        private Int64 _SlpConsTax;
        /// <summary>�_���폜�敪(�d���f�[�^)</summary>
        private Int32 _slpLogDelCd;
        /// <summary>�_���폜�敪(�d�����׃f�[�^)</summary>
        private Int32 _dtlLogDelCd;
        /// <summary>���㖾�גʔԁi�����j</summary>
        private Int64 _salesSlipDtlNum;
        /// <summary>�`�[�敪</summary>
        private Int32 _supplierSlipCd;

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  SlpLogDelCd
        /// <summary>�_���폜�敪�v���p�e�B(�d���f�[�^)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlpLogDelCd
        {
            get { return _slpLogDelCd; }
            set { _slpLogDelCd = value; }
        }

        /// public propaty name  :  LogicalDelCode
        /// <summary>�_���폜�敪�v���p�e�B(�d�����׃f�[�^)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlLogDelCd
        {
            get { return _dtlLogDelCd; }
            set { _dtlLogDelCd = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԁi�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>�`�[���z�i�Ŕ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>�`�[���z�i�ō��j�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:���`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���z�i�ō��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  DtlConsTax
        /// <summary>�`�[����Ŋz�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DtlConsTax
        {
            get { return _DtlConsTax; }
            set { _DtlConsTax = value; }
        }


        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  ListPriceTaxExc
        /// <summary>�艿�i�Ŕ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExc
        {
            get { return _ListPriceTaxExc; }
            set { _ListPriceTaxExc = value; }
        }

        /// public propaty name  :  ListPriceTaxInc
        /// <summary>�艿�i�ō��j�v���p�e�B</summary>
        /// <value>���݂̔������́u�艿�i�Ŕ��j�{�艿�i�ō��j�v�ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxInc
        {
            get { return _ListPriceTaxInc; }
            set { _ListPriceTaxInc = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockUnitTaxPriceFl
        /// <summary>�d���P���i�ō��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitTaxPriceFl
        {
            get { return _stockUnitTaxPriceFl; }
            set { _stockUnitTaxPriceFl = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>�d���`�[���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
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
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  SlpConsTax
        /// <summary>���׏���Ŋz�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׏���Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SlpConsTax
        {
            get { return _SlpConsTax; }
            set { _SlpConsTax = value; }
        }

        /// <summary>
        /// �d���ԕi�\��ꗗ�\���o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockRetPlnList�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockRetPlnList()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockRetPlnList�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockRetPlnList_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockRetPlnList || graph is ArrayList || graph is StockRetPlnList[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockRetPlnList).FullName));

            if (graph != null && graph is StockRetPlnList)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockRetPlnList");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockRetPlnList[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockRetPlnList[])graph).Length;
            }
            else if (graph is StockRetPlnList)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�`�[���z�i�Ŕ��j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�`�[���z�i�ō��j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�`�[����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //DtlConsTax
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //�艿�i�Ŕ��j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExc
            //�艿�i�ō��j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxInc
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���׏���Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SlpConsTax
            //�_���폜�敪(�d���f�[�^)
            serInfo.MemberInfo.Add(typeof(Int32)); //SlpLogDelCd
            //�_���폜�敪(�d�����׃f�[�^)
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlLogDelCd
            //���㖾�גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //�`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd

            serInfo.Serialize(writer, serInfo);
            if (graph is StockRetPlnList)
            {
                StockRetPlnList temp = (StockRetPlnList)graph;

                SetStockRetPlnList(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockRetPlnList[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockRetPlnList[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockRetPlnList temp in lst)
                {
                    SetStockRetPlnList(writer, temp);
                }
            }
        }

        /// <summary>
        /// StockRetPlnList�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 31;
        /// <summary>
        ///  StockRetPlnList�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockRetPlnList(System.IO.BinaryWriter writer, StockRetPlnList temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�`�[���z�i�Ŕ��j
            writer.Write(temp.StockTtlPricTaxExc);
            //�`�[���z�i�ō��j
            writer.Write(temp.StockTtlPricTaxInc);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�`�[����Ŋz
            writer.Write(temp.DtlConsTax);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�d����
            writer.Write(temp.StockCount);
            //�艿�i�Ŕ��j
            writer.Write(temp.ListPriceTaxExc);
            //�艿�i�ō��j
            writer.Write(temp.ListPriceTaxInc);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���P���i�ō��C�����j
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�ېŋ敪
            writer.Write(temp.TaxationCode);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���׏���Ŋz
            writer.Write(temp.SlpConsTax);
            //�_���폜�敪
            writer.Write(temp.SlpLogDelCd);
            //�_���폜�敪
            writer.Write(temp.DtlLogDelCd);
            //���㖾�גʔԁi�����j
            writer.Write(temp.SalesSlipDtlNum);
            //�`�[�敪SalesSlipDtlNum
            writer.Write(temp.SupplierSlipCd);
        }

        /// <summary>
        ///  StockRetPlnList�C���X�^���X�擾
        /// </summary>
        /// <returns>StockRetPlnList�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockRetPlnList GetStockRetPlnList(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockRetPlnList temp = new StockRetPlnList();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�`�[���z�i�Ŕ��j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�`�[���z�i�ō��j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�`�[����Ŋz
            temp.DtlConsTax = reader.ReadInt64();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //�艿�i�Ŕ��j
            temp.ListPriceTaxExc = reader.ReadDouble();
            //�艿�i�ō��j
            temp.ListPriceTaxInc = reader.ReadDouble();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�ō��C�����j
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���׏���Ŋz
            temp.SlpConsTax = reader.ReadInt64();
            //�_���폜�敪(�d���f�[�^)
            temp.SlpLogDelCd = reader.ReadInt32();
            //�_���폜�敪(�d�����׃f�[�^)
            temp.DtlLogDelCd = reader.ReadInt32();
            //���㖾�גʔԁi�����j
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //�`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();

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
        /// <returns>StockRetPlnList�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockRetPlnList�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockRetPlnList temp = GetStockRetPlnList(reader, serInfo);
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
                    retValue = (StockRetPlnList[])lst.ToArray(typeof(StockRetPlnList));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�G�N�X�|�[�g�p�����[�^�N���X
// �v���O�����T�v   : �|���}�X�^�G�N�X�|�[�g�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-**  �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12   �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasWork �� RateTextWork
//                                   StockMasWork_SerializationSurrogate_For_V51010 �� RateTextWork_SerializationSurrogate_For_V51010
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateTextWork
    /// <summary>
    ///                      �|���}�X�^�G�N�X�|�[�g���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�G�N�X�|�[�g���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/06/12   (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    // --- CHG  2015/10/14 K.Miura --- >>>>
    // public class StockMasWork
    public class RateTextWork
    // --- CHG  2015/10/14 K.Miura --- <<<<
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _sectionCode = "";

        /// <summary>�P�����(�����p)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _warehouseCode = "";

        /// <summary>�P���|���ݒ�敪</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _unitRateSetDivCd = "";

        /// <summary>�P�����</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _unitPriceKind = "";

        /// <summary>�|���ݒ�敪</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _rateSettingDivide = "";

        /// <summary>�|���ݒ�敪(���i)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _rateMngGoodsCd = "";

        /// <summary>�|���ݒ薼��(���i)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _rateMngGoodsNm = "";

        /// <summary>�|���ݒ�敪(���Ӑ�)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _rateMngCustCd = "";

        /// <summary>�|���ݒ薼��(���Ӑ�)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _rateMngCustNm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _goodsNo = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�|���}�X�^</remarks>
        private string _goodsRateRank = "";

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _custRateGrpCode;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _supplierCd;

        /// <summary>���b�g��</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _lotCount;

        /// <summary>���i(����)</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _priceFl;

        /// <summary>�|��</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _rateVal;

        /// <summary>UP��</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _upRate;

        /// <summary>�e���m�ۗ�</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _grsProfitSecureRate;

        /// <summary>�P���[�������P��</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Double _unPrcFracProcUnit;

        /// <summary>�P���[�������敪</summary>
        /// <remarks>�|���}�X�^</remarks>
        private Int32 _unPrcFracProcDiv;

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^</value>
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

        /// public propaty name  :  WarehouseCd
        /// <summary>�P�����(�����p)</summary>
        /// <value>�݌Ƀ}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P�����(�����p)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }


        /// public propaty name  :  UnitRateSetDivCd
        /// <summary>�P���|���ݒ�敪�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���|���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitRateSetDivCd
        {
            get { return _unitRateSetDivCd; }
            set { _unitRateSetDivCd = value; }
        }

        /// public propaty name  :  UnitPriceKind
        /// <summary>�P����ރv���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitPriceKind
        {
            get { return _unitPriceKind; }
            set { _unitPriceKind = value; }
        }

        /// public propaty name  :  RateSettingDivide
        /// <summary>�|���ݒ�敪�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateSettingDivide
        {
            get { return _rateSettingDivide; }
            set { _rateSettingDivide = value; }
        }

        /// public propaty name  :  RateMngGoodsCd
        /// <summary>�|���ݒ�敪(���i)�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsCd
        {
            get { return _rateMngGoodsCd; }
            set { _rateMngGoodsCd = value; }
        }

        /// public propaty name  :  RateMngGoodsNm
        /// <summary>�|���ݒ薼��(���i)�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼��(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngGoodsNm
        {
            get { return _rateMngGoodsNm; }
            set { _rateMngGoodsNm = value; }
        }

        /// public propaty name  :  RateMngCustCd
        /// <summary>�|���ݒ�敪(���Ӑ�)�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ�敪(���Ӑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustCd
        {
            get { return _rateMngCustCd; }
            set { _rateMngCustCd = value; }
        }

        /// public propaty name  :  RateMngCustNm
        /// <summary>�|���ݒ薼��(���Ӑ�)�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���ݒ薼��(���Ӑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RateMngCustNm
        {
            get { return _rateMngCustNm; }
            set { _rateMngCustNm = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
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

        /// public propaty name  :  LotCount
        /// <summary>���b�g���v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���b�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double LotCount
        {
            get { return _lotCount; }
            set { _lotCount = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>���i(����)�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�|���v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP���v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// public propaty name  :  GrsProfitSecureRate
        /// <summary>�e���m�ۗ��v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���m�ۗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrsProfitSecureRate
        {
            get { return _grsProfitSecureRate; }
            set { _grsProfitSecureRate = value; }
        }

        /// public propaty name  :  UnPrcFracProcUnit
        /// <summary>�P���[�������P�ʃv���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnPrcFracProcUnit
        {
            get { return _unPrcFracProcUnit; }
            set { _unPrcFracProcUnit = value; }
        }

        /// public propaty name  :  UnPrcFracProcDiv
        /// <summary>�P���[�������敪�v���p�e�B</summary>
        /// <value>�|���}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnPrcFracProcDiv
        {
            get { return _unPrcFracProcDiv; }
            set { _unPrcFracProcDiv = value; }
        }


        /// <summary>
        /// �݌Ƀe�L�X�g�ϊ����o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMasWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RateTextWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMasWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMasWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    // --- CHG  2015/10/14 K.Miura --- >>>>
    // public class StockMasWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    public class RateTextWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    // --- CHG  2015/10/14 K.Miura --- <<<<
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RateTextWork || graph is ArrayList || graph is RateTextWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RateTextWork).FullName));

            if (graph != null && graph is RateTextWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RateTextWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RateTextWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RateTextWork[])graph).Length;
            }
            else if (graph is RateTextWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�P�����(�����p)
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCd
            //�P���|���ݒ�敪
            serInfo.MemberInfo.Add(typeof(string)); //UnitRateSetDivCd
            //�P�����
            serInfo.MemberInfo.Add(typeof(string)); //UnitPriceKind
            //�|���ݒ�敪
            serInfo.MemberInfo.Add(typeof(string)); //RateSettingDivide
            //�|���ݒ�敪(���i)
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsCd
            //�|���ݒ薼��(���i)
            serInfo.MemberInfo.Add(typeof(string)); //RateMngGoodsNm
            //�|���ݒ�敪(���Ӑ�)
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustCd
            //�|���ݒ薼��(���Ӑ�)
            serInfo.MemberInfo.Add(typeof(string)); //RateMngCustNm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���b�g��
            serInfo.MemberInfo.Add(typeof(Double)); //LotCount
            //���i(����)
            serInfo.MemberInfo.Add(typeof(Double)); //PriceFl
            //�|��
            serInfo.MemberInfo.Add(typeof(Double)); //RateVal
            //UP��
            serInfo.MemberInfo.Add(typeof(Double)); //UpRate
            //�e���m�ۗ�
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitSecureRate
            //�P���[�������P��
            serInfo.MemberInfo.Add(typeof(Double)); //UnPrcFracProcUnit
            //�P���[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcFracProcDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is RateTextWork)
            {
                RateTextWork temp = (RateTextWork)graph;

                SetStockMasWork(writer, temp);
            }            
            else if (graph is RateTextWork)
            {
                RateTextWork temp = (RateTextWork)graph;

                SetStockMasWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RateTextWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RateTextWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }
                

                foreach (RateTextWork temp in lst)
                {
                    SetStockMasWork(writer, temp);
                }
            }


        }


        /// <summary>
        /// StockMasWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  StockMasWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMasWork(System.IO.BinaryWriter writer, RateTextWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�P�����(�����p)
            writer.Write(temp.WarehouseCd);
            //�P���|���ݒ�敪
            writer.Write(temp.UnitRateSetDivCd);
            //�P�����
            writer.Write(temp.UnitPriceKind);
            //�|���ݒ�敪
            writer.Write(temp.RateSettingDivide);
            //�|���ݒ�敪(���i)
            writer.Write(temp.RateMngGoodsCd);
            //�|���ݒ薼��(���i)
            writer.Write(temp.RateMngGoodsNm);
            //�|���ݒ�敪(���Ӑ�)
            writer.Write(temp.RateMngCustCd);
            //�|���ݒ薼��(���Ӑ�)
            writer.Write(temp.RateMngCustNm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���b�g��
            writer.Write(temp.LotCount);
            //���i(����)
            writer.Write(temp.PriceFl);
            //�|��
            writer.Write(temp.RateVal);
            //UP��
            writer.Write(temp.UpRate);
            //�e���m�ۗ�
            writer.Write(temp.GrsProfitSecureRate);
            //�P���[�������P��
            writer.Write(temp.UnPrcFracProcUnit);
            //�P���[�������敪
            writer.Write(temp.UnPrcFracProcDiv);

        }

        /// <summary>
        ///  StockMasWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMasWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RateTextWork GetStockMasWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RateTextWork temp = new RateTextWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�P�����(�����p)
            temp.WarehouseCd = reader.ReadString();
            //�P���|���ݒ�敪
            temp.UnitRateSetDivCd = reader.ReadString();
            //�P�����
            temp.UnitPriceKind = reader.ReadString();
            //�|���ݒ�敪
            temp.RateSettingDivide = reader.ReadString();
            //�|���ݒ�敪(���i)
            temp.RateMngGoodsCd = reader.ReadString();
            //�|���ݒ薼��(���i)
            temp.RateMngGoodsNm = reader.ReadString();
            //�|���ݒ�敪(���Ӑ�)
            temp.RateMngCustCd = reader.ReadString();
            //�|���ݒ薼��(���Ӑ�)
            temp.RateMngCustNm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���b�g��
            temp.LotCount = reader.ReadDouble();
            //���i(����)
            temp.PriceFl = reader.ReadDouble();
            //�|��
            temp.RateVal = reader.ReadDouble();
            //UP��
            temp.UpRate = reader.ReadDouble();
            //�e���m�ۗ�
            temp.GrsProfitSecureRate = reader.ReadDouble();
            //�P���[�������P��
            temp.UnPrcFracProcUnit = reader.ReadDouble();
            //�P���[�������敪
            temp.UnPrcFracProcDiv = reader.ReadInt32();


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
        /// <returns>StockMasWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RateTextWork temp = GetStockMasWork(reader, serInfo);
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
                    retValue = (RateTextWork[])lst.ToArray(typeof(RateTextWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

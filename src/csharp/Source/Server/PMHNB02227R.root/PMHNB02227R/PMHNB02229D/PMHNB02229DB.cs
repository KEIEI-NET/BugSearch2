//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����s�����m�F�\
// �v���O�����T�v   : ����s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesStockInfoWork
    /// <summary>
    ///                      ����s�����m�F�\�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����s�����m�F�\�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesStockInfoWork 
    {
        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sectionGuideNm = "";

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private Int32 _salesDate;

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>���͒S���҃R�[�h</summary>
        /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
        private string _inputAgenCd = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`No�j</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>�d���s�ԍ�</summary>
        private Int32 _stockRowNo;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>�s�������e</summary>
        /// <remarks>�s�������e</remarks>
        private string _nayiYou = "";

        /// <summary>���_�R�[�h�w�b�_</summary>
        /// <remarks>�w�b�_</remarks>
        private string _sectionCodeHeader = "";

        /// <summary>���Ӑ�R�[�h�w�b�_</summary>
        /// <remarks>�w�b�_</remarks>
        private Int32 _customerCodeHeader;

        /// <summary>���ʃ`�b�N�t���O</summary>
        /// <remarks>���ʃ`�b�N�t���O</remarks>
        private string _countFlg = "";

        /// <summary>���i�`�b�N�t���O</summary>
        /// <remarks>���i�`�b�N�t���O</remarks>
        private string _priceFlg = "";

        /// <summary>�d�����݃`�b�N�t���O</summary>
        /// <remarks>�d�����݃`�b�N�t���O</remarks>
        private string _existFlg = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _salesRowNo;


        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���`�[�ԍ�,���ד`�[�ԍ�,�������ԍ�(����)�����˂�</value>
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
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
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

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>�`�[�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���ҁi�t�r�a�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`No�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>�d���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
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

        /// public propaty name  :  NayiYou
        /// <summary>�s�������e�v���p�e�B</summary>
        /// <value>�s�������e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s�������e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NayiYou
        {
            get { return _nayiYou; }
            set { _nayiYou = value; }
        }

        /// public propaty name  :  SectionCodeHeader
        /// <summary>���_�R�[�h�w�b�_�v���p�e�B</summary>
        /// <value>�w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�w�b�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeHeader
        {
            get { return _sectionCodeHeader; }
            set { _sectionCodeHeader = value; }
        }

        /// public propaty name  :  CustomerCodeHeader
        /// <summary>���Ӑ�R�[�h�w�b�_�v���p�e�B</summary>
        /// <value>�w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�w�b�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeHeader
        {
            get { return _customerCodeHeader; }
            set { _customerCodeHeader = value; }
        }

        /// public propaty name  :  CountFlg
        /// <summary>���ʃ`�b�N�t���O�v���p�e�B</summary>
        /// <value>���ʃ`�b�N�t���O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃ`�b�N�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CountFlg
        {
            get { return _countFlg; }
            set { _countFlg = value; }
        }

        /// public propaty name  :  PriceFlg
        /// <summary>���i�`�b�N�t���O�v���p�e�B</summary>
        /// <value>���i�`�b�N�t���O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�`�b�N�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceFlg
        {
            get { return _priceFlg; }
            set { _priceFlg = value; }
        }

        /// public propaty name  :  ExistFlg
        /// <summary>�d�����݃`�b�N�t���O�v���p�e�B</summary>
        /// <value>�d�����݃`�b�N�t���O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����݃`�b�N�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExistFlg
        {
            get { return _existFlg; }
            set { _existFlg = value; }
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


        /// <summary>
        /// ����s�����m�F�\�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesStockInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesStockInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesStockInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesStockInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesStockInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesStockInfoWork || graph is ArrayList || graph is SalesStockInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesStockInfoWork).FullName));

            if (graph != null && graph is SalesStockInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesStockInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesStockInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesStockInfoWork[])graph).Length;
            }
            else if (graph is SalesStockInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�`�[�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //���͒S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InputAgenCd
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�����`�[�ԍ��i���ׁj
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //�d���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�s�������e
            serInfo.MemberInfo.Add(typeof(string)); //NayiYou
            //���_�R�[�h�w�b�_
            serInfo.MemberInfo.Add(typeof(string)); //SectionCodeHeader
            //���Ӑ�R�[�h�w�b�_
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCodeHeader
            //���ʃ`�b�N�t���O
            serInfo.MemberInfo.Add(typeof(string)); //CountFlg
            //���i�`�b�N�t���O
            serInfo.MemberInfo.Add(typeof(string)); //PriceFlg
            //�d�����݃`�b�N�t���O
            serInfo.MemberInfo.Add(typeof(string)); //ExistFlg
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesStockInfoWork)
            {
                SalesStockInfoWork temp = (SalesStockInfoWork)graph;

                SetSalesStockInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesStockInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesStockInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesStockInfoWork temp in lst)
                {
                    SetSalesStockInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesStockInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SalesStockInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesStockInfoWork(System.IO.BinaryWriter writer, SalesStockInfoWork temp)
        {
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //������t
            writer.Write(temp.SalesDate);
            //�`�[�������t
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //���͒S���҃R�[�h
            writer.Write(temp.InputAgenCd);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�����`�[�ԍ��i���ׁj
            writer.Write(temp.PartySlipNumDtl);
            //�d���s�ԍ�
            writer.Write(temp.StockRowNo);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�s�������e
            writer.Write(temp.NayiYou);
            //���_�R�[�h�w�b�_
            writer.Write(temp.SectionCodeHeader);
            //���Ӑ�R�[�h�w�b�_
            writer.Write(temp.CustomerCodeHeader);
            //���ʃ`�b�N�t���O
            writer.Write(temp.CountFlg);
            //���i�`�b�N�t���O
            writer.Write(temp.PriceFlg);
            //�d�����݃`�b�N�t���O
            writer.Write(temp.ExistFlg);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  SalesStockInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesStockInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesStockInfoWork GetSalesStockInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesStockInfoWork temp = new SalesStockInfoWork();

            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //������t
            temp.SalesDate = reader.ReadInt32();
            //�`�[�������t
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //���͒S���҃R�[�h
            temp.InputAgenCd = reader.ReadString();
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�����`�[�ԍ��i���ׁj
            temp.PartySlipNumDtl = reader.ReadString();
            //�d���s�ԍ�
            temp.StockRowNo = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�s�������e
            temp.NayiYou = reader.ReadString();
            //���_�R�[�h�w�b�_
            temp.SectionCodeHeader = reader.ReadString();
            //���Ӑ�R�[�h�w�b�_
            temp.CustomerCodeHeader = reader.ReadInt32();
            //���ʃ`�b�N�t���O
            temp.CountFlg = reader.ReadString();
            //���i�`�b�N�t���O
            temp.PriceFlg = reader.ReadString();
            //�d�����݃`�b�N�t���O
            temp.ExistFlg = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();


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
        /// <returns>SalesStockInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesStockInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesStockInfoWork temp = GetSalesStockInfoWork(reader, serInfo);
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
                    retValue = (SalesStockInfoWork[])lst.ToArray(typeof(SalesStockInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

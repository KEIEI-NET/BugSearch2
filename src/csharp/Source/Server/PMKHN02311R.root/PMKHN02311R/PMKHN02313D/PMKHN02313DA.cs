//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsInfoDataWork
    /// <summary>
    ///                      ���i�ǉ��f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�ǉ��f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/2/27</br>
    /// <br>Genarated Date   :   2009/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsInfoDataWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�d���溰��</summary>
        /// <remarks>�d���溰��</remarks>
        private Int32 _supplierCd;

        /// <summary>Ұ������</summary>
        /// <remarks>Ұ������</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���޺���</summary>
        /// <remarks>���޺���</remarks>
        private string _kindCd = "";

        /// <summary>������</summary>
        /// <remarks>������</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>�i�@��</summary>
        /// <remarks>�i�@��</remarks>
        private string _goodsNo = "";

        /// <summary>�i�@��</summary>
        /// <remarks>�i�@��</remarks>
        private string _goodsName = "";

        /// <summary>��@��</summary>
        /// <remarks>��@��</remarks>
        private Double _price;

        /// <summary>���i�������P</summary>
        /// <remarks>���i�������P</remarks>
        private string _price1 = "";

        /// <summary>���i�������Q</summary>
        /// <remarks>���i�������Q</remarks>
        private string _price2 = "";

        /// <summary>���i�������R</summary>
        /// <remarks>���i�������R</remarks>
        private string _price3 = "";

        /// <summary>���i���{��</summary>
        /// <remarks>���i���{��</remarks>
        private Int64 _priceStartDate;

        /// <summary>�o�^�敪</summary>
        /// <remarks>�o�^�敪</remarks>
        private string _loginFlg = "";

        /// <summary>������</summary>
        /// <remarks>������</remarks>
        private Double _stockRate;

        /// <summary>���@��</summary>
        /// <remarks>���@��</remarks>
        private Double _salesUnitCost;

        /// <summary>���i������</summary>
        /// <remarks>���i������</remarks>
        private string _goodsTraderCd = "";

        /// <summary>�t�@�C���쐬���t</summary>
        /// <remarks>�쐬���t</remarks>
        private string _fileCreateDateTime = "";

        /// <summary>pdf���</summary>
        /// <remarks>pdf���</remarks>
        private string _pdfStatus = "";

        /// <summary>�G���[�R�[�h</summary>
        /// <remarks>DB�G���[�R�[�h</remarks>
        private Int32 _errorCode;

        /// <summary>�G���[���b�Z�[�W</summary>
        /// <remarks>DB�G���[���b�Z�[�W</remarks>
        private string _errorMessage = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
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

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d���溰�ރv���p�e�B</summary>
        /// <value>�d���溰��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���溰�ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>Ұ�����ރv���p�e�B</summary>
        /// <value>Ұ������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  KindCd
        /// <summary>���޺��ރv���p�e�B</summary>
        /// <value>���޺���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���޺��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KindCd
        {
            get { return _kindCd; }
            set { _kindCd = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>�����ރv���p�e�B</summary>
        /// <value>������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�@�ԃv���p�e�B</summary>
        /// <value>�i�@��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�@�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>�i�@���v���p�e�B</summary>
        /// <value>�i�@��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Price
        /// <summary>��@���v���p�e�B</summary>
        /// <value>��@��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        /// public propaty name  :  Price1
        /// <summary>���i�������P�v���p�e�B</summary>
        /// <value>���i�������P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price1
        {
            get { return _price1; }
            set { _price1 = value; }
        }

        /// public propaty name  :  Price2
        /// <summary>���i�������Q�v���p�e�B</summary>
        /// <value>���i�������Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }

        /// public propaty name  :  Price3
        /// <summary>���i�������R�v���p�e�B</summary>
        /// <value>���i�������R</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i���{���v���p�e�B</summary>
        /// <value>���i���{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  LoginFlg
        /// <summary>�o�^�敪�v���p�e�B</summary>
        /// <value>�o�^�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginFlg
        {
            get { return _loginFlg; }
            set { _loginFlg = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�������v���p�e�B</summary>
        /// <value>������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>���@���v���p�e�B</summary>
        /// <value>���@��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsTraderCd
        /// <summary>���i�����ރv���p�e�B</summary>
        /// <value>���i������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsTraderCd
        {
            get { return _goodsTraderCd; }
            set { _goodsTraderCd = value; }
        }

        /// public propaty name  :  FileCreateDateTime
        /// <summary>�t�@�C���쐬���t�v���p�e�B</summary>
        /// <value>�쐬���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���쐬���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileCreateDateTime
        {
            get { return _fileCreateDateTime; }
            set { _fileCreateDateTime = value; }
        }

        /// public propaty name  :  PdfStatus
        /// <summary>pdf��ԃv���p�e�B</summary>
        /// <value>pdf���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   pdf��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PdfStatus
        {
            get { return _pdfStatus; }
            set { _pdfStatus = value; }
        }

        /// public propaty name  :  ErrorCode
        /// <summary>�G���[�R�[�h�v���p�e�B</summary>
        /// <value>DB�G���[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>�G���[���b�Z�[�W�v���p�e�B</summary>
        /// <value>DB�G���[���b�Z�[�W</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }


        /// <summary>
        /// ���i�ǉ��f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsInfoDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsInfoDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsInfoDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsInfoDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsInfoDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsInfoDataWork || graph is ArrayList || graph is GoodsInfoDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsInfoDataWork).FullName));

            if (graph != null && graph is GoodsInfoDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsInfoDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsInfoDataWork[])graph).Length;
            }
            else if (graph is GoodsInfoDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�d���溰��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //Ұ������
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���޺���
            serInfo.MemberInfo.Add(typeof(string)); //KindCd
            //������
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�i�@��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�i�@��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //��@��
            serInfo.MemberInfo.Add(typeof(Double)); //Price
            //���i�������P
            serInfo.MemberInfo.Add(typeof(string)); //Price1
            //���i�������Q
            serInfo.MemberInfo.Add(typeof(string)); //Price2
            //���i�������R
            serInfo.MemberInfo.Add(typeof(string)); //Price3
            //���i���{��
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //�o�^�敪
            serInfo.MemberInfo.Add(typeof(string)); //LoginFlg
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //���@��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //���i������
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTraderCd
            //�t�@�C���쐬���t
            serInfo.MemberInfo.Add(typeof(string)); //FileCreateDateTime
            //pdf���
            serInfo.MemberInfo.Add(typeof(string)); //PdfStatus
            //�G���[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorCode
            //�G���[���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsInfoDataWork)
            {
                GoodsInfoDataWork temp = (GoodsInfoDataWork)graph;

                SetGoodsInfoDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsInfoDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsInfoDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsInfoDataWork temp in lst)
                {
                    SetGoodsInfoDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsInfoDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  GoodsInfoDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsInfoDataWork(System.IO.BinaryWriter writer, GoodsInfoDataWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�d���溰��
            writer.Write(temp.SupplierCd);
            //Ұ������
            writer.Write(temp.GoodsMakerCd);
            //���޺���
            writer.Write(temp.KindCd);
            //������
            writer.Write(temp.BLGoodsCode);
            //�i�@��
            writer.Write(temp.GoodsNo);
            //�i�@��
            writer.Write(temp.GoodsName);
            //��@��
            writer.Write(temp.Price);
            //���i�������P
            writer.Write(temp.Price1);
            //���i�������Q
            writer.Write(temp.Price2);
            //���i�������R
            writer.Write(temp.Price3);
            //���i���{��
            writer.Write(temp.PriceStartDate);
            //�o�^�敪
            writer.Write(temp.LoginFlg);
            //������
            writer.Write(temp.StockRate);
            //���@��
            writer.Write(temp.SalesUnitCost);
            //���i������
            writer.Write(temp.GoodsTraderCd);
            //�t�@�C���쐬���t
            writer.Write(temp.FileCreateDateTime);
            //pdf���
            writer.Write(temp.PdfStatus);
            //�G���[�R�[�h
            writer.Write(temp.ErrorCode);
            //�G���[���b�Z�[�W
            writer.Write(temp.ErrorMessage);

        }

        /// <summary>
        ///  GoodsInfoDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsInfoDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsInfoDataWork GetGoodsInfoDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsInfoDataWork temp = new GoodsInfoDataWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�d���溰��
            temp.SupplierCd = reader.ReadInt32();
            //Ұ������
            temp.GoodsMakerCd = reader.ReadInt32();
            //���޺���
            temp.KindCd = reader.ReadString();
            //������
            temp.BLGoodsCode = reader.ReadInt32();
            //�i�@��
            temp.GoodsNo = reader.ReadString();
            //�i�@��
            temp.GoodsName = reader.ReadString();
            //��@��
            temp.Price = reader.ReadDouble();
            //���i�������P
            temp.Price1 = reader.ReadString();
            //���i�������Q
            temp.Price2 = reader.ReadString();
            //���i�������R
            temp.Price3 = reader.ReadString();
            //���i���{��
            temp.PriceStartDate = reader.ReadInt64();
            //�o�^�敪
            temp.LoginFlg = reader.ReadString();
            //������
            temp.StockRate = reader.ReadDouble();
            //���@��
            temp.SalesUnitCost = reader.ReadDouble();
            //���i������
            temp.GoodsTraderCd = reader.ReadString();
            //�t�@�C���쐬���t
            temp.FileCreateDateTime = reader.ReadString();
            //pdf���
            temp.PdfStatus = reader.ReadString();
            //�G���[�R�[�h
            temp.ErrorCode = reader.ReadInt32();
            //�G���[���b�Z�[�W
            temp.ErrorMessage = reader.ReadString();


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
        /// <returns>GoodsInfoDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsInfoDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsInfoDataWork temp = GetGoodsInfoDataWork(reader, serInfo);
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
                    retValue = (GoodsInfoDataWork[])lst.ToArray(typeof(GoodsInfoDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}

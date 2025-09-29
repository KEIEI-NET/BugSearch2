using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PublicationConfResultWork
    /// <summary>
    ///                      ���s�m�F�ꗗ�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���s�m�F�ꗗ�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PublicationConfResultWork 
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>�I�����C���s�ԍ�</summary>
        private Int32 _onlineRowNo;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�艿�i�����j</summary>
        /// <remarks>�K�p�i�艿�j</remarks>
        private Double _listPrice;

        /// <summary>�󒍐���</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>UOE���_�o�ɐ�</summary>
        private Int32 _uOESectOutGoodsCnt;

        /// <summary>BO�o�ɐ�1</summary>
        /// <remarks>�T�u�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt1;

        /// <summary>BO�o�ɐ�2</summary>
        /// <remarks>�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt2;

        /// <summary>BO�o�ɐ�3</summary>
        /// <remarks>���[�g�t�H���[��</remarks>
        private Int32 _bOShipmentCnt3;

        /// <summary>���[�J�[�t�H���[��</summary>
        private Int32 _makerFollowCnt;

        /// <summary>EO������</summary>
        private Int32 _eOAlwcCount;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>��M���t</summary>
        private DateTime _receiveDate;

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�񓚕i��</summary>
        private string _answerPartsNo = "";

        /// <summary>�񓚕i��</summary>
        private string _answerPartsName = "";

        /// <summary>�񓚒艿</summary>
        private Double _answerListPrice;

        /// <summary>�񓚌����P��</summary>
        private Double _answerSalesUnitCost;

        /// <summary>UOE���_�`�[�ԍ�</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>BO�`�[�ԍ��P</summary>
        /// <remarks>�T�u�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO�`�[�ԍ��Q</summary>
        /// <remarks>�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO�`�[�ԍ��R</summary>
        /// <remarks>���[�g�t�H���[�`�[��</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>BO�Ǘ��ԍ�</summary>
        private string _bOManagementNo = "";


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  OnlineNo
        /// <summary>�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>�I�����C���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>�K�p�i�艿�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  UOESectOutGoodsCnt
        /// <summary>UOE���_�o�ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�o�ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectOutGoodsCnt
        {
            get { return _uOESectOutGoodsCnt; }
            set { _uOESectOutGoodsCnt = value; }
        }

        /// public propaty name  :  BOShipmentCnt1
        /// <summary>BO�o�ɐ�1�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt1
        {
            get { return _bOShipmentCnt1; }
            set { _bOShipmentCnt1 = value; }
        }

        /// public propaty name  :  BOShipmentCnt2
        /// <summary>BO�o�ɐ�2�v���p�e�B</summary>
        /// <value>�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt2
        {
            get { return _bOShipmentCnt2; }
            set { _bOShipmentCnt2 = value; }
        }

        /// public propaty name  :  BOShipmentCnt3
        /// <summary>BO�o�ɐ�3�v���p�e�B</summary>
        /// <value>���[�g�t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt3
        {
            get { return _bOShipmentCnt3; }
            set { _bOShipmentCnt3 = value; }
        }

        /// public propaty name  :  MakerFollowCnt
        /// <summary>���[�J�[�t�H���[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�t�H���[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerFollowCnt
        {
            get { return _makerFollowCnt; }
            set { _makerFollowCnt = value; }
        }

        /// public propaty name  :  EOAlwcCount
        /// <summary>EO�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   EO�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EOAlwcCount
        {
            get { return _eOAlwcCount; }
            set { _eOAlwcCount = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  ReceiveDate
        /// <summary>��M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  AnswerPartsNo
        /// <summary>�񓚕i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsNo
        {
            get { return _answerPartsNo; }
            set { _answerPartsNo = value; }
        }

        /// public propaty name  :  AnswerPartsName
        /// <summary>�񓚕i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsName
        {
            get { return _answerPartsName; }
            set { _answerPartsName = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>�񓚒艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>�񓚌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE���_�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO�`�[�ԍ��P�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO�`�[�ԍ��Q�v���p�e�B</summary>
        /// <value>�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO�`�[�ԍ��R�v���p�e�B</summary>
        /// <value>���[�g�t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  BOManagementNo
        /// <summary>BO�Ǘ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOManagementNo
        {
            get { return _bOManagementNo; }
            set { _bOManagementNo = value; }
        }


        /// <summary>
        /// ���s�m�F�ꗗ�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PublicationConfResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PublicationConfResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PublicationConfResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PublicationConfResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PublicationConfResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PublicationConfResultWork || graph is ArrayList || graph is PublicationConfResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PublicationConfResultWork).FullName));

            if (graph != null && graph is PublicationConfResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PublicationConfResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PublicationConfResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PublicationConfResultWork[])graph).Length;
            }
            else if (graph is PublicationConfResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�I�����C���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //�I�����C���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineRowNo
            //�V�X�e���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //UOE���_�o�ɐ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectOutGoodsCnt
            //BO�o�ɐ�1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt1
            //BO�o�ɐ�2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt2
            //BO�o�ɐ�3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt3
            //���[�J�[�t�H���[��
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowCnt
            //EO������
            serInfo.MemberInfo.Add(typeof(Int32)); //EOAlwcCount
            //UOE�����於��
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //��M���t
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveDate
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�񓚕i��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsNo
            //�񓚕i��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsName
            //�񓚒艿
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerListPrice
            //�񓚌����P��
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerSalesUnitCost
            //UOE���_�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO�`�[�ԍ��P
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO�`�[�ԍ��Q
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO�`�[�ԍ��R
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //BO�Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //BOManagementNo


            serInfo.Serialize(writer, serInfo);
            if (graph is PublicationConfResultWork)
            {
                PublicationConfResultWork temp = (PublicationConfResultWork)graph;

                SetPublicationConfResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PublicationConfResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PublicationConfResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PublicationConfResultWork temp in lst)
                {
                    SetPublicationConfResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PublicationConfResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  PublicationConfResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPublicationConfResultWork(System.IO.BinaryWriter writer, PublicationConfResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�I�����C���ԍ�
            writer.Write(temp.OnlineNo);
            //�I�����C���s�ԍ�
            writer.Write(temp.OnlineRowNo);
            //�V�X�e���敪
            writer.Write(temp.SystemDivCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�艿�i�����j
            writer.Write(temp.ListPrice);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //UOE���_�o�ɐ�
            writer.Write(temp.UOESectOutGoodsCnt);
            //BO�o�ɐ�1
            writer.Write(temp.BOShipmentCnt1);
            //BO�o�ɐ�2
            writer.Write(temp.BOShipmentCnt2);
            //BO�o�ɐ�3
            writer.Write(temp.BOShipmentCnt3);
            //���[�J�[�t�H���[��
            writer.Write(temp.MakerFollowCnt);
            //EO������
            writer.Write(temp.EOAlwcCount);
            //UOE�����於��
            writer.Write(temp.UOESupplierName);
            //��M���t
            writer.Write((Int64)temp.ReceiveDate.Ticks);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�񓚕i��
            writer.Write(temp.AnswerPartsNo);
            //�񓚕i��
            writer.Write(temp.AnswerPartsName);
            //�񓚒艿
            writer.Write(temp.AnswerListPrice);
            //�񓚌����P��
            writer.Write(temp.AnswerSalesUnitCost);
            //UOE���_�`�[�ԍ�
            writer.Write(temp.UOESectionSlipNo);
            //BO�`�[�ԍ��P
            writer.Write(temp.BOSlipNo1);
            //BO�`�[�ԍ��Q
            writer.Write(temp.BOSlipNo2);
            //BO�`�[�ԍ��R
            writer.Write(temp.BOSlipNo3);
            //BO�Ǘ��ԍ�
            writer.Write(temp.BOManagementNo);

        }

        /// <summary>
        ///  PublicationConfResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PublicationConfResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PublicationConfResultWork GetPublicationConfResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PublicationConfResultWork temp = new PublicationConfResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�I�����C���ԍ�
            temp.OnlineNo = reader.ReadInt32();
            //�I�����C���s�ԍ�
            temp.OnlineRowNo = reader.ReadInt32();
            //�V�X�e���敪
            temp.SystemDivCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�艿�i�����j
            temp.ListPrice = reader.ReadDouble();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //UOE���_�o�ɐ�
            temp.UOESectOutGoodsCnt = reader.ReadInt32();
            //BO�o�ɐ�1
            temp.BOShipmentCnt1 = reader.ReadInt32();
            //BO�o�ɐ�2
            temp.BOShipmentCnt2 = reader.ReadInt32();
            //BO�o�ɐ�3
            temp.BOShipmentCnt3 = reader.ReadInt32();
            //���[�J�[�t�H���[��
            temp.MakerFollowCnt = reader.ReadInt32();
            //EO������
            temp.EOAlwcCount = reader.ReadInt32();
            //UOE�����於��
            temp.UOESupplierName = reader.ReadString();
            //��M���t
            temp.ReceiveDate = new DateTime(reader.ReadInt64());
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�񓚕i��
            temp.AnswerPartsNo = reader.ReadString();
            //�񓚕i��
            temp.AnswerPartsName = reader.ReadString();
            //�񓚒艿
            temp.AnswerListPrice = reader.ReadDouble();
            //�񓚌����P��
            temp.AnswerSalesUnitCost = reader.ReadDouble();
            //UOE���_�`�[�ԍ�
            temp.UOESectionSlipNo = reader.ReadString();
            //BO�`�[�ԍ��P
            temp.BOSlipNo1 = reader.ReadString();
            //BO�`�[�ԍ��Q
            temp.BOSlipNo2 = reader.ReadString();
            //BO�`�[�ԍ��R
            temp.BOSlipNo3 = reader.ReadString();
            //BO�Ǘ��ԍ�
            temp.BOManagementNo = reader.ReadString();


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
        /// <returns>PublicationConfResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PublicationConfResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PublicationConfResultWork temp = GetPublicationConfResultWork(reader, serInfo);
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
                    retValue = (PublicationConfResultWork[])lst.ToArray(typeof(PublicationConfResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//


using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetWork
    /// <summary>
    ///                      �W�����i�I��ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �W�����i�I��ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/09/15</br>
    /// <br>Genarated Date   :   2009/10/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetWork : IFileHeader
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

        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        /// <remarks>0:Ұ�����ށEBL���ށE���Ӑ溰��,1:Ұ�����ށE���Ӑ溰��,2:BL���ށE���Ӑ溰��,3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��,4:Ұ�����ށE���Ӑ�|����ٰ��,5:BL���ށE���Ӑ�|����ٰ��,6:Ұ�����ށEBL����,7:Ұ������,8:BL����</remarks>
        private Int32 _priceSelectPtn;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�W�����i�I���敪</summary>
        /// <remarks>0:�D��,1:����,2:������(1:N),,3:������(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";


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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>�W�����i�I��ݒ�p�^�[���v���p�e�B</summary>
        /// <value>0:Ұ�����ށEBL���ށE���Ӑ溰��,1:Ұ�����ށE���Ӑ溰��,2:BL���ށE���Ӑ溰��,3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��,4:Ұ�����ށE���Ӑ�|����ٰ��,5:BL���ށE���Ӑ�|����ٰ��,6:Ұ�����ށEBL����,7:Ұ������,8:BL����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I��ݒ�p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  PriceSelectDiv
        /// <summary>�W�����i�I���敪�v���p�e�B</summary>
        /// <value>0:�D��,1:����,2:������(1:N),,3:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
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


        /// <summary>
        /// �W�����i�I��ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PriceSelectSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PriceSelectSetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PriceSelectSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceSelectSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceSelectSetWork || graph is ArrayList || graph is PriceSelectSetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PriceSelectSetWork).FullName));

            if (graph != null && graph is PriceSelectSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceSelectSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceSelectSetWork[])graph).Length;
            }
            else if (graph is PriceSelectSetWork)
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
            //�W�����i�I��ݒ�p�^�[��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectPtn
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�W�����i�I���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectDiv
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName


            serInfo.Serialize(writer, serInfo);
            if (graph is PriceSelectSetWork)
            {
                PriceSelectSetWork temp = (PriceSelectSetWork)graph;

                SetPriceSelectSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceSelectSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceSelectSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceSelectSetWork temp in lst)
                {
                    SetPriceSelectSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PriceSelectSetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  PriceSelectSetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPriceSelectSetWork(System.IO.BinaryWriter writer, PriceSelectSetWork temp)
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
            //�W�����i�I��ݒ�p�^�[��
            writer.Write(temp.PriceSelectPtn);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�W�����i�I���敪
            writer.Write(temp.PriceSelectDiv);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���[�J�[����
            writer.Write(temp.MakerName);

        }

        /// <summary>
        ///  PriceSelectSetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PriceSelectSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PriceSelectSetWork GetPriceSelectSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PriceSelectSetWork temp = new PriceSelectSetWork();

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
            //�W�����i�I��ݒ�p�^�[��
            temp.PriceSelectPtn = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�W�����i�I���敪
            temp.PriceSelectDiv = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���[�J�[����
            temp.MakerName = reader.ReadString();


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
        /// <returns>PriceSelectSetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceSelectSetWork temp = GetPriceSelectSetWork(reader, serInfo);
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
                    retValue = (PriceSelectSetWork[])lst.ToArray(typeof(PriceSelectSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


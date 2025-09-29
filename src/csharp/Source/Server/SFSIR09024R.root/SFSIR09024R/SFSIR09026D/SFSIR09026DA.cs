using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentSetWork
    /// <summary>
    ///                      �x���ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/03/30</br>
    /// <br>Genarated Date   :   2006/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentSetWork : IFileHeader
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

        /// <summary>�x���ݒ�Ǘ�No</summary>
        /// <remarks>0�Œ�</remarks>
        private Int32 _payStMngNo;

        /// <summary>�x���ݒ����R�[�h1</summary>
        private Int32 _payStMoneyKindCd1;

        /// <summary>�x���ݒ����R�[�h2</summary>
        private Int32 _payStMoneyKindCd2;

        /// <summary>�x���ݒ����R�[�h3</summary>
        private Int32 _payStMoneyKindCd3;

        /// <summary>�x���ݒ����R�[�h4</summary>
        private Int32 _payStMoneyKindCd4;

        /// <summary>�x���ݒ����R�[�h5</summary>
        private Int32 _payStMoneyKindCd5;

        /// <summary>�x���ݒ����R�[�h6</summary>
        private Int32 _payStMoneyKindCd6;

        /// <summary>�x���ݒ����R�[�h7</summary>
        private Int32 _payStMoneyKindCd7;

        /// <summary>�x���ݒ����R�[�h8</summary>
        private Int32 _payStMoneyKindCd8;

        /// <summary>�x���ݒ����R�[�h9</summary>
        private Int32 _payStMoneyKindCd9;

        /// <summary>�x���ݒ����R�[�h10</summary>
        private Int32 _payStMoneyKindCd10;


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

        /// public propaty name  :  PayStMngNo
        /// <summary>�x���ݒ�Ǘ�No�v���p�e�B</summary>
        /// <value>0�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ�Ǘ�No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMngNo
        {
            get { return _payStMngNo; }
            set { _payStMngNo = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd1
        /// <summary>�x���ݒ����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd1
        {
            get { return _payStMoneyKindCd1; }
            set { _payStMoneyKindCd1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd2
        /// <summary>�x���ݒ����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd2
        {
            get { return _payStMoneyKindCd2; }
            set { _payStMoneyKindCd2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd3
        /// <summary>�x���ݒ����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd3
        {
            get { return _payStMoneyKindCd3; }
            set { _payStMoneyKindCd3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd4
        /// <summary>�x���ݒ����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd4
        {
            get { return _payStMoneyKindCd4; }
            set { _payStMoneyKindCd4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd5
        /// <summary>�x���ݒ����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd5
        {
            get { return _payStMoneyKindCd5; }
            set { _payStMoneyKindCd5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd6
        /// <summary>�x���ݒ����R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd6
        {
            get { return _payStMoneyKindCd6; }
            set { _payStMoneyKindCd6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd7
        /// <summary>�x���ݒ����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd7
        {
            get { return _payStMoneyKindCd7; }
            set { _payStMoneyKindCd7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd8
        /// <summary>�x���ݒ����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd8
        {
            get { return _payStMoneyKindCd8; }
            set { _payStMoneyKindCd8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd9
        /// <summary>�x���ݒ����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd9
        {
            get { return _payStMoneyKindCd9; }
            set { _payStMoneyKindCd9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd10
        /// <summary>�x���ݒ����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd10
        {
            get { return _payStMoneyKindCd10; }
            set { _payStMoneyKindCd10 = value; }
        }

        /// <summary>
        /// �x���ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PaymentSetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PaymentSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PaymentSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PaymentSetWork || graph is ArrayList || graph is PaymentSetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PaymentSetWork).FullName));

            if (graph != null && graph is PaymentSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PaymentSetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PaymentSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PaymentSetWork[])graph).Length;
            }
            else if (graph is PaymentSetWork)
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
            //�x���ݒ�Ǘ�No
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMngNo
            //�x���ݒ����R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd1
            //�x���ݒ����R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd2
            //�x���ݒ����R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd3
            //�x���ݒ����R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd4
            //�x���ݒ����R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd5
            //�x���ݒ����R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd6
            //�x���ݒ����R�[�h7
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd7
            //�x���ݒ����R�[�h8
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd8
            //�x���ݒ����R�[�h9
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd9
            //�x���ݒ����R�[�h10
            serInfo.MemberInfo.Add(typeof(Int32)); //PayStMoneyKindCd10


            serInfo.Serialize(writer, serInfo);
            if (graph is PaymentSetWork)
            {
                PaymentSetWork temp = (PaymentSetWork)graph;

                SetPaymentSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PaymentSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PaymentSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PaymentSetWork temp in lst)
                {
                    SetPaymentSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PaymentSetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  PaymentSetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPaymentSetWork(System.IO.BinaryWriter writer, PaymentSetWork temp)
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
            //�x���ݒ�Ǘ�No
            writer.Write(temp.PayStMngNo);
            //�x���ݒ����R�[�h1
            writer.Write(temp.PayStMoneyKindCd1);
            //�x���ݒ����R�[�h2
            writer.Write(temp.PayStMoneyKindCd2);
            //�x���ݒ����R�[�h3
            writer.Write(temp.PayStMoneyKindCd3);
            //�x���ݒ����R�[�h4
            writer.Write(temp.PayStMoneyKindCd4);
            //�x���ݒ����R�[�h5
            writer.Write(temp.PayStMoneyKindCd5);
            //�x���ݒ����R�[�h6
            writer.Write(temp.PayStMoneyKindCd6);
            //�x���ݒ����R�[�h7
            writer.Write(temp.PayStMoneyKindCd7);
            //�x���ݒ����R�[�h8
            writer.Write(temp.PayStMoneyKindCd8);
            //�x���ݒ����R�[�h9
            writer.Write(temp.PayStMoneyKindCd9);
            //�x���ݒ����R�[�h10
            writer.Write(temp.PayStMoneyKindCd10);

        }

        /// <summary>
        ///  PaymentSetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PaymentSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PaymentSetWork GetPaymentSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PaymentSetWork temp = new PaymentSetWork();

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
            //�x���ݒ�Ǘ�No
            temp.PayStMngNo = reader.ReadInt32();
            //�x���ݒ����R�[�h1
            temp.PayStMoneyKindCd1 = reader.ReadInt32();
            //�x���ݒ����R�[�h2
            temp.PayStMoneyKindCd2 = reader.ReadInt32();
            //�x���ݒ����R�[�h3
            temp.PayStMoneyKindCd3 = reader.ReadInt32();
            //�x���ݒ����R�[�h4
            temp.PayStMoneyKindCd4 = reader.ReadInt32();
            //�x���ݒ����R�[�h5
            temp.PayStMoneyKindCd5 = reader.ReadInt32();
            //�x���ݒ����R�[�h6
            temp.PayStMoneyKindCd6 = reader.ReadInt32();
            //�x���ݒ����R�[�h7
            temp.PayStMoneyKindCd7 = reader.ReadInt32();
            //�x���ݒ����R�[�h8
            temp.PayStMoneyKindCd8 = reader.ReadInt32();
            //�x���ݒ����R�[�h9
            temp.PayStMoneyKindCd9 = reader.ReadInt32();
            //�x���ݒ����R�[�h10
            temp.PayStMoneyKindCd10 = reader.ReadInt32();


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
        /// <returns>PaymentSetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PaymentSetWork temp = GetPaymentSetWork(reader, serInfo);
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
                    retValue = (PaymentSetWork[])lst.ToArray(typeof(PaymentSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

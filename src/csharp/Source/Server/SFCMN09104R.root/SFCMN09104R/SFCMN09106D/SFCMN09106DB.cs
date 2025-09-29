using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   NoTypeMngWork
    /// <summary>
    ///                      �ԍ��^�C�v�Ǘ����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԍ��^�C�v�Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2008/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class NoTypeMngWork : IFileHeader
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

        /// <summary>�ԍ��R�[�h</summary>
        /// <remarks>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</remarks>
        private Int32 _noCode;

        /// <summary>�ԍ�����</summary>
        private string _noName = "";

        /// <summary>�ԍ����ڌ^</summary>
        /// <remarks>0:���l 1:����</remarks>
        private Int32 _noItemPatternCd;

        /// <summary>�ԍ�����</summary>
        private Int32 _noCharcterCount;

        /// <summary>�ԍ��A�Ԍ���</summary>
        private Int32 _consNoCharcterCount;

        /// <summary>�ԍ��\���ʒu�敪</summary>
        /// <remarks>0:�E�l�� 1:���l��</remarks>
        private Int32 _noDispPositionDivCd;

        /// <summary>�ԍ��̔ԋ敪</summary>
        /// <remarks>0:�̔Ԗ��� 1:�̔ԗL��</remarks>
        private Int32 _numberingDivCd;

        /// <summary>�ԍ��̔ԃ^�C�v</summary>
        /// <remarks>0:�A�� 1:�ԍ��Ǘ��p���_�R�[�h2��+Y1��+M1��+�A��(�c�茅��)</remarks>
        private Int32 _numberingTypeDivCd;

        /// <summary>�ԍ��̔Ԕ͈�</summary>
        /// <remarks>0:��ƒʔ�(���_���薳��) 1:��ƒʔ�(���_����L��) 2:���_�ʔ�</remarks>
        private Int32 _numberingAmbitDivCd;

        /// <summary>�ԍ����Z�b�g�^�C�~���O</summary>
        /// <remarks>0:�ݒ�I���ԍ� 1:�N 2:�� 3:��</remarks>
        private Int32 _noResetTimingDivCd;


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

        /// public propaty name  :  NoCode
        /// <summary>�ԍ��R�[�h�v���p�e�B</summary>
        /// <value>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoCode
        {
            get { return _noCode; }
            set { _noCode = value; }
        }

        /// public propaty name  :  NoName
        /// <summary>�ԍ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NoName
        {
            get { return _noName; }
            set { _noName = value; }
        }

        /// public propaty name  :  NoItemPatternCd
        /// <summary>�ԍ����ڌ^�v���p�e�B</summary>
        /// <value>0:���l 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ����ڌ^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoItemPatternCd
        {
            get { return _noItemPatternCd; }
            set { _noItemPatternCd = value; }
        }

        /// public propaty name  :  NoCharcterCount
        /// <summary>�ԍ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoCharcterCount
        {
            get { return _noCharcterCount; }
            set { _noCharcterCount = value; }
        }

        /// public propaty name  :  ConsNoCharcterCount
        /// <summary>�ԍ��A�Ԍ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A�Ԍ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsNoCharcterCount
        {
            get { return _consNoCharcterCount; }
            set { _consNoCharcterCount = value; }
        }

        /// public propaty name  :  NoDispPositionDivCd
        /// <summary>�ԍ��\���ʒu�敪�v���p�e�B</summary>
        /// <value>0:�E�l�� 1:���l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��\���ʒu�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoDispPositionDivCd
        {
            get { return _noDispPositionDivCd; }
            set { _noDispPositionDivCd = value; }
        }

        /// public propaty name  :  NumberingDivCd
        /// <summary>�ԍ��̔ԋ敪�v���p�e�B</summary>
        /// <value>0:�̔Ԗ��� 1:�̔ԗL��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��̔ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberingDivCd
        {
            get { return _numberingDivCd; }
            set { _numberingDivCd = value; }
        }

        /// public propaty name  :  NumberingTypeDivCd
        /// <summary>�ԍ��̔ԃ^�C�v�v���p�e�B</summary>
        /// <value>0:�A�� 1:�ԍ��Ǘ��p���_�R�[�h2��+Y1��+M1��+�A��(�c�茅��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��̔ԃ^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberingTypeDivCd
        {
            get { return _numberingTypeDivCd; }
            set { _numberingTypeDivCd = value; }
        }

        /// public propaty name  :  NumberingAmbitDivCd
        /// <summary>�ԍ��̔Ԕ͈̓v���p�e�B</summary>
        /// <value>0:��ƒʔ�(���_���薳��) 1:��ƒʔ�(���_����L��) 2:���_�ʔ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��̔Ԕ͈̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberingAmbitDivCd
        {
            get { return _numberingAmbitDivCd; }
            set { _numberingAmbitDivCd = value; }
        }

        /// public propaty name  :  NoResetTimingDivCd
        /// <summary>�ԍ����Z�b�g�^�C�~���O�v���p�e�B</summary>
        /// <value>0:�ݒ�I���ԍ� 1:�N 2:�� 3:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ����Z�b�g�^�C�~���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoResetTimingDivCd
        {
            get { return _noResetTimingDivCd; }
            set { _noResetTimingDivCd = value; }
        }


        /// <summary>
        /// �ԍ��^�C�v�Ǘ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>NoTypeMngWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NoTypeMngWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>NoTypeMngWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class NoTypeMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  NoTypeMngWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is NoTypeMngWork || graph is ArrayList || graph is NoTypeMngWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(NoTypeMngWork).FullName));

            if (graph != null && graph is NoTypeMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoTypeMngWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is NoTypeMngWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((NoTypeMngWork[])graph).Length;
            }
            else if (graph is NoTypeMngWork)
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
            //�ԍ��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //NoCode
            //�ԍ�����
            serInfo.MemberInfo.Add(typeof(string)); //NoName
            //�ԍ����ڌ^
            serInfo.MemberInfo.Add(typeof(Int32)); //NoItemPatternCd
            //�ԍ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //NoCharcterCount
            //�ԍ��A�Ԍ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsNoCharcterCount
            //�ԍ��\���ʒu�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //NoDispPositionDivCd
            //�ԍ��̔ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingDivCd
            //�ԍ��̔ԃ^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingTypeDivCd
            //�ԍ��̔Ԕ͈�
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingAmbitDivCd
            //�ԍ����Z�b�g�^�C�~���O
            serInfo.MemberInfo.Add(typeof(Int32)); //NoResetTimingDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is NoTypeMngWork)
            {
                NoTypeMngWork temp = (NoTypeMngWork)graph;

                SetNoTypeMngWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is NoTypeMngWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((NoTypeMngWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (NoTypeMngWork temp in lst)
                {
                    SetNoTypeMngWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// NoTypeMngWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  NoTypeMngWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetNoTypeMngWork(System.IO.BinaryWriter writer, NoTypeMngWork temp)
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
            //�ԍ��R�[�h
            writer.Write(temp.NoCode);
            //�ԍ�����
            writer.Write(temp.NoName);
            //�ԍ����ڌ^
            writer.Write(temp.NoItemPatternCd);
            //�ԍ�����
            writer.Write(temp.NoCharcterCount);
            //�ԍ��A�Ԍ���
            writer.Write(temp.ConsNoCharcterCount);
            //�ԍ��\���ʒu�敪
            writer.Write(temp.NoDispPositionDivCd);
            //�ԍ��̔ԋ敪
            writer.Write(temp.NumberingDivCd);
            //�ԍ��̔ԃ^�C�v
            writer.Write(temp.NumberingTypeDivCd);
            //�ԍ��̔Ԕ͈�
            writer.Write(temp.NumberingAmbitDivCd);
            //�ԍ����Z�b�g�^�C�~���O
            writer.Write(temp.NoResetTimingDivCd);

        }

        /// <summary>
        ///  NoTypeMngWork�C���X�^���X�擾
        /// </summary>
        /// <returns>NoTypeMngWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private NoTypeMngWork GetNoTypeMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            NoTypeMngWork temp = new NoTypeMngWork();

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
            //�ԍ��R�[�h
            temp.NoCode = reader.ReadInt32();
            //�ԍ�����
            temp.NoName = reader.ReadString();
            //�ԍ����ڌ^
            temp.NoItemPatternCd = reader.ReadInt32();
            //�ԍ�����
            temp.NoCharcterCount = reader.ReadInt32();
            //�ԍ��A�Ԍ���
            temp.ConsNoCharcterCount = reader.ReadInt32();
            //�ԍ��\���ʒu�敪
            temp.NoDispPositionDivCd = reader.ReadInt32();
            //�ԍ��̔ԋ敪
            temp.NumberingDivCd = reader.ReadInt32();
            //�ԍ��̔ԃ^�C�v
            temp.NumberingTypeDivCd = reader.ReadInt32();
            //�ԍ��̔Ԕ͈�
            temp.NumberingAmbitDivCd = reader.ReadInt32();
            //�ԍ����Z�b�g�^�C�~���O
            temp.NoResetTimingDivCd = reader.ReadInt32();


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
        /// <returns>NoTypeMngWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoTypeMngWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                NoTypeMngWork temp = GetNoTypeMngWork(reader, serInfo);
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
                    retValue = (NoTypeMngWork[])lst.ToArray(typeof(NoTypeMngWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

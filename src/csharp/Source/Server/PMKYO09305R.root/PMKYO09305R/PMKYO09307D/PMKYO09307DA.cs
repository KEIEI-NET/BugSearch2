//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�t�@�C����ۑ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ServiceFilesWork
    /// <summary>
    ///                      �T�[�r�X�t�@�C�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �T�[�r�X�t�@�C�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/23  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   ���i���̃J�i</br>
    /// <br>Update Note      :   2008/9/25  ����</br>
    /// <br>                 :   �����ڍ폜</br>
    /// <br>                 :   �q�ɔ��l2</br>
    /// <br>                 :   �q�ɔ��l3</br>
    /// <br>                 :   �q�ɔ��l4</br>
    /// <br>                 :   �q�ɔ��l5 </br>
    /// <br>Update Note      :   2009/1/21  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �ړ����z</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ServiceFilesWork
    {
        /// <summary>�t�@�C�����e</summary>
        private Byte[] _fileContent;


        /// public propaty name  :  FileContent
        /// <summary>�t�@�C�����e�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }


        /// <summary>
        /// �T�[�r�X�t�@�C�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ServiceFilesWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ServiceFilesWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ServiceFilesWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ServiceFilesWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ServiceFilesWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ServiceFilesWork || graph is ArrayList || graph is ServiceFilesWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ServiceFilesWork).FullName));

            if (graph != null && graph is ServiceFilesWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ServiceFilesWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ServiceFilesWork[])graph).Length;
            }
            else if (graph is ServiceFilesWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�t�@�C�����e
            serInfo.MemberInfo.Add(typeof(Byte[])); //FileContent


            serInfo.Serialize(writer, serInfo);
            if (graph is ServiceFilesWork)
            {
                ServiceFilesWork temp = (ServiceFilesWork)graph;

                SetServiceFilesWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ServiceFilesWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ServiceFilesWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ServiceFilesWork temp in lst)
                {
                    SetServiceFilesWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ServiceFilesWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 1;

        /// <summary>
        ///  ServiceFilesWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetServiceFilesWork(System.IO.BinaryWriter writer, ServiceFilesWork temp)
        {
            //�t�@�C�����e
            writer.Write(temp.FileContent.Length);
            writer.Write(temp.FileContent);

        }

        /// <summary>
        ///  ServiceFilesWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ServiceFilesWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ServiceFilesWork GetServiceFilesWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ServiceFilesWork temp = new ServiceFilesWork();

            //�t�@�C�����e
            int length = reader.ReadInt32();
            temp.FileContent = reader.ReadBytes(length);


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
        /// <returns>ServiceFilesWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ServiceFilesWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ServiceFilesWork temp = GetServiceFilesWork(reader, serInfo);
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
                    retValue = (ServiceFilesWork[])lst.ToArray(typeof(ServiceFilesWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


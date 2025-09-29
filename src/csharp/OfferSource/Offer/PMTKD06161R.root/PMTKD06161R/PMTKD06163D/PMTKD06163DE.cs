using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsTrimWork
    /// <summary>
    ///                      ���i�g�����R�[�h���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�g�����R�[�h���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/5/6</br>
    /// <br>Genarated Date   :   2005/05/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsTrimWork
    {
        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>���i�ŗL�ԍ�</summary>
        private Int64 _partsproperno;

        /// <summary>���i�ŗL�ԍ�</summary>
        public Int64 PartsProperNo
        {
            get { return _partsproperno; }
            set { _partsproperno = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }
        /// <summary>
        /// ���i�g�����R�[�h���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsTrimWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsTrimWork()
        {
        }
        /// <summary>
        /// ���i�g�����R�[�h���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <param name="partsProperno"></param>
        /// <returns>PartsTrimWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsTrimWork(string trimCode, Int64 partsProperno)
        {
            this._trimCode = trimCode;
            this._partsproperno = partsProperno;
        }
        /// <summary>
        /// ���i�g�����R�[�h���[�N��������
        /// </summary>
        /// <returns>PartsTrimWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PartsTrimWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsTrimWork Clone()
        {
            return new PartsTrimWork(this._trimCode, this._partsproperno);
        }
    }

    /// <summary>
    ///  Ver5.1.0.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsTrimWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsTrimWork_SerializationSurrogate_For_V5100 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o
        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V5100.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsTrimWork || graph is ArrayList))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsTrimWork).FullName));

            if (graph != null && graph is PartsTrimWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsTrimWork)
            {
                occurrence = 1;
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.1.0.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsTrimWork");
            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int64));


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsTrimWork)
            {
                PartsTrimWork temp = (PartsTrimWork)graph;

                writer.Write(temp.TrimCode);
                writer.Write(temp.PartsProperNo);

            }
            else if (graph is ArrayList)
            {
                ArrayList lst = (ArrayList)graph;
                for (int i = 0; i < occurrence; ++i)
                {

                    PartsTrimWork temp = (PartsTrimWork)lst[i];

                    writer.Write(temp.TrimCode);
                    writer.Write(temp.PartsProperNo);

                }

            }
        }

        /// <summary>
        /// PartsTrimWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 2;

        /// <summary>
        ///  PartsTrimWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsTrimWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsTrimWork GetPartsTrimWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsTrimWork temp = new PartsTrimWork();

            temp.TrimCode = reader.ReadString();
            temp.PartsProperNo = reader.ReadInt64();


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
        ///  Ver5.1.0.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>PartsTrimWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsTrimWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsTrimWork temp = GetPartsTrimWork(reader, serInfo);
                lst.Add(temp);
            }
            retValue = lst;
            return retValue;
        }

        #endregion
    }

}

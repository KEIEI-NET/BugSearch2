using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BaseCodeNameWork
    /// <summary>
    ///                      �ԕi�s�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԕi�s�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/3/13</br>
    /// <br>Genarated Date   :   2009/05/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BaseCodeNameWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sectionGuideNm = "";

        /// <summary>�V���N���s���t</summary>
        /// <remarks>�ŏI���M��</remarks>
        private DateTime _syncExecDate;

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

        /// public propaty name  :  SyncExecDate
        /// <summary>�V���N���s���t�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
        }

        /// <summary>
        /// �ԕi�s�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>BaseCodeNameWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BaseCodeNameWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>BaseCodeNameWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class BaseCodeNameWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BaseCodeNameWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BaseCodeNameWork || graph is ArrayList || graph is BaseCodeNameWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(BaseCodeNameWork).FullName));

            if (graph != null && graph is BaseCodeNameWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BaseCodeNameWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BaseCodeNameWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BaseCodeNameWork[])graph).Length;
            }
            else if (graph is BaseCodeNameWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�V���N���s���t
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate


            serInfo.Serialize(writer, serInfo);
            if (graph is BaseCodeNameWork)
            {
                BaseCodeNameWork temp = (BaseCodeNameWork)graph;

                SetBaseCodeNameWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BaseCodeNameWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BaseCodeNameWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BaseCodeNameWork temp in lst)
                {
                    SetBaseCodeNameWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BaseCodeNameWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  BaseCodeNameWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetBaseCodeNameWork(System.IO.BinaryWriter writer, BaseCodeNameWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�V���N���s���t
            writer.Write((Int64)temp.SyncExecDate.Ticks);

        }

        /// <summary>
        ///  BaseCodeNameWork�C���X�^���X�擾
        /// </summary>
        /// <returns>BaseCodeNameWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private BaseCodeNameWork GetBaseCodeNameWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            BaseCodeNameWork temp = new BaseCodeNameWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�V���N���s���t
            temp.SyncExecDate = new DateTime(reader.ReadInt64());


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
        /// <returns>BaseCodeNameWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BaseCodeNameWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BaseCodeNameWork temp = GetBaseCodeNameWork(reader, serInfo);
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
                    retValue = (BaseCodeNameWork[])lst.ToArray(typeof(BaseCodeNameWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

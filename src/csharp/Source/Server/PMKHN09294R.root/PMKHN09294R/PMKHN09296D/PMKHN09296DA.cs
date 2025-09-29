//****************************************************************************//
// �V�X�e��         : RC.NS
// �v���O��������   : �o�b�N�A�b�v���������擾���ʃ��[�N
// �v���O�����T�v   : �o�b�N�A�b�v���������擾���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.06.22  �C�����e : �V�K�쐬
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
    /// public class name:   BackUpExecutionWork
    /// <summary>
    ///                      �o�b�N�A�b�v���������擾���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�b�N�A�b�v���������擾���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.06.22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BackUpExecutionWork 
    {
        /// <summary>�����J�n����</summary>
        /// <remarks>�����J�n���ԁistring:���x��100�i�m�b�j</remarks>
        private string _startDateTime;

        /// <summary>�����I������</summary>
        /// <remarks>�����I�����ԁistring:���x��100�i�m�b�j</remarks>
        private string _endDateTime;

        /// <summary>�o�b�N�A�b�v�t�@�C����</summary>
        private string _fileName = "";

        /// <summary>DBVersion</summary>
        private string _dBVersion = "";

        /// <summary>��������</summary>
        private string _resultContent = "";

        /// <summary>�X�e�[�^�X</summary>
        private Int32 _status;

        /// public propaty name  :  StartDateTime
        /// <summary>�����J�n����</summary>
        /// <value>�����J�n���ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�n����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>�����I������</summary>
        /// <value>�����I�����ԁiDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����I������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>�o�b�N�A�b�v�t�@�C����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�t�@�C����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  DBVersion
        /// <summary>DBVersion</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DBVersion</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DBVersion
        {
            get { return _dBVersion; }
            set { _dBVersion = value; }
        }

        /// public propaty name  :  ResultContent
        /// <summary>��������</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultContent
        {
            get { return _resultContent; }
            set { _resultContent = value; }
        }

        /// public propaty name  :  Status
        /// <summary>�X�e�[�^�X</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�e�[�^�X</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Status
        {
            get { return _status; }
            set { _status = value; }
        }



        /// <summary>
        /// �o�b�N�A�b�v���������擾���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>BackUpExecutionWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BackUpExecutionWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>BackUpExecutionWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class BackUpExecutionWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BackUpExecutionWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BackUpExecutionWork || graph is ArrayList || graph is BackUpExecutionWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(BackUpExecutionWork).FullName));

            if (graph != null && graph is BackUpExecutionWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BackUpExecutionWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BackUpExecutionWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BackUpExecutionWork[])graph).Length;
            }
            else if (graph is BackUpExecutionWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�����J�n����
            serInfo.MemberInfo.Add(typeof(string)); //StartDateTime
            //�����I������
            serInfo.MemberInfo.Add(typeof(string)); //EndDateTime
            //�o�b�N�A�b�v�t�@�C����
            serInfo.MemberInfo.Add(typeof(string)); //FileName
            //DBVersion
            serInfo.MemberInfo.Add(typeof(string)); //DBVersion
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //ResultContent
            //�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //Status



            serInfo.Serialize(writer, serInfo);
            if (graph is BackUpExecutionWork)
            {
                BackUpExecutionWork temp = (BackUpExecutionWork)graph;

                SetBackUpExecutionWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BackUpExecutionWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BackUpExecutionWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BackUpExecutionWork temp in lst)
                {
                    SetBackUpExecutionWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BackUpExecutionWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  BackUpExecutionWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetBackUpExecutionWork(System.IO.BinaryWriter writer, BackUpExecutionWork temp)
        {
            //�����J�n����
            //writer.Write((Int64)temp.StartDateTime.Ticks);
            writer.Write(temp.StartDateTime);
            //�����I������
            //writer.Write((Int64)temp.EndDateTime.Ticks);
            writer.Write(temp.EndDateTime);
            //�o�b�N�A�b�v�t�@�C����
            writer.Write(temp.FileName);
            //DBVersion
            writer.Write(temp.DBVersion);
            //��������
            writer.Write(temp.ResultContent);
            //�X�e�[�^�X
            writer.Write((Int32)temp.Status);


        }

        /// <summary>
        ///  BackUpExecutionWork�C���X�^���X�擾
        /// </summary>
        /// <returns>BackUpExecutionWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private BackUpExecutionWork GetBackUpExecutionWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            BackUpExecutionWork temp = new BackUpExecutionWork();

            //�����J�n����
            //temp.StartDateTime = new DateTime(reader.ReadInt64());
            temp.StartDateTime = reader.ReadString();
            //�����I������
            //temp.EndDateTime = new DateTime(reader.ReadInt64());
            temp.EndDateTime = reader.ReadString();
            //�o�b�N�A�b�v�t�@�C����
            temp.FileName = reader.ReadString();
            //DBVersion
            temp.DBVersion = reader.ReadString();
            //��������
            temp.ResultContent = reader.ReadString();
            //�X�e�[�^�X
            temp.Status = reader.ReadInt32();



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
        /// <returns>BackUpExecutionWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BackUpExecutionWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BackUpExecutionWork temp = GetBackUpExecutionWork(reader, serInfo);
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
                    retValue = (BackUpExecutionWork[])lst.ToArray(typeof(BackUpExecutionWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

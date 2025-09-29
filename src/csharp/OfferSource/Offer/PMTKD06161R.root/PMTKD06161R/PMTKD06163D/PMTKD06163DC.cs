using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RetTbsPartsCodeWork
    /// <summary>
    ///                      �a�k���̎擾���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �a�k���̎擾���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �n���h���C�h</br>
    /// <br>Date             :   2007/03/06</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetTbsPartsCodeWork
    {
        /// <summary>�a�k�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>�a�k�R�[�h���́i�S�p�j</summary>
        private string _tbsPartsFullName = "";

        /// <summary>�a�k�R�[�h���́i���p�j</summary>
        private string _tbsPartsHalfName = "";

        /// <summary>��������</summary>
        /// <remarks>��j1001�F�o�b�e��</remarks>
        private Int32 _equipGenre;

        /// <summary>�D�ǌ����敪</summary>
        /// <remarks>0�F�D�ǌ��������@1�F�D�ǌ����L��</remarks>
        private Int32 _primeSearchFlg;

        /// public propaty name  :  TbsPartsCode
        /// <summary>�a�k�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsFullName
        /// <summary>�a�k�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TbsPartsFullName
        {
            get { return _tbsPartsFullName; }
            set { _tbsPartsFullName = value; }
        }

        /// public propaty name  :  TbsPartsHalfName
        /// <summary>�a�k�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TbsPartsHalfName
        {
            get { return _tbsPartsHalfName; }
            set { _tbsPartsHalfName = value; }
        }

        /// public propaty name  :  EquipGenre
        /// <summary>�������ރv���p�e�B</summary>
        /// <value>��j1001�F�o�b�e��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipGenre
        {
            get { return _equipGenre; }
            set { _equipGenre = value; }
        }

        /// public propaty name  :  PrimeSearchFlg
        /// <summary>�D�ǌ����敪�v���p�e�B</summary>
        /// <value>0�F�D�ǌ��������@1�F�D�ǌ����L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǌ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrimeSearchFlg
        {
            get { return _primeSearchFlg; }
            set { _primeSearchFlg = value; }
        }

        /// <summary>
        /// �a�k���̎擾���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RetTbsPartsCodeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RetTbsPartsCodeWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RetTbsPartsCodeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RetTbsPartsCodeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RetTbsPartsCodeWork || graph is ArrayList || graph is RetTbsPartsCodeWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RetTbsPartsCodeWork).FullName));

            if (graph != null && graph is RetTbsPartsCodeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RetTbsPartsCodeWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RetTbsPartsCodeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RetTbsPartsCodeWork[])graph).Length;
            }
            else if (graph is RetTbsPartsCodeWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�a�k�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //tbspartscode
            //�a�k�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //tbspartsfullname
            //�a�k�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //tbspartshalfname
            //��������
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenre
            //�D�ǌ����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeSearchFlg

            serInfo.Serialize(writer, serInfo);
            if (graph is RetTbsPartsCodeWork)
            {
                RetTbsPartsCodeWork temp = (RetTbsPartsCodeWork)graph;

                SetRetTbsPartsCodeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RetTbsPartsCodeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RetTbsPartsCodeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RetTbsPartsCodeWork temp in lst)
                {
                    SetRetTbsPartsCodeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RetTbsPartsCodeWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  RetTbsPartsCodeWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRetTbsPartsCodeWork(System.IO.BinaryWriter writer, RetTbsPartsCodeWork temp)
        {
            //�a�k�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�a�k�R�[�h���́i�S�p�j
            writer.Write(temp.TbsPartsFullName);
            //�a�k�R�[�h���́i���p�j
            writer.Write(temp.TbsPartsHalfName);
            //��������
            writer.Write(temp.EquipGenre);
            //�D�ǌ����敪
            writer.Write(temp.PrimeSearchFlg);
        }

        /// <summary>
        ///  RetTbsPartsCodeWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RetTbsPartsCodeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetTbsPartsCodeWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RetTbsPartsCodeWork GetRetTbsPartsCodeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RetTbsPartsCodeWork temp = new RetTbsPartsCodeWork();

            //�a�k�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�a�k�R�[�h���́i�S�p�j
            temp.TbsPartsFullName = reader.ReadString();
            //�a�k�R�[�h���́i���p�j
            temp.TbsPartsHalfName = reader.ReadString();
            //��������
            temp.EquipGenre = reader.ReadInt32();
            //�D�ǌ����敪
            temp.PrimeSearchFlg = reader.ReadInt32();

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
        /// <returns>PartsSubstWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RetTbsPartsCodeWork temp = GetRetTbsPartsCodeWork(reader, serInfo);
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
                    retValue = (RetTbsPartsCodeWork[])lst.ToArray(typeof(RetTbsPartsCodeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	�񋟃f�[�^�폜���� �f�[�^�p�����[�^             //
//					:	PMTKD01106D.DLL									//
// Name Space		:	Broadleaf.Application.Remoting.ParamData    	//
// Programmer		:	�������@                                        //
// Date				:	2009.06.16										//
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferDataDeleteWork
    /// <summary>
    ///                      �񋟃f�[�^�폜�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟃f�[�^�폜�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/26  ��</br>
    /// <br>                 :   �����敪�ǉ��B</br>
    /// <br>                 :   �L�[�ύX</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferDataDeleteWork
    {
        /// <summary>�e�[�u����</summary>
        private string _tableName = "";

        /// <summary>�e�[�u���h�c</summary>
        private string _tableID = "";

        /// <summary>�����R�[�h</summary>
        /// <remarks>�q�R�[�h�i�q�R�[�h���[���̏ꍇ�́A�e�R�[�h�̖��́j</remarks>
        private Int32 _code;

        /// <summary>�����t�B�[���h</summary>
        private string _field = "";

        /// <summary>��������</summary>
        private string _result = "";


        /// public propaty name  :  TableName
        /// <summary>�e�[�u�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�[�u�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// public propaty name  :  TableID
        /// <summary>�e�[�u���h�c�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�[�u���h�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }

        /// public propaty name  :  Code
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// <value>�q�R�[�h�i�q�R�[�h���[���̏ꍇ�́A�e�R�[�h�̖��́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// public propaty name  :  Field
        /// <summary>�����t�B�[���h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����t�B�[���h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        /// public propaty name  :  Result
        /// <summary>�������ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }


        /// <summary>
        /// �񋟃f�[�^�폜�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfferDataDeleteWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfferDataDeleteWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OfferDataDeleteWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OfferDataDeleteWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferDataDeleteWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferDataDeleteWork || graph is ArrayList || graph is OfferDataDeleteWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfferDataDeleteWork).FullName));

            if (graph != null && graph is OfferDataDeleteWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferDataDeleteWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferDataDeleteWork[])graph).Length;
            }
            else if (graph is OfferDataDeleteWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�e�[�u����
            serInfo.MemberInfo.Add(typeof(string)); //TableName
            //�e�[�u���h�c
            serInfo.MemberInfo.Add(typeof(string)); //TableID
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //Code
            //�����t�B�[���h
            serInfo.MemberInfo.Add(typeof(string)); //Field
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //Result


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferDataDeleteWork)
            {
                OfferDataDeleteWork temp = (OfferDataDeleteWork)graph;

                SetOfferDataDeleteWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferDataDeleteWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferDataDeleteWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferDataDeleteWork temp in lst)
                {
                    SetOfferDataDeleteWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferDataDeleteWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  OfferDataDeleteWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOfferDataDeleteWork(System.IO.BinaryWriter writer, OfferDataDeleteWork temp)
        {
            //�e�[�u����
            writer.Write(temp.TableName);
            //�e�[�u���h�c
            writer.Write(temp.TableID);
            //�����R�[�h
            writer.Write(temp.Code);
            //�����t�B�[���h
            writer.Write(temp.Field);
            //��������
            writer.Write(temp.Result);

        }

        /// <summary>
        ///  OfferDataDeleteWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OfferDataDeleteWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OfferDataDeleteWork GetOfferDataDeleteWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OfferDataDeleteWork temp = new OfferDataDeleteWork();

            //�e�[�u����
            temp.TableName = reader.ReadString();
            //�e�[�u���h�c
            temp.TableID = reader.ReadString();
            //�����R�[�h
            temp.Code = reader.ReadInt32();
            //�����t�B�[���h
            temp.Field = reader.ReadString();
            //��������
            temp.Result = reader.ReadString();


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
        /// <returns>OfferDataDeleteWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferDataDeleteWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferDataDeleteWork temp = GetOfferDataDeleteWork(reader, serInfo);
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
                    retValue = (OfferDataDeleteWork[])lst.ToArray(typeof(OfferDataDeleteWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

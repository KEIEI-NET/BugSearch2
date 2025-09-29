using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CtgryEquipWork
    /// <summary>
    ///                      �ޕʑ������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ޕʑ������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/04/06</br>
    /// <br>Genarated Date   :   2008/07/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CtgryEquipWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>�������ރR�[�h</summary>
        private Int32 _equipmentGenreCd;

        /// <summary>�������ޖ���</summary>
        private string _equipmentGenreNm = "";

        /// <summary>�����R�[�h</summary>
        private Int32 _equipmentCode;

        /// <summary>��������</summary>
        private string _equipmentName = "";

        /// <summary>��������</summary>
        private string _equipmentShortName = "";

        /// <summary>����ICON�R�[�h</summary>
        private Int32 _equipmentIconCode;


        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  EquipmentGenreCd
        /// <summary>�������ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipmentGenreCd
        {
            get { return _equipmentGenreCd; }
            set { _equipmentGenreCd = value; }
        }

        /// public propaty name  :  EquipmentGenreNm
        /// <summary>�������ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipmentGenreNm
        {
            get { return _equipmentGenreNm; }
            set { _equipmentGenreNm = value; }
        }

        /// public propaty name  :  EquipmentCode
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipmentCode
        {
            get { return _equipmentCode; }
            set { _equipmentCode = value; }
        }

        /// public propaty name  :  EquipmentName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipmentName
        {
            get { return _equipmentName; }
            set { _equipmentName = value; }
        }

        /// public propaty name  :  EquipmentShortName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipmentShortName
        {
            get { return _equipmentShortName; }
            set { _equipmentShortName = value; }
        }

        /// public propaty name  :  EquipmentIconCode
        /// <summary>����ICON�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ICON�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipmentIconCode
        {
            get { return _equipmentIconCode; }
            set { _equipmentIconCode = value; }
        }


        /// <summary>
        /// �ޕʑ������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CtgryEquipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CtgryEquipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CtgryEquipWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CtgryEquipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CtgryEquipWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CtgryEquipWork || graph is ArrayList || graph is CtgryEquipWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CtgryEquipWork).FullName));

            if (graph != null && graph is CtgryEquipWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CtgryEquipWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CtgryEquipWork[])graph).Length;
            }
            else if (graph is CtgryEquipWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //�������ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
            //�������ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
            //����ICON�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode


            serInfo.Serialize(writer, serInfo);
            if (graph is CtgryEquipWork)
            {
                CtgryEquipWork temp = (CtgryEquipWork)graph;

                SetCtgryEquipWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CtgryEquipWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CtgryEquipWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CtgryEquipWork temp in lst)
                {
                    SetCtgryEquipWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CtgryEquipWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  CtgryEquipWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCtgryEquipWork(System.IO.BinaryWriter writer, CtgryEquipWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //�������ރR�[�h
            writer.Write(temp.EquipmentGenreCd);
            //�������ޖ���
            writer.Write(temp.EquipmentGenreNm);
            //�����R�[�h
            writer.Write(temp.EquipmentCode);
            //��������
            writer.Write(temp.EquipmentName);
            //��������
            writer.Write(temp.EquipmentShortName);
            //����ICON�R�[�h
            writer.Write(temp.EquipmentIconCode);

        }

        /// <summary>
        ///  CtgryEquipWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CtgryEquipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CtgryEquipWork GetCtgryEquipWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CtgryEquipWork temp = new CtgryEquipWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //�������ރR�[�h
            temp.EquipmentGenreCd = reader.ReadInt32();
            //�������ޖ���
            temp.EquipmentGenreNm = reader.ReadString();
            //�����R�[�h
            temp.EquipmentCode = reader.ReadInt32();
            //��������
            temp.EquipmentName = reader.ReadString();
            //��������
            temp.EquipmentShortName = reader.ReadString();
            //����ICON�R�[�h
            temp.EquipmentIconCode = reader.ReadInt32();


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
        /// <returns>CtgryEquipWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CtgryEquipWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CtgryEquipWork temp = GetCtgryEquipWork(reader, serInfo);
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
                    retValue = (CtgryEquipWork[])lst.ToArray(typeof(CtgryEquipWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PMakerNmWork
    /// <summary>
    ///                      ���i���[�J�[���́i�񋟁j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���[�J�[���́i�񋟁j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/03/07</br>
    /// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PMakerNmWork : IFileHeaderOffer2
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _partsMakerCode;

        /// <summary>���i���[�J�[���́i�S�p�j</summary>
        private string _partsMakerFullName = "";

        /// <summary>���i���[�J�[���́i���p�j</summary>
        private string _partsMakerHalfName = "";


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

        /// public propaty name  :  PartsMakerCode
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// public propaty name  :  PartsMakerFullName
        /// <summary>���i���[�J�[���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsMakerFullName
        {
            get { return _partsMakerFullName; }
            set { _partsMakerFullName = value; }
        }

        /// public propaty name  :  PartsMakerHalfName
        /// <summary>���i���[�J�[���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsMakerHalfName
        {
            get { return _partsMakerHalfName; }
            set { _partsMakerHalfName = value; }
        }


        /// <summary>
        /// ���i���[�J�[���́i�񋟁j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PMakerNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PMakerNmWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PMakerNmWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PMakerNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PMakerNmWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PMakerNmWork || graph is ArrayList || graph is PMakerNmWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PMakerNmWork).FullName));

            if (graph != null && graph is PMakerNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PMakerNmWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PMakerNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PMakerNmWork[])graph).Length;
            }
            else if (graph is PMakerNmWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCode
            //���i���[�J�[���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerFullName
            //���i���[�J�[���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is PMakerNmWork)
            {
                PMakerNmWork temp = (PMakerNmWork)graph;

                SetPMakerNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PMakerNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PMakerNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PMakerNmWork temp in lst)
                {
                    SetPMakerNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PMakerNmWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  PMakerNmWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPMakerNmWork(System.IO.BinaryWriter writer, PMakerNmWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCode);
            //���i���[�J�[���́i�S�p�j
            writer.Write(temp.PartsMakerFullName);
            //���i���[�J�[���́i���p�j
            writer.Write(temp.PartsMakerHalfName);

        }

        /// <summary>
        ///  PMakerNmWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PMakerNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PMakerNmWork GetPMakerNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PMakerNmWork temp = new PMakerNmWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCode = reader.ReadInt32();
            //���i���[�J�[���́i�S�p�j
            temp.PartsMakerFullName = reader.ReadString();
            //���i���[�J�[���́i���p�j
            temp.PartsMakerHalfName = reader.ReadString();


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
        /// <returns>PMakerNmWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMakerNmWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PMakerNmWork temp = GetPMakerNmWork(reader, serInfo);
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
                    retValue = (PMakerNmWork[])lst.ToArray(typeof(PMakerNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

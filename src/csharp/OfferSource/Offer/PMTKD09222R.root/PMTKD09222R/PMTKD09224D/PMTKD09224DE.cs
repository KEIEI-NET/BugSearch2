using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceUpdManualDataWork
    /// <summary>
    ///                      ���i�����������t�擾(�蓮)�f�[�^�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�����������t�擾(�蓮)�f�[�^�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceUpdManualDataWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>�ŐV�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reNewOfferDate;

        /// <summary>�Ώۃf�[�^����</summary>
        private Int32 _dataCnt;

        /// <summary>�S�Ώۃf�[�^����</summary>
        private Int32 _allDatacnt;

        /// <summary>�Ώۃf�[�^�敪</summary>
        /// <remarks>0:BL�R�[�h�}�X�^,1:BL�O���[�v�}�X�^,2:�����ރ}�X�^,3:�Ԏ�}�X�^,4:���[�J�[�}�X�^,5:�D�ǐݒ�ύX�}�X�^</remarks>
        private Int32 _dataDiv;


        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  ReNewOfferDate
        /// <summary>�ŐV�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŐV�񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReNewOfferDate
        {
            get { return _reNewOfferDate; }
            set { _reNewOfferDate = value; }
        }

        /// public propaty name  :  dataCnt
        /// <summary>�Ώۃf�[�^�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۃf�[�^�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 dataCnt
        {
            get { return _dataCnt; }
            set { _dataCnt = value; }
        }

        /// public propaty name  :  allDatacnt
        /// <summary>�S�Ώۃf�[�^�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S�Ώۃf�[�^�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 allDatacnt
        {
            get { return _allDatacnt; }
            set { _allDatacnt = value; }
        }

        /// public propaty name  :  dataDiv
        /// <summary>�Ώۃf�[�^�敪�v���p�e�B</summary>
        /// <value>0:BL�R�[�h�}�X�^,1:BL�O���[�v�}�X�^,2:�����ރ}�X�^,3:�Ԏ�}�X�^,4:���[�J�[�}�X�^,5:�D�ǐݒ�ύX�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۃf�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 dataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }


        /// <summary>
        /// ���i�����������t�擾(�蓮)�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PriceUpdManualDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceUpdManualDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PriceUpdManualDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PriceUpdManualDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PriceUpdManualDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PriceUpdManualDataWork || graph is ArrayList || graph is PriceUpdManualDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PriceUpdManualDataWork).FullName));

            if (graph != null && graph is PriceUpdManualDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PriceUpdManualDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PriceUpdManualDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PriceUpdManualDataWork[])graph).Length;
            }
            else if (graph is PriceUpdManualDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�ŐV�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //ReNewOfferDate
            //�Ώۃf�[�^����
            serInfo.MemberInfo.Add(typeof(Int32)); //dataCnt
            //�S�Ώۃf�[�^����
            serInfo.MemberInfo.Add(typeof(Int32)); //allDatacnt
            //�Ώۃf�[�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //dataDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PriceUpdManualDataWork)
            {
                PriceUpdManualDataWork temp = (PriceUpdManualDataWork)graph;

                SetPriceUpdManualDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PriceUpdManualDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PriceUpdManualDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PriceUpdManualDataWork temp in lst)
                {
                    SetPriceUpdManualDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PriceUpdManualDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  PriceUpdManualDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPriceUpdManualDataWork(System.IO.BinaryWriter writer, PriceUpdManualDataWork temp)
        {
            //�񋟓��t
            writer.Write((Int64)temp.OfferDate.Ticks);
            //�ŐV�񋟓��t
            writer.Write((Int64)temp.OfferDate.Ticks);
            //�Ώۃf�[�^����
            writer.Write(temp.dataCnt);
            //�S�Ώۃf�[�^����
            writer.Write(temp.allDatacnt);
            //�Ώۃf�[�^�敪
            writer.Write(temp.dataDiv);

        }

        /// <summary>
        ///  PriceUpdManualDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PriceUpdManualDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PriceUpdManualDataWork GetPriceUpdManualDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PriceUpdManualDataWork temp = new PriceUpdManualDataWork();

            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //�ŐV�񋟓��t
            temp.ReNewOfferDate = new DateTime(reader.ReadInt64());
            //�Ώۃf�[�^����
            temp.dataCnt = reader.ReadInt32();
            //�S�Ώۃf�[�^����
            temp.allDatacnt = reader.ReadInt32();
            //�Ώۃf�[�^�敪
            temp.dataDiv = reader.ReadInt32();


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
        /// <returns>PriceUpdManualDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceUpdManualDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PriceUpdManualDataWork temp = GetPriceUpdManualDataWork(reader, serInfo);
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
                    retValue = (PriceUpdManualDataWork[])lst.ToArray(typeof(PriceUpdManualDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

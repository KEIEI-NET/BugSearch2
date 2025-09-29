using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmPrtPriceWork
    /// <summary>
    ///                      �D�ǉ��i���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�ǉ��i���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/5/12</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      : �����ށABL�R�[�h�ǉ�(MANTIS[0015332])</br>
    /// <br>Programmer       : 21024�@���X�� ��</br>
    /// <br>Date             : 2010/04/26</br>    
    /// </remarks>
    [Serializable]

    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmPrtPriceWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>�Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _partsMakerCd;

        /// <summary>�D�Ǖi��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>�V���i</summary>
        private Double _newPrice;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;

        // 2010/04/26 Add >>>
        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;
        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;
        // 2010/04/26 Add <<<


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

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
        /// <value>�Z���N�g�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>�D�Ǖi��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖi��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  NewPrice
        /// <summary>�V���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewPrice
        {
            get { return _newPrice; }
            set { _newPrice = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        // 2010/04/26 Add >>>
        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        // 2010/04/26 Add <<<

        /// <summary>
        /// �D�ǉ��i���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmPrtPriceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrmPrtPriceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmPrtPriceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrmPrtPriceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmPrtPriceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmPrtPriceWork || graph is ArrayList || graph is PrmPrtPriceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmPrtPriceWork).FullName));

            if (graph != null && graph is PrmPrtPriceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmPrtPriceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmPrtPriceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmPrtPriceWork[])graph).Length;
            }
            else if (graph is PrmPrtPriceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //�D�Ǖi��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //�V���i
            serInfo.MemberInfo.Add(typeof(Double)); //NewPrice
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv

            // 2010/04/26 Add >>>
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            // 2010/04/26 Add <<<


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmPrtPriceWork)
            {
                PrmPrtPriceWork temp = (PrmPrtPriceWork)graph;

                SetPrmPrtPriceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmPrtPriceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmPrtPriceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmPrtPriceWork temp in lst)
                {
                    SetPrmPrtPriceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmPrtPriceWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2010/04/26 Add >>>
        //private const int currentMemberCount = 7;
        private const int currentMemberCount = 9;
        // 2010/04/26 Add <<<

        /// <summary>
        ///  PrmPrtPriceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrmPrtPriceWork(System.IO.BinaryWriter writer, PrmPrtPriceWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //�D�Ǖi��(�|�t���i��)
            writer.Write(temp.PrimePartsNoWithH);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //�V���i
            writer.Write(temp.NewPrice);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            // 2010/04/26 Add >>>
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            // 2010/04/26 Add <<<
        }

        /// <summary>
        ///  PrmPrtPriceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmPrtPriceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrmPrtPriceWork GetPrmPrtPriceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmPrtPriceWork temp = new PrmPrtPriceWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //�D�Ǖi��(�|�t���i��)
            temp.PrimePartsNoWithH = reader.ReadString();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //�V���i
            temp.NewPrice = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            // 2010/04/26 Add >>>
            // ���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            // BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            // 2010/04/26 Add <<<


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
        /// <returns>PrmPrtPriceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtPriceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmPrtPriceWork temp = GetPrmPrtPriceWork(reader, serInfo);
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
                    retValue = (PrmPrtPriceWork[])lst.ToArray(typeof(PrmPrtPriceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

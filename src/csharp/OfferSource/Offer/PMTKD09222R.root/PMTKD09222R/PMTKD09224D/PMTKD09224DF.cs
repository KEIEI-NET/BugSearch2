using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmPrtBrcdWork
    /// <summary>
    ///                      �D�Ǖ��i�o�[�R�[�h
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�Ǖ��i�o�[�R�[�h���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/11/22</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmPrtBrcdWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>������Ұ��</remarks>
        private Int32 _partsMakerCode;

        /// <summary>BL�R�[�h</summary>
        /// <remarks></remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�D�Ǖi��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>���i�o�[�R�[�h���</summary>
        /// <remarks>�o�[�R�[�h��ʂƂ��Ďg�p</remarks>
        private Int16 _primePrtsBarCdKndDiv;

        /// <summary>���i�o�[�R�[�h���</summary>
        private string _primePartsBarCode = "";

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
        /// <value>������Ұ��</value>
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

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value></value>
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

        /// public propaty name  :  PrimePrtsBarCdKndDiv
        /// <summary>���i�o�[�R�[�h��ʃv���p�e�B</summary>
        /// <value>���i�o�[�R�[�h��ʂƂ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PrimePrtsBarCdKndDiv
        {
            get { return _primePrtsBarCdKndDiv; }
            set { _primePrtsBarCdKndDiv = value; }
        }

        /// public propaty name  :  PrimePartsBarCode
        /// <summary>���i�o�[�R�[�h���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsBarCode
        {
            get { return _primePartsBarCode; }
            set { _primePartsBarCode = value; }
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmPrtBrcdWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrmPrtBrcdWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmPrtBrcdWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrmPrtBrcdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmPrtBrcdWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmPrtBrcdWork || graph is ArrayList || graph is PrmPrtBrcdWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmPrtBrcdWork).FullName));

            if (graph != null && graph is PrmPrtBrcdWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmPrtBrcdWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmPrtBrcdWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmPrtBrcdWork[])graph).Length;
            }
            else if (graph is PrmPrtBrcdWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32));	//OfferDate
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));	//PartsMakerCode
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));	//TbsPartsCode
            //�D�Ǖi��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string));	//PrimePartsNoWithH
            //���i�o�[�R�[�h���
            serInfo.MemberInfo.Add(typeof(Int16));	//PrimePrtsBarCdKndDiv
            //���i�o�[�R�[�h���
            serInfo.MemberInfo.Add(typeof(string));	//PrimePartsBarCode

            serInfo.Serialize(writer, serInfo);
            if (graph is PrmPrtBrcdWork)
            {
                PrmPrtBrcdWork temp = (PrmPrtBrcdWork)graph;

                SetPrmPrtBrcdWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmPrtBrcdWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmPrtBrcdWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmPrtBrcdWork temp in lst)
                {
                    SetPrmPrtBrcdWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// PrmPrtBrcdWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  PrmPrtBrcdWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrmPrtBrcdWork(System.IO.BinaryWriter writer, PrmPrtBrcdWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCode);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�D�Ǖi��(�|�t���i��)
            writer.Write(temp.PrimePartsNoWithH);
            //���i�o�[�R�[�h���
            writer.Write(temp.PrimePrtsBarCdKndDiv);
            //���i�o�[�R�[�h���
            writer.Write(temp.PrimePartsBarCode);
        }

        /// <summary>
        ///  PrmPrtBrcdWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmPrtBrcdWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrmPrtBrcdWork GetPrmPrtBrcdWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmPrtBrcdWork temp = new PrmPrtBrcdWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCode = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�D�Ǖi��(�|�t���i��)
            temp.PrimePartsNoWithH = reader.ReadString();
            //���i����
            temp.PrimePrtsBarCdKndDiv = reader.ReadInt16();
            //�D�Ǖ��i�C���X�g�R�[�h
            temp.PrimePartsBarCode = reader.ReadString();

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
        /// <returns>PrmPrtBrcdWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmPrtBrcdWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmPrtBrcdWork temp = GetPrmPrtBrcdWork(reader, serInfo);
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
                    retValue = (PrmPrtBrcdWork[])lst.ToArray(typeof(PrmPrtBrcdWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

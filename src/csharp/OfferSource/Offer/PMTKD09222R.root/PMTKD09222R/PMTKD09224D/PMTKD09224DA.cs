using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PtMkrPriceWork
    /// <summary>
    ///                      ���i���i���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���i���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/5/6</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/4/6  ����@���j</br>
    /// <br>                 :   ���ʃt�@�C���w�b�_�ύX�i���ڍ폜�j</br>
    /// <br>                 :   �E��ƃR�[�h</br>
    /// <br>                 :   �EGUID</br>
    /// <br>                 :   �E�X�V�]�ƈ��R�[�h</br>
    /// <br>                 :   �E�X�V�A�Z���u��ID1</br>
    /// <br>                 :   �E�X�V�A�Z���u��ID2</br>
    /// <br>Update Note      :   2006/12/27  ��{�@�E</br>
    /// <br>                 :   �E���i��񐧌�t���O</br>
    /// <br>                 :   �ǉ�</br>
    /// <br>Update Note      :   2008/7/3  ����</br>
    /// <br>                 :   �ǉ��F���i���i�J�n��</br>
    /// <br>                 :   �I�[�v�����i�敪</br>
    /// <br>                 :   ���i�敪�H</br>
    /// <br>Update Note      :   2008/7/7  ����</br>
    /// <br>                 :   �ǉ��F���[�J�[�񋟕��i�J�i����</br>
    /// <br>                 :   �V�w�b�_�[�ֈڍs</br>
    /// <br>Update Note      :   2008/7/9  ����</br>
    /// <br>                 :   �E���i��񐧌�t���O�폜</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PtMkrPriceWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i���i����敪</summary>
        /// <remarks>0:�����1,1:�����2,2:�����3�@��PM.NS�͂O�Œ�</remarks>
        private Int32 _partsPriceRevCd;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�n�C�t���t�ŐV���i�i��</summary>
        private string _newPrtsNoWithHyphen = "";

        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _newPrtsNoNoneHyphen = "";

        /// <summary>���i���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _partsPriceStDate;

        /// <summary>�����i�R�[�h</summary>
        /// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�����i�R�[�h�}��</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>���[�J�[�񋟕��i����</summary>
        private string _makerOfferPartsName = "";

        /// <summary>���[�J�[�񋟕��i�J�i����</summary>
        private string _makerOfferPartsKana = "";

        /// <summary>���i���i</summary>
        private Int64 _partsPrice;

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _openPriceDiv;


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

        /// public propaty name  :  PartsPriceRevCd
        /// <summary>���i���i����敪�v���p�e�B</summary>
        /// <value>0:�����1,1:�����2,2:�����3�@��PM.NS�͂O�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsPriceRevCd
        {
            get { return _partsPriceRevCd; }
            set { _partsPriceRevCd = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  NewPrtsNoWithHyphen
        /// <summary>�n�C�t���t�ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPrtsNoWithHyphen
        {
            get { return _newPrtsNoWithHyphen; }
            set { _newPrtsNoWithHyphen = value; }
        }

        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>�n�C�t�����ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }

        /// public propaty name  :  PartsPriceStDate
        /// <summary>���i���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>�����i�R�[�h�v���p�e�B</summary>
        /// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>�����i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  MakerOfferPartsName
        /// <summary>���[�J�[�񋟕��i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�񋟕��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>���[�J�[�񋟕��i�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�񋟕��i�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  PartsPrice
        /// <summary>���i���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
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


        /// <summary>
        /// ���i���i���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PtMkrPriceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PtMkrPriceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PtMkrPriceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PtMkrPriceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PtMkrPriceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PtMkrPriceWork || graph is ArrayList || graph is PtMkrPriceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PtMkrPriceWork).FullName));

            if (graph != null && graph is PtMkrPriceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PtMkrPriceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PtMkrPriceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PtMkrPriceWork[])graph).Length;
            }
            else if (graph is PtMkrPriceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //���i���i����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPriceRevCd
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //�n�C�t���t�ŐV���i�i��
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoWithHyphen
            //�n�C�t�����ŐV���i�i��
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoNoneHyphen
            //���i���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPriceStDate
            //�����i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //�����i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //���[�J�[�񋟕��i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsName
            //���[�J�[�񋟕��i�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsKana
            //���i���i
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPrice
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PtMkrPriceWork)
            {
                PtMkrPriceWork temp = (PtMkrPriceWork)graph;

                SetPtMkrPriceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PtMkrPriceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PtMkrPriceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PtMkrPriceWork temp in lst)
                {
                    SetPtMkrPriceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PtMkrPriceWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  PtMkrPriceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPtMkrPriceWork(System.IO.BinaryWriter writer, PtMkrPriceWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i���i����敪
            writer.Write(temp.PartsPriceRevCd);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //�n�C�t���t�ŐV���i�i��
            writer.Write(temp.NewPrtsNoWithHyphen);
            //�n�C�t�����ŐV���i�i��
            writer.Write(temp.NewPrtsNoNoneHyphen);
            //���i���i�J�n��
            writer.Write(temp.PartsPriceStDate);
            //�����i�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�����i�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //���[�J�[�񋟕��i����
            writer.Write(temp.MakerOfferPartsName);
            //���[�J�[�񋟕��i�J�i����
            writer.Write(temp.MakerOfferPartsKana);
            //���i���i
            writer.Write(temp.PartsPrice);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);

        }

        /// <summary>
        ///  PtMkrPriceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PtMkrPriceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PtMkrPriceWork GetPtMkrPriceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PtMkrPriceWork temp = new PtMkrPriceWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i���i����敪
            temp.PartsPriceRevCd = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�n�C�t���t�ŐV���i�i��
            temp.NewPrtsNoWithHyphen = reader.ReadString();
            //�n�C�t�����ŐV���i�i��
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            //���i���i�J�n��
            temp.PartsPriceStDate = reader.ReadInt32();
            //�����i�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�����i�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //���[�J�[�񋟕��i����
            temp.MakerOfferPartsName = reader.ReadString();
            //���[�J�[�񋟕��i�J�i����
            temp.MakerOfferPartsKana = reader.ReadString();
            //���i���i
            temp.PartsPrice = reader.ReadInt64();
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();


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
        /// <returns>PtMkrPriceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PtMkrPriceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PtMkrPriceWork temp = GetPtMkrPriceWork(reader, serInfo);
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
                    retValue = (PtMkrPriceWork[])lst.ToArray(typeof(PtMkrPriceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

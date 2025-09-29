using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfrPartsRetWork
    /// <summary>
    ///                      ���i���N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfrPartsRetWork
    {
        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�n�C�t���t�ŐV���i�i��</summary>
        private string _partsNoWithHyphen = "";

        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _partsNoNoneHyphen = "";

        /// <summary>���i����</summary>
        private string _partsName = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>�D�Ǖ��i�K�i�E���L����</summary>
        /// <remarks>[�D�ǐ�p]</remarks>
        private string _primePartsSpecialNote = "";

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i�敪</summary>
        /// <remarks>0:�����A1:�D�ǁA2:�p�i</remarks>
        private Int32 _partsCode;


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

        /// public propaty name  :  PartsNoWithHyphen
        /// <summary>�n�C�t���t�ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsNoWithHyphen
        {
            get { return _partsNoWithHyphen; }
            set { _partsNoWithHyphen = value; }
        }

        /// public propaty name  :  PartsNoNoneHyphen
        /// <summary>�n�C�t�����ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsNoNoneHyphen
        {
            get { return _partsNoNoneHyphen; }
            set { _partsNoNoneHyphen = value; }
        }

        /// public propaty name  :  PartsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }

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
        /// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
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

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>�D�Ǖ��i�K�i�E���L�����v���p�e�B</summary>
        /// <value>[�D�ǐ�p]</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }

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

        /// public propaty name  :  PartsCode
        /// <summary>���i�敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D�ǁA2:�p�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }


        /// <summary>
        /// ���i���N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfrPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OfrPartsRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OfrPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfrPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfrPartsRetWork || graph is ArrayList || graph is OfrPartsRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfrPartsRetWork).FullName));

            if (graph != null && graph is OfrPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfrPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfrPartsRetWork[])graph).Length;
            }
            else if (graph is OfrPartsRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //�n�C�t���t�ŐV���i�i��
            serInfo.MemberInfo.Add(typeof(string)); //PartsNoWithHyphen
            //�n�C�t�����ŐV���i�i��
            serInfo.MemberInfo.Add(typeof(string)); //PartsNoNoneHyphen
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //PartsName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //�D�Ǖ��i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is OfrPartsRetWork)
            {
                OfrPartsRetWork temp = (OfrPartsRetWork)graph;

                SetOfrPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfrPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfrPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfrPartsRetWork temp in lst)
                {
                    SetOfrPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfrPartsRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  OfrPartsRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOfrPartsRetWork(System.IO.BinaryWriter writer, OfrPartsRetWork temp)
        {
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //�n�C�t���t�ŐV���i�i��
            writer.Write(temp.PartsNoWithHyphen);
            //�n�C�t�����ŐV���i�i��
            writer.Write(temp.PartsNoNoneHyphen);
            //���i����
            writer.Write(temp.PartsName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //�D�Ǖ��i�K�i�E���L����
            writer.Write(temp.PrimePartsSpecialNote);
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i�敪
            writer.Write(temp.PartsCode);

        }

        /// <summary>
        ///  OfrPartsRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OfrPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OfrPartsRetWork GetOfrPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OfrPartsRetWork temp = new OfrPartsRetWork();

            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�n�C�t���t�ŐV���i�i��
            temp.PartsNoWithHyphen = reader.ReadString();
            //�n�C�t�����ŐV���i�i��
            temp.PartsNoNoneHyphen = reader.ReadString();
            //���i����
            temp.PartsName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //�D�Ǖ��i�K�i�E���L����
            temp.PrimePartsSpecialNote = reader.ReadString();
            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i�敪
            temp.PartsCode = reader.ReadInt32();


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
        /// <returns>OfrPartsRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfrPartsRetWork temp = GetOfrPartsRetWork(reader, serInfo);
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
                    retValue = (OfrPartsRetWork[])lst.ToArray(typeof(OfrPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

/*
namespace Broadleaf.Application.Remoting.ParamData
{
	# region public class OfrPartsRetWork
	/// public class name:   OfrPartsRetWork
	/// <summary>
	///                      ���[�U�[���i���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[���i���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OfrPartsRetWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		private Int32 _makerCd;

		/// <summary>���i�i�ԁi�n�C�t���t���j</summary>
		private string _goodsNoWithHyp = "";

		/// <summary>���i�i�ԁi�n�C�t�������j</summary>
		private string _goodsNoNoneHyp = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>�����ރR�[�h</summary>
		private Int32 _middleGenreCode;

		/// <summary>BL�R�[�h</summary>
		private Int32 _tbsPartsCode;

		/// <summary>�艿</summary>
		private Int64 _listPrice;

		/// <summary>�w�ʃR�[�h</summary>
		private string _goodsLayerCd = "";

		/// <summary>���i�K�i�E���L����</summary>
		/// <remarks>���t�������Ă���Β�</remarks>
		private string _goodsSpecialNote = "";

		/// <summary>�f�[�^�񋟓��t</summary>
		private Int32 _offerDate;

		/// <summary>�V�艿</summary>
		private Int64 _newListPrice;

		/// <summary>�V�艿�K�p���t</summary>
		private Int32 _newListPriceApplyDate;

		/// <summary>���i�敪</summary>
		/// <remarks>0:�����A1:�D�ǁA2:�p�i</remarks>
		private Int32 _partsCode;

		/// <summary>���i�敪 </summary>
		private Int32 _goodsCode;

		/// <summary>�ŋ敪</summary>
		/// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
		private Int32 _taxationCode;

		/// <summary>���i���l1</summary>
		private string _goodsNote1 = "";

		/// <summary>���i���l2</summary>
		private string _goodsNote2 = "";


		/// public propaty name  :  MakerCd
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCd
		{
			get { return _makerCd; }
			set { _makerCd = value; }
		}

		/// public propaty name  :  GoodsNoWithHyp
		/// <summary>���i�i�ԁi�n�C�t���t���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�i�ԁi�n�C�t���t���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoWithHyp
		{
			get { return _goodsNoWithHyp; }
			set { _goodsNoWithHyp = value; }
		}

		/// public propaty name  :  GoodsNoNoneHyp
		/// <summary>���i�i�ԁi�n�C�t�������j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�i�ԁi�n�C�t�������j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoNoneHyp
		{
			get { return _goodsNoNoneHyp; }
			set { _goodsNoNoneHyp = value; }
		}

		/// public propaty name  :  GoodsName
		/// <summary>���i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsName
		{
			get { return _goodsName; }
			set { _goodsName = value; }
		}

		/// public propaty name  :  MiddleGenreCode
		/// <summary>�����ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MiddleGenreCode
		{
			get { return _middleGenreCode; }
			set { _middleGenreCode = value; }
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

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get { return _listPrice; }
			set { _listPrice = value; }
		}

		/// public propaty name  :  GoodsLayerCd
		/// <summary>�w�ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsLayerCd
		{
			get { return _goodsLayerCd; }
			set { _goodsLayerCd = value; }
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>���i�K�i�E���L�����v���p�e�B</summary>
		/// <value>���t�������Ă���Β�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get { return _goodsSpecialNote; }
			set { _goodsSpecialNote = value; }
		}

		/// public propaty name  :  OfferDate
		/// <summary>�f�[�^�񋟓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDate
		{
			get { return _offerDate; }
			set { _offerDate = value; }
		}

		/// public propaty name  :  NewListPrice
		/// <summary>�V�艿�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 NewListPrice
		{
			get { return _newListPrice; }
			set { _newListPrice = value; }
		}

		/// public propaty name  :  NewListPriceApplyDate
		/// <summary>�V�艿�K�p���t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�艿�K�p���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NewListPriceApplyDate
		{
			get { return _newListPriceApplyDate; }
			set { _newListPriceApplyDate = value; }
		}

		/// public propaty name  :  PartsCode
		/// <summary>���i�敪�v���p�e�B</summary>
		/// <value>0:�����A1:�D�ǁA2:�p�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsCode
		{
			get { return _partsCode; }
			set { _partsCode = value; }
		}

		/// public propaty name  :  GoodsCode
		/// <summary>���i�敪 �v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�敪 �v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsCode
		{
			get { return _goodsCode; }
			set { _goodsCode = value; }
		}

		/// public propaty name  :  TaxationCode
		/// <summary>�ŋ敪�v���p�e�B</summary>
		/// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxationCode
		{
			get { return _taxationCode; }
			set { _taxationCode = value; }
		}

		/// public propaty name  :  GoodsNote1
		/// <summary>���i���l1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote1
		{
			get { return _goodsNote1; }
			set { _goodsNote1 = value; }
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>���i���l2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote2
		{
			get { return _goodsNote2; }
			set { _goodsNote2 = value; }
		}


		/// <summary>
		/// ���[�U�[���i���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>OfrPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OfrPartsRetWork()
		{
		}

	}
	# endregion

	# region public class OfrPartsRetWork_SerializationSurrogate_For_V51010
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>OfrPartsRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class OfrPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  OfrPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is OfrPartsRetWork || graph is ArrayList || graph is OfrPartsRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfrPartsRetWork).FullName));

			if (graph != null && graph is OfrPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfrPartsRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is OfrPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((OfrPartsRetWork[])graph).Length;
			}
			else if (graph is OfrPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCd
			//���i�i�ԁi�n�C�t���t���j
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNoWithHyp
			//���i�i�ԁi�n�C�t�������j
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyp
			//���i����
			serInfo.MemberInfo.Add(typeof(string)); //GoodsName
			//�����ރR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //MiddleGenreCode
			//BL�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
			//�艿
			serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
			//�w�ʃR�[�h
			serInfo.MemberInfo.Add(typeof(string)); //GoodsLayerCd
			//���i�K�i�E���L����
			serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
			//�f�[�^�񋟓��t
			serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
			//�V�艿
			serInfo.MemberInfo.Add(typeof(Int64)); //NewListPrice
			//�V�艿�K�p���t
			serInfo.MemberInfo.Add(typeof(Int32)); //NewListPriceApplyDate
			//���i�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode
			//���i�敪 
			serInfo.MemberInfo.Add(typeof(Int32)); //GoodsCode
			//�ŋ敪
			serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
			//���i���l1
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
			//���i���l2
			serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2


			serInfo.Serialize(writer, serInfo);
			if (graph is OfrPartsRetWork)
			{
				OfrPartsRetWork temp = (OfrPartsRetWork)graph;

				SetOfrPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is OfrPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((OfrPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (OfrPartsRetWork temp in lst)
				{
					SetOfrPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// OfrPartsRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 17;

		/// <summary>
		///  OfrPartsRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetOfrPartsRetWork(System.IO.BinaryWriter writer, OfrPartsRetWork temp)
		{
			//���[�J�[�R�[�h
			writer.Write(temp.MakerCd);
			//���i�i�ԁi�n�C�t���t���j
			writer.Write(temp.GoodsNoWithHyp);
			//���i�i�ԁi�n�C�t�������j
			writer.Write(temp.GoodsNoNoneHyp);
			//���i����
			writer.Write(temp.GoodsName);
			//�����ރR�[�h
			writer.Write(temp.MiddleGenreCode);
			//BL�R�[�h
			writer.Write(temp.TbsPartsCode);
			//�艿
			writer.Write(temp.ListPrice);
			//�w�ʃR�[�h
			writer.Write(temp.GoodsLayerCd);
			//���i�K�i�E���L����
			writer.Write(temp.GoodsSpecialNote);
			//�f�[�^�񋟓��t
			writer.Write(temp.OfferDate);
			//�V�艿
			writer.Write(temp.NewListPrice);
			//�V�艿�K�p���t
			writer.Write(temp.NewListPriceApplyDate);
			//���i�敪
			writer.Write(temp.PartsCode);
			//���i�敪 
			writer.Write(temp.GoodsCode);
			//�ŋ敪
			writer.Write(temp.TaxationCode);
			//���i���l1
			writer.Write(temp.GoodsNote1);
			//���i���l2
			writer.Write(temp.GoodsNote2);

		}

		/// <summary>
		///  OfrPartsRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>OfrPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private OfrPartsRetWork GetOfrPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			OfrPartsRetWork temp = new OfrPartsRetWork();

			//���[�J�[�R�[�h
			temp.MakerCd = reader.ReadInt32();
			//���i�i�ԁi�n�C�t���t���j
			temp.GoodsNoWithHyp = reader.ReadString();
			//���i�i�ԁi�n�C�t�������j
			temp.GoodsNoNoneHyp = reader.ReadString();
			//���i����
			temp.GoodsName = reader.ReadString();
			//�����ރR�[�h
			temp.MiddleGenreCode = reader.ReadInt32();
			//BL�R�[�h
			temp.TbsPartsCode = reader.ReadInt32();
			//�艿
			temp.ListPrice = reader.ReadInt64();
			//�w�ʃR�[�h
			temp.GoodsLayerCd = reader.ReadString();
			//���i�K�i�E���L����
			temp.GoodsSpecialNote = reader.ReadString();
			//�f�[�^�񋟓��t
			temp.OfferDate = reader.ReadInt32();
			//�V�艿
			temp.NewListPrice = reader.ReadInt64();
			//�V�艿�K�p���t
			temp.NewListPriceApplyDate = reader.ReadInt32();
			//���i�敪
			temp.PartsCode = reader.ReadInt32();
			//���i�敪 
			temp.GoodsCode = reader.ReadInt32();
			//�ŋ敪
			temp.TaxationCode = reader.ReadInt32();
			//���i���l1
			temp.GoodsNote1 = reader.ReadString();
			//���i���l2
			temp.GoodsNote2 = reader.ReadString();


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
		/// <returns>OfrPartsRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   OfrPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				OfrPartsRetWork temp = GetOfrPartsRetWork(reader, serInfo);
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
					retValue = (OfrPartsRetWork[])lst.ToArray(typeof(OfrPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
	# endregion
}
*/
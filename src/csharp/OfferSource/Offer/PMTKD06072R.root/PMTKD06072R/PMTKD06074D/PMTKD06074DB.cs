using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBOSearchRetWork
    /// <summary>
    ///                      �񋟎��q��񌋍��������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟎��q��񌋍��������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchRetWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>��������</summary>
        /// <remarks>��j1001�F�o�b�e��</remarks>
        private Int32 _equipGenreCode;

        /// <summary>��������</summary>
        /// <remarks>��j100D26L�i�o�b�e���K�i�j</remarks>
        private string _equipName = "";

        /// <summary>�ԗ������\������</summary>
        /// <remarks>2,3,5,6������̌������������݂���ꍇ�̘A��</remarks>
        private Int32 _carInfoJoinDispOrder;

        /// <summary>�����惁�[�J�[�R�[�h</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>������i��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>�����p�s�x</summary>
        private Double _joinQty;

        /// <summary>�����K�i�E���L����</summary>
        private string _equipSpecialNote = "";

        /// <summary>�D�Ǖ��i����</summary>
        /// <remarks>�S�p</remarks>
        private string _primePartsName = "";

        /// <summary>�D�Ǖ��i�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _primePartsKanaName = "";

        /// <summary>�w�ʃR�[�h</summary>
        /// <remarks>�|���ݒ�Ŏg�p����</remarks>
        private string _partsLayerCd = "";

        /// <summary>�D�Ǖ��i�K�i�E���L����</summary>
        private string _primePartsSpecialNote = "";

        /// <summary>���i����</summary>
        /// <remarks>0:���� ��D�ǁA�p�i�Ȃǂ���ʂ��邽�߂̑���</remarks>
        private Int32 _partsAttribute;

        /// <summary>�J�^���O�폜�t���O</summary>
        private Int32 _catalogDelteFlag;

        /// <summary>�����i���i�S�p�j</summary>
        private string _searchPartsFullName = "";

        /// <summary>�����i���i���p�j</summary>
        private string _searchPartsHalfName = "";


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

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>��������</value>
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

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  EquipGenreCode
        /// <summary>�������ރv���p�e�B</summary>
        /// <value>��j1001�F�o�b�e��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>�������̃v���p�e�B</summary>
        /// <value>��j100D26L�i�o�b�e���K�i�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  CarInfoJoinDispOrder
        /// <summary>�ԗ������\�����ʃv���p�e�B</summary>
        /// <value>2,3,5,6������̌������������݂���ꍇ�̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ������\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarInfoJoinDispOrder
        {
            get { return _carInfoJoinDispOrder; }
            set { _carInfoJoinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>�����惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������i��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>�����p�s�x�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����p�s�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  EquipSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipSpecialNote
        {
            get { return _equipSpecialNote; }
            set { _equipSpecialNote = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>�D�Ǖ��i���̃v���p�e�B</summary>
        /// <value>�S�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaName
        /// <summary>�D�Ǖ��i�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsKanaName
        {
            get { return _primePartsKanaName; }
            set { _primePartsKanaName = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// <value>�|���ݒ�Ŏg�p����</value>
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

        /// public propaty name  :  PartsAttribute
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:���� ��D�ǁA�p�i�Ȃǂ���ʂ��邽�߂̑���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsAttribute
        {
            get { return _partsAttribute; }
            set { _partsAttribute = value; }
        }

        /// public propaty name  :  CatalogDelteFlag
        /// <summary>�J�^���O�폜�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O�폜�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CatalogDelteFlag
        {
            get { return _catalogDelteFlag; }
            set { _catalogDelteFlag = value; }
        }

        /// public propaty name  :  SearchPartsFullName
        /// <summary>�����i���i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsFullName
        {
            get { return _searchPartsFullName; }
            set { _searchPartsFullName = value; }
        }

        /// public propaty name  :  SearchPartsHalfName
        /// <summary>�����i���i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i���i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsHalfName
        {
            get { return _searchPartsHalfName; }
            set { _searchPartsHalfName = value; }
        }


        /// <summary>
        /// �񋟎��q��񌋍��������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TBOSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TBOSearchRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TBOSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBOSearchRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBOSearchRetWork || graph is ArrayList || graph is TBOSearchRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TBOSearchRetWork).FullName));

            if (graph != null && graph is TBOSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBOSearchRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBOSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBOSearchRetWork[])graph).Length;
            }
            else if (graph is TBOSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //��������
            serInfo.MemberInfo.Add(typeof(Int32)); //EquipGenreCode
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //EquipName
            //�ԗ������\������
            serInfo.MemberInfo.Add(typeof(Int32)); //CarInfoJoinDispOrder
            //�����惁�[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //������i��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //�����p�s�x
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //�����K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //EquipSpecialNote
            //�D�Ǖ��i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //�D�Ǖ��i�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaName
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //�D�Ǖ��i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsAttribute
            //�J�^���O�폜�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDelteFlag
            //�����i���i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //�����i���i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is TBOSearchRetWork)
            {
                TBOSearchRetWork temp = (TBOSearchRetWork)graph;

                SetTBOSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBOSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBOSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBOSearchRetWork temp in lst)
                {
                    SetTBOSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TBOSearchRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  TBOSearchRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTBOSearchRetWork(System.IO.BinaryWriter writer, TBOSearchRetWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate.Ticks);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //��������
            writer.Write(temp.EquipGenreCode);
            //��������
            writer.Write(temp.EquipName);
            //�ԗ������\������
            writer.Write(temp.CarInfoJoinDispOrder);
            //�����惁�[�J�[�R�[�h
            writer.Write(temp.JoinDestMakerCd);
            //������i��(�|�t���i��)
            writer.Write(temp.JoinDestPartsNo);
            //�����p�s�x
            writer.Write(temp.JoinQty);
            //�����K�i�E���L����
            writer.Write(temp.EquipSpecialNote);
            //�D�Ǖ��i����
            writer.Write(temp.PrimePartsName);
            //�D�Ǖ��i�J�i����
            writer.Write(temp.PrimePartsKanaName);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //�D�Ǖ��i�K�i�E���L����
            writer.Write(temp.PrimePartsSpecialNote);
            //���i����
            writer.Write(temp.PartsAttribute);
            //�J�^���O�폜�t���O
            writer.Write(temp.CatalogDelteFlag);
            //�����i���i�S�p�j
            writer.Write(temp.SearchPartsFullName);
            //�����i���i���p�j
            writer.Write(temp.SearchPartsHalfName);

        }

        /// <summary>
        ///  TBOSearchRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TBOSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TBOSearchRetWork GetTBOSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TBOSearchRetWork temp = new TBOSearchRetWork();

            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //��������
            temp.EquipGenreCode = reader.ReadInt32();
            //��������
            temp.EquipName = reader.ReadString();
            //�ԗ������\������
            temp.CarInfoJoinDispOrder = reader.ReadInt32();
            //�����惁�[�J�[�R�[�h
            temp.JoinDestMakerCd = reader.ReadInt32();
            //������i��(�|�t���i��)
            temp.JoinDestPartsNo = reader.ReadString();
            //�����p�s�x
            temp.JoinQty = reader.ReadDouble();
            //�����K�i�E���L����
            temp.EquipSpecialNote = reader.ReadString();
            //�D�Ǖ��i����
            temp.PrimePartsName = reader.ReadString();
            //�D�Ǖ��i�J�i����
            temp.PrimePartsKanaName = reader.ReadString();
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //�D�Ǖ��i�K�i�E���L����
            temp.PrimePartsSpecialNote = reader.ReadString();
            //���i����
            temp.PartsAttribute = reader.ReadInt32();
            //�J�^���O�폜�t���O
            temp.CatalogDelteFlag = reader.ReadInt32();
            //�����i���i�S�p�j
            temp.SearchPartsFullName = reader.ReadString();
            //�����i���i���p�j
            temp.SearchPartsHalfName = reader.ReadString();


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
        /// <returns>TBOSearchRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBOSearchRetWork temp = GetTBOSearchRetWork(reader, serInfo);
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
                    retValue = (TBOSearchRetWork[])lst.ToArray(typeof(TBOSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}


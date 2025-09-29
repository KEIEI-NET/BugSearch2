using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferJoinPartsRetWork
    /// <summary>
    ///                      �񋟌������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟌������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferJoinPartsRetWork
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

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>���Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�����\������</summary>
        /// <remarks>2,3,5,6,8,9������̌������������݂���ꍇ�̘A��</remarks>
        private Int32 _joinDispOrder;

        /// <summary>���������[�J�[�R�[�h</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>�������i��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _joinSourPartsNoWithH = "";

        /// <summary>�������i��(�|�����i��)</summary>
        private string _joinSourPartsNoNoneH = "";

        /// <summary>�����惁�[�J�[�R�[�h</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>������i��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>����QTY</summary>
        private Double _joinQty;

        /// <summary>�Z�b�g�i�ԃt���O</summary>
        /// <remarks>0:�Z�b�g�i�����@1:�Z�b�g�i�L��</remarks>
        private Int32 _setPartsFlg;

        /// <summary>�����K�i�E���L����</summary>
        private string _joinSpecialNote = "";

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
        private Int32 _catalogDeleteFlag;

        /// <summary>�D�Ǖ��i�C���X�g�R�[�h</summary>
        private string _prmPartsIllustC = "";

        /// <summary>��֋敪</summary>
        /// <remarks>1:���</remarks>
        private Int32 _substKubun;

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

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
        /// <value>���Z���N�g�R�[�h</value>
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

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>����ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  JoinDispOrder
        /// <summary>�����\�����ʃv���p�e�B</summary>
        /// <value>2,3,5,6,8,9������̌������������݂���ꍇ�̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>���������[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>�������i��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>�������i��(�|�����i��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i��(�|�����i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
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
        /// <summary>����QTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����QTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  SetPartsFlg
        /// <summary>�Z�b�g�i�ԃt���O�v���p�e�B</summary>
        /// <value>0:�Z�b�g�i�����@1:�Z�b�g�i�L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�i�ԃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsFlg
        {
            get { return _setPartsFlg; }
            set { _setPartsFlg = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
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

        /// public propaty name  :  CatalogDeleteFlag
        /// <summary>�J�^���O�폜�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O�폜�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CatalogDeleteFlag
        {
            get { return _catalogDeleteFlag; }
            set { _catalogDeleteFlag = value; }
        }

        /// public propaty name  :  PrmPartsIllustC
        /// <summary>�D�Ǖ��i�C���X�g�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�C���X�g�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmPartsIllustC
        {
            get { return _prmPartsIllustC; }
            set { _prmPartsIllustC = value; }
        }

        /// public propaty name  :  SubstKubun
        /// <summary>��֋敪�v���p�e�B</summary>
        /// <value>1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubstKubun
        {
            get { return _substKubun; }
            set { _substKubun = value; }
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
        /// �񋟌������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfferJoinPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfferJoinPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OfferJoinPartsRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OfferJoinPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferJoinPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferJoinPartsRetWork || graph is ArrayList || graph is OfferJoinPartsRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfferJoinPartsRetWork).FullName));

            if (graph != null && graph is OfferJoinPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferJoinPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferJoinPartsRetWork[])graph).Length;
            }
            else if (graph is OfferJoinPartsRetWork)
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
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //�����\������
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
            //���������[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
            //�������i��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
            //�������i��(�|�����i��)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
            //�����惁�[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //������i��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //����QTY
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //�Z�b�g�i�ԃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsFlg
            //�����K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote
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
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDeleteFlag
            //�D�Ǖ��i�C���X�g�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsIllustC
            //��֋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstKubun
            //�����i���i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //�����i���i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferJoinPartsRetWork)
            {
                OfferJoinPartsRetWork temp = (OfferJoinPartsRetWork)graph;

                SetOfferJoinPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferJoinPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferJoinPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferJoinPartsRetWork temp in lst)
                {
                    SetOfferJoinPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferJoinPartsRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  OfferJoinPartsRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOfferJoinPartsRetWork(System.IO.BinaryWriter writer, OfferJoinPartsRetWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate.Ticks);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //�D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            //�����\������
            writer.Write(temp.JoinDispOrder);
            //���������[�J�[�R�[�h
            writer.Write(temp.JoinSourceMakerCode);
            //�������i��(�|�t���i��)
            writer.Write(temp.JoinSourPartsNoWithH);
            //�������i��(�|�����i��)
            writer.Write(temp.JoinSourPartsNoNoneH);
            //�����惁�[�J�[�R�[�h
            writer.Write(temp.JoinDestMakerCd);
            //������i��(�|�t���i��)
            writer.Write(temp.JoinDestPartsNo);
            //����QTY
            writer.Write(temp.JoinQty);
            //�Z�b�g�i�ԃt���O
            writer.Write(temp.SetPartsFlg);
            //�����K�i�E���L����
            writer.Write(temp.JoinSpecialNote);
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
            writer.Write(temp.CatalogDeleteFlag);
            //�D�Ǖ��i�C���X�g�R�[�h
            writer.Write(temp.PrmPartsIllustC);
            //��֋敪
            writer.Write(temp.SubstKubun);
            //�����i���i�S�p�j
            writer.Write(temp.SearchPartsFullName);
            //�����i���i���p�j
            writer.Write(temp.SearchPartsHalfName);

        }

        /// <summary>
        ///  OfferJoinPartsRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OfferJoinPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OfferJoinPartsRetWork GetOfferJoinPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OfferJoinPartsRetWork temp = new OfferJoinPartsRetWork();

            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //�����\������
            temp.JoinDispOrder = reader.ReadInt32();
            //���������[�J�[�R�[�h
            temp.JoinSourceMakerCode = reader.ReadInt32();
            //�������i��(�|�t���i��)
            temp.JoinSourPartsNoWithH = reader.ReadString();
            //�������i��(�|�����i��)
            temp.JoinSourPartsNoNoneH = reader.ReadString();
            //�����惁�[�J�[�R�[�h
            temp.JoinDestMakerCd = reader.ReadInt32();
            //������i��(�|�t���i��)
            temp.JoinDestPartsNo = reader.ReadString();
            //����QTY
            temp.JoinQty = reader.ReadDouble();
            //�Z�b�g�i�ԃt���O
            temp.SetPartsFlg = reader.ReadInt32();
            //�����K�i�E���L����
            temp.JoinSpecialNote = reader.ReadString();
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
            temp.CatalogDeleteFlag = reader.ReadInt32();
            //�D�Ǖ��i�C���X�g�R�[�h
            temp.PrmPartsIllustC = reader.ReadString();
            //��֋敪
            temp.SubstKubun = reader.ReadInt32();
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
        /// <returns>OfferJoinPartsRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferJoinPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferJoinPartsRetWork temp = GetOfferJoinPartsRetWork(reader, serInfo);
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
                    retValue = (OfferJoinPartsRetWork[])lst.ToArray(typeof(OfferJoinPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

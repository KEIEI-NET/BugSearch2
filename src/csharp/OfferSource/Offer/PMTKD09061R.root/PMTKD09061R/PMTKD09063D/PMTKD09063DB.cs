using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferSetPartsRetWork
    /// <summary>
    ///                      �񋟃Z�b�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟃Z�b�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      : 2009/11/24�@21024 ���X�� ��</br>
    /// <br>                 : �v���p�e�B�ɉ��L���ڂ�ǉ�(MANTIS[0013603])</br>
    /// <br>                 : �E�D�Ǖ��iBL�R�[�h(PrmPrtTbsPrtCd)</br>
    /// <br>                 : �E�D�Ǖ��iBL�R�[�h�}��(PrmPrtTbsPrtCdDerivNo)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferSetPartsRetWork
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

        /// <summary>�Z�b�g�e���[�J�[�R�[�h</summary>
        private Int32 _setMainMakerCd;

        /// <summary>�Z�b�g�e�i��</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _setMainPartsNo = "";

        /// <summary>�Z�b�g�q���[�J�[�R�[�h</summary>
        private Int32 _setSubMakerCd;

        /// <summary>�Z�b�g�q�i��</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _setSubPartsNo = "";

        /// <summary>�Z�b�g�\������</summary>
        private Int32 _setDispOrder;

        /// <summary>�Z�b�gQTY</summary>
        private Double _setQty;

        /// <summary>�Z�b�g����</summary>
        private string _setName = "";

        /// <summary>�Z�b�g�K�i�E���L����</summary>
        private string _setSpecialNote = "";

        /// <summary>�J�^���O�}��</summary>
        private string _catalogShapeNo = "";

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

        // 2009/11/24 Add >>>
        /// <summary>�D�Ǖ��iBL�R�[�h</summary>
        private Int32 _prmPrtTbsPrtCd;

        /// <summary>�D�Ǖ��iBL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _prmPrtTbsPrtCdDerivNo;
        // 2009/11/24 Add <<<


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

        /// public propaty name  :  SetMainMakerCd
        /// <summary>�Z�b�g�e���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�e���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetMainMakerCd
        {
            get { return _setMainMakerCd; }
            set { _setMainMakerCd = value; }
        }

        /// public propaty name  :  SetMainPartsNo
        /// <summary>�Z�b�g�e�i�ԃv���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�e�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetMainPartsNo
        {
            get { return _setMainPartsNo; }
            set { _setMainPartsNo = value; }
        }

        /// public propaty name  :  SetSubMakerCd
        /// <summary>�Z�b�g�q���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�q���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetSubMakerCd
        {
            get { return _setSubMakerCd; }
            set { _setSubMakerCd = value; }
        }

        /// public propaty name  :  SetSubPartsNo
        /// <summary>�Z�b�g�q�i�ԃv���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�q�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetSubPartsNo
        {
            get { return _setSubPartsNo; }
            set { _setSubPartsNo = value; }
        }

        /// public propaty name  :  SetDispOrder
        /// <summary>�Z�b�g�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetDispOrder
        {
            get { return _setDispOrder; }
            set { _setDispOrder = value; }
        }

        /// public propaty name  :  SetQty
        /// <summary>�Z�b�gQTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�gQTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SetQty
        {
            get { return _setQty; }
            set { _setQty = value; }
        }

        /// public propaty name  :  SetName
        /// <summary>�Z�b�g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetName
        {
            get { return _setName; }
            set { _setName = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>�Z�b�g�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  CatalogShapeNo
        /// <summary>�J�^���O�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CatalogShapeNo
        {
            get { return _catalogShapeNo; }
            set { _catalogShapeNo = value; }
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

        // 2009/11/24 Add >>>
        /// public propaty name  :  PrmPrtTbsPrtCd
        /// <summary>�D�Ǖ��iBL�R�[�h�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        public Int32 PrmPrtTbsPrtCd
        {
            get { return _prmPrtTbsPrtCd; }
            set { _prmPrtTbsPrtCd = value; }
        }

        /// public propaty name  :  PrmPrtTbsPrtCdDerivNo
        /// <summary>�D�Ǖ��iBL�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        public Int32 PrmPrtTbsPrtCdDerivNo
        {
            get { return _prmPrtTbsPrtCdDerivNo; }
            set { _prmPrtTbsPrtCdDerivNo = value; }
        }
        // 2009/11/24 Add <<<

        /// <summary>
        /// �񋟃Z�b�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfferSetPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfferSetPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OfferSetPartsRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br></br>
    /// <br>Update Note      : 2009/11/24�@21024 ���X�� ��</br>
    /// <br>                 : �v���p�e�B�ɉ��L���ڂ�ǉ�(MANTIS[0013603])</br>
    /// <br>                 : �E�D�Ǖ��iBL�R�[�h(PrmPrtTbsPrtCd)</br>
    /// <br>                 : �E�D�Ǖ��iBL�R�[�h�}��(PrmPrtTbsPrtCdDerivNo)</br>    
    /// </remarks>
    public class OfferSetPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferSetPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferSetPartsRetWork || graph is ArrayList || graph is OfferSetPartsRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OfferSetPartsRetWork).FullName));

            if (graph != null && graph is OfferSetPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferSetPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferSetPartsRetWork[])graph).Length;
            }
            else if (graph is OfferSetPartsRetWork)
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
            //�Z�b�g�e���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SetMainMakerCd
            //�Z�b�g�e�i��
            serInfo.MemberInfo.Add(typeof(string)); //SetMainPartsNo
            //�Z�b�g�q���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SetSubMakerCd
            //�Z�b�g�q�i��
            serInfo.MemberInfo.Add(typeof(string)); //SetSubPartsNo
            //�Z�b�g�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //SetDispOrder
            //�Z�b�gQTY
            serInfo.MemberInfo.Add(typeof(Double)); //SetQty
            //�Z�b�g����
            serInfo.MemberInfo.Add(typeof(string)); //SetName
            //�Z�b�g�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
            //�J�^���O�}��
            serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo
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
            // 2009/11/24 Add >>>
            // �D�Ǖ��iBL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtTbsPrtCd
            // �D�Ǖ��iBL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtTbsPrtCdDerivNo
            // 2009/11/24 Add <<<


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferSetPartsRetWork)
            {
                OfferSetPartsRetWork temp = (OfferSetPartsRetWork)graph;

                SetOfferSetPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferSetPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferSetPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferSetPartsRetWork temp in lst)
                {
                    SetOfferSetPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferSetPartsRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2009/11/24 >>>
        //private const int currentMemberCount = 23;
        private const int currentMemberCount = 25;
        // 2009/11/24 <<<

        /// <summary>
        ///  OfferSetPartsRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOfferSetPartsRetWork(System.IO.BinaryWriter writer, OfferSetPartsRetWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate.Ticks);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�Z�b�g�e���[�J�[�R�[�h
            writer.Write(temp.SetMainMakerCd);
            //�Z�b�g�e�i��
            writer.Write(temp.SetMainPartsNo);
            //�Z�b�g�q���[�J�[�R�[�h
            writer.Write(temp.SetSubMakerCd);
            //�Z�b�g�q�i��
            writer.Write(temp.SetSubPartsNo);
            //�Z�b�g�\������
            writer.Write(temp.SetDispOrder);
            //�Z�b�gQTY
            writer.Write(temp.SetQty);
            //�Z�b�g����
            writer.Write(temp.SetName);
            //�Z�b�g�K�i�E���L����
            writer.Write(temp.SetSpecialNote);
            //�J�^���O�}��
            writer.Write(temp.CatalogShapeNo);
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
            // 2009/11/24 Add >>>
            //�D�Ǖ��iBL�R�[�h
            writer.Write(temp.PrmPrtTbsPrtCd);
            //�D�Ǖ��iBL�R�[�h�}��
            writer.Write(temp.PrmPrtTbsPrtCdDerivNo);
            // 2009/11/24 Add <<<
        }

        /// <summary>
        ///  OfferSetPartsRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OfferSetPartsRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OfferSetPartsRetWork GetOfferSetPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OfferSetPartsRetWork temp = new OfferSetPartsRetWork();

            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�Z�b�g�e���[�J�[�R�[�h
            temp.SetMainMakerCd = reader.ReadInt32();
            //�Z�b�g�e�i��
            temp.SetMainPartsNo = reader.ReadString();
            //�Z�b�g�q���[�J�[�R�[�h
            temp.SetSubMakerCd = reader.ReadInt32();
            //�Z�b�g�q�i��
            temp.SetSubPartsNo = reader.ReadString();
            //�Z�b�g�\������
            temp.SetDispOrder = reader.ReadInt32();
            //�Z�b�gQTY
            temp.SetQty = reader.ReadDouble();
            //�Z�b�g����
            temp.SetName = reader.ReadString();
            //�Z�b�g�K�i�E���L����
            temp.SetSpecialNote = reader.ReadString();
            //�J�^���O�}��
            temp.CatalogShapeNo = reader.ReadString();
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
            // 2009/11/24 Add >>>
            //�D�Ǖ��iBL�R�[�h
            temp.PrmPrtTbsPrtCd = reader.ReadInt32();
            //�D�Ǖ��iBL�R�[�h�}��
            temp.PrmPrtTbsPrtCdDerivNo = reader.ReadInt32();
            // 2009/11/24 Add <<<

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
        /// <returns>OfferSetPartsRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferSetPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferSetPartsRetWork temp = GetOfferSetPartsRetWork(reader, serInfo);
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
                    retValue = (OfferSetPartsRetWork[])lst.ToArray(typeof(OfferSetPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

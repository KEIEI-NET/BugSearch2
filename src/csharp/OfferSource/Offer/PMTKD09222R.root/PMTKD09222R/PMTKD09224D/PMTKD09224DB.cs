using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrimePartsWork
    /// <summary>
    ///                      �D�Ǖ��i���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�Ǖ��i���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/11/22</br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/2/29  ����</br>
    /// <br>                 :   �E�폜</br>
    /// <br>                 :   �艿</br>
    /// <br>                 :   �V�艿�K�p���t</br>
    /// <br>                 :   �V�艿</br>
    /// <br>                 :   �E���ڒǉ�</br>
    /// <br>                 :   �D�Ǖ��i�C���X�g�R�[�h</br>
    /// <br>Update Note      :   2008/6/11  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �D�Ǖ��i�J�i����</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrimePartsWork
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _partsMakerCd;

        /// <summary>�D�Ǖi��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>�D�Ǖi��(�|�����i��)</summary>
        /// <remarks>�n�C�t������</remarks>
        private string _primePartsNoNoneH = "";

        /// <summary>�D�Ǖ��i����</summary>
        /// <remarks>�S�p</remarks>
        private string _primePartsName = "";

        /// <summary>�D�Ǖ��i�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _primePartsKanaNm = "";

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

        ///// <summary>���i���X�g</summary>
        //private ArrayList _priceList;

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
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
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
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
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
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
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

        /// public propaty name  :  PrimePartsNoNoneH
        /// <summary>�D�Ǖi��(�|�����i��)�v���p�e�B</summary>
        /// <value>�n�C�t������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖi��(�|�����i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsNoNoneH
        {
            get { return _primePartsNoNoneH; }
            set { _primePartsNoNoneH = value; }
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

        /// public propaty name  :  PrimePartsKanaNm
        /// <summary>�D�Ǖ��i�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimePartsKanaNm
        {
            get { return _primePartsKanaNm; }
            set { _primePartsKanaNm = value; }
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

        ///// public propaty name  :  PriceList
        ///// <summary>���i���X�g�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i���X�g�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList PriceList
        //{
        //    get { return _priceList; }
        //    set { _priceList = value; }
        //}

        /// <summary>
        /// �D�Ǖ��i���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrimePartsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrimePartsWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrimePartsWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrimePartsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrimePartsWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrimePartsWork || graph is ArrayList || graph is PrimePartsWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrimePartsWork).FullName));

            if (graph != null && graph is PrimePartsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrimePartsWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrimePartsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrimePartsWork[])graph).Length;
            }
            else if (graph is PrimePartsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //�D�Ǖi��(�|�t���i��)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //�D�Ǖi��(�|�����i��)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoNoneH
            //�D�Ǖ��i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //�D�Ǖ��i�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaNm
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
            ////���i���X�g
            //serInfo.MemberInfo.Add(typeof(ArrayList)); //PriceList

            serInfo.Serialize(writer, serInfo);
            if (graph is PrimePartsWork)
            {
                PrimePartsWork temp = (PrimePartsWork)graph;

                SetPrimePartsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrimePartsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrimePartsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrimePartsWork temp in lst)
                {
                    SetPrimePartsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrimePartsWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  PrimePartsWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrimePartsWork(System.IO.BinaryWriter writer, PrimePartsWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //�D�Ǖi��(�|�t���i��)
            writer.Write(temp.PrimePartsNoWithH);
            //�D�Ǖi��(�|�����i��)
            writer.Write(temp.PrimePartsNoNoneH);
            //�D�Ǖ��i����
            writer.Write(temp.PrimePartsName);
            //�D�Ǖ��i�J�i����
            writer.Write(temp.PrimePartsKanaNm);
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
            ////���i���X�g
            //if (temp.PriceList == null)
            //{
            //    writer.Write(0);
            //}
            //else
            //{
            //    writer.Write(temp.PriceList.Count);
            //    for (int i = 0; i < temp.PriceList.Count; i++)
            //    {
            //        SetPrmPrtPriceWork(writer, temp.PriceList[i] as PrmPrtPriceWork);
            //    }
            //}
        }

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

        }

        /// <summary>
        ///  PrimePartsWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrimePartsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrimePartsWork GetPrimePartsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrimePartsWork temp = new PrimePartsWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //�D�Ǖi��(�|�t���i��)
            temp.PrimePartsNoWithH = reader.ReadString();
            //�D�Ǖi��(�|�����i��)
            temp.PrimePartsNoNoneH = reader.ReadString();
            //�D�Ǖ��i����
            temp.PrimePartsName = reader.ReadString();
            //�D�Ǖ��i�J�i����
            temp.PrimePartsKanaNm = reader.ReadString();
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
            ////���i���X�g
            //int priceCnt = reader.ReadInt32();
            //temp.PriceList = new ArrayList();
            //for (int i = 0; i < priceCnt; i++)
            //{
            //    PrmPrtPriceWork tempPrice = new PrmPrtPriceWork();

            //    //�񋟓��t
            //    tempPrice.OfferDate = reader.ReadInt32();
            //    //�D�ǐݒ�ڍ׃R�[�h�P
            //    tempPrice.PrmSetDtlNo1 = reader.ReadInt32();
            //    //���i���[�J�[�R�[�h
            //    tempPrice.PartsMakerCd = reader.ReadInt32();
            //    //�D�Ǖi��(�|�t���i��)
            //    tempPrice.PrimePartsNoWithH = reader.ReadString();
            //    //���i�J�n��
            //    tempPrice.PriceStartDate = reader.ReadInt32();
            //    //�V���i
            //    tempPrice.NewPrice = reader.ReadDouble();
            //    //�I�[�v�����i�敪
            //    tempPrice.OpenPriceDiv = reader.ReadInt32();

            //    temp.PriceList.Add(tempPrice);
            //}

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
        /// <returns>PrimePartsWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrimePartsWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrimePartsWork temp = GetPrimePartsWork(reader, serInfo);
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
                    retValue = (PrimePartsWork[])lst.ToArray(typeof(PrimePartsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

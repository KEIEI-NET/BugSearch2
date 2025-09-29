using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmSettingWork
    /// <summary>
    ///                      �D�ǐݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�ǐݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/1/15</br>
    /// <br>Genarated Date   :   2009/01/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  ����</br>
    /// <br>                 :   �e�[�u�����ύX</br>
    /// <br>                 :   PrmeSettingRF</br>
    /// <br>Update Note      :   2008/9/2  ����</br>
    /// <br>                 :   ��NULL���ɕύX</br>
    /// <br>                 :   �D�ǐݒ�ڍז��̂P</br>
    /// <br>                 :   �D�ǐݒ�ڍז��̂Q</br>
    /// <br>Update Note      :   2008/11/10  ����</br>
    /// <br>                 :   ��NULL���ύX�i���ׂĕs�ɂ���j</br>
    /// <br>Update Note      :   2008/12/23  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �D�ǐݒ�O���[�v</br>
    /// <br>Update Note      :   2015/02/23  �L��</br>
    /// <br>                 :   SCM������ C������ʓ��L�Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmSettingWork : IFileHeaderOffer2
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _partsMakerCd;

        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>�V�[�N���b�g�敪</summary>
        /// <remarks>0:�ʏ�@1:�V�[�N���b�g</remarks>
        private Int32 _secretCode;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>�Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>�D�ǐݒ�ڍז��̂P</summary>
        private string _prmSetDtlName1 = "";

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>��ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        private string _prmSetDtlName2 = "";

        /// <summary>�D�ǐݒ�O���[�v</summary>
        /// <remarks>0�F�ݒ�Ȃ� �P�`����ݒ�O���[�v</remarks>
        private Int32 _prmSetGroup;

        // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)</summary>
        private string _prmSetDtlName2ForFac = "";

        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<

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

        /// public propaty name  :  SecretCode
        /// <summary>�V�[�N���b�g�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�@1:�V�[�N���b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�[�N���b�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecretCode
        {
            get { return _secretCode; }
            set { _secretCode = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
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

        /// public propaty name  :  PrmSetDtlName1
        /// <summary>�D�ǐݒ�ڍז��̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName1
        {
            get { return _prmSetDtlName1; }
            set { _prmSetDtlName1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>��ʃR�[�h</value>
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

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>�D�ǐݒ�ڍז��̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  PrmSetGroup
        /// <summary>�D�ǐݒ�O���[�v�v���p�e�B</summary>
        /// <value>0�F�ݒ�Ȃ� �P�`����ݒ�O���[�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�O���[�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetGroup
        {
            get { return _prmSetGroup; }
            set { _prmSetGroup = value; }
        }

        // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<

        /// <summary>
        /// �D�ǐݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmSettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrmSettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmSettingWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrmSettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSettingWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSettingWork || graph is ArrayList || graph is PrmSettingWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmSettingWork).FullName));

            if (graph != null && graph is PrmSettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSettingWork[])graph).Length;
            }
            else if (graph is PrmSettingWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //�V�[�N���b�g�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SecretCode
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //�D�ǐݒ�ڍז��̂P
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //�D�ǐݒ�ڍז��̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //�D�ǐݒ�O���[�v
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetGroup
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForFac
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForCOw
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSettingWork)
            {
                PrmSettingWork temp = (PrmSettingWork)graph;

                SetPrmSettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSettingWork temp in lst)
                {
                    SetPrmSettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmSettingWork�����o��(public�v���p�e�B��)
        /// </summary>
        // UPD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
        //private const int currentMemberCount = 12;
        private const int currentMemberCount = 14;
        // UPD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<

        /// <summary>
        ///  PrmSettingWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrmSettingWork(System.IO.BinaryWriter writer, PrmSettingWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�V�[�N���b�g�敪
            writer.Write(temp.SecretCode);
            //�\������
            writer.Write(temp.DisplayOrder);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //�D�ǐݒ�ڍז��̂P
            writer.Write(temp.PrmSetDtlName1);
            //�D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            //�D�ǐݒ�ڍז��̂Q
            writer.Write(temp.PrmSetDtlName2);
            //�D�ǐݒ�O���[�v
            writer.Write(temp.PrmSetGroup);
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            writer.Write(temp.PrmSetDtlName2ForFac);
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            writer.Write(temp.PrmSetDtlName2ForCOw);
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<

        }

        /// <summary>
        ///  PrmSettingWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmSettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrmSettingWork GetPrmSettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmSettingWork temp = new PrmSettingWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�V�[�N���b�g�敪
            temp.SecretCode = reader.ReadInt32();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //�D�ǐݒ�ڍז��̂P
            temp.PrmSetDtlName1 = reader.ReadString();
            //�D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //�D�ǐݒ�ڍז��̂Q
            temp.PrmSetDtlName2 = reader.ReadString();
            //�D�ǐݒ�O���[�v
            temp.PrmSetGroup = reader.ReadInt32();
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ---------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();
            // ADD 2015/02/23 �L�� SCM������ C������ʓ��L�Ή� ----------<<<<<


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
        /// <returns>PrmSettingWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingWork temp = GetPrmSettingWork(reader, serInfo);
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
                    retValue = (PrmSettingWork[])lst.ToArray(typeof(PrmSettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�f�[�^�p�����[�^
//                  :   PMKEN09034D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30757 ���X�؁@�M�p 
// �C �� ��  2015/02/24  �C�����e : SCM������ �b������ʑΉ�
//                                  �@���ڒǉ�
//                                    �E�D�ǐݒ�ڍז��̂Q(�H�����)
//                                    �E�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmSettingUWork
    /// <summary>
    ///                      �D�ǐݒ�i���[�U�[�o�^���j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�ǐݒ�i���[�U�[�o�^���j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    2006/11/22</br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  ����</br>
    /// <br>                 :   ���Ł�PM.NS�Ή�</br>
    /// <br>Update Note      :   2008/6/11  ����</br>
    /// <br>                 :   �L�[�ύX</br>
    /// <br>                 :    3,10,11,13,15,17 �� 3,9,10,13,15,17</br>
    /// <br>Update Note      :   2008/7/7  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �@���_�R�[�h</br>
    /// <br>Update Note      :   2009/01/05  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �@�񋟓��t</br>
    /// <br></br>
    /// <br>Update Note      : �@2015/02/24 30757 ���X�� �M�p</br>
    /// <br>                 :   11070266-00�@SCM������ �b������ʑΉ�</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �E�D�ǐݒ�ڍז��̂Q(�H�����)</br>
    /// <br>                 :   �E�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmSettingUWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>���[�J�[�\������</summary>
        private Int32 _makerDispOrder;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _partsMakerCd;

        /// <summary>�D�Ǖ\������</summary>
        private Int32 _primeDispOrder;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>���Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>�D�ǐݒ�ڍז��̂P</summary>
        private string _prmSetDtlName1 = "";

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>����ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        private string _prmSetDtlName2 = "";

        /// <summary>�D�Ǖ\���敪</summary>
        /// <remarks>0:�����@1:���i&#38;�����@2:���i</remarks>
        private Int32 _primeDisplayCode;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)</summary>
        /// <remarks>�����H��E����H��Ȃǂ������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _prmSetDtlName2ForFac;

        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</summary>
        /// <remarks>�J�[�I�[�i�[�������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _prmSetDtlName2ForCOw;
        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  MakerDispOrder
        /// <summary>���[�J�[�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerDispOrder
        {
            get { return _makerDispOrder; }
            set { _makerDispOrder = value; }
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

        /// public propaty name  :  PrimeDispOrder
        /// <summary>�D�Ǖ\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrimeDispOrder
        {
            get { return _primeDispOrder; }
            set { _primeDispOrder = value; }
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

        /// public propaty name  :  PrimeDisplayCode
        /// <summary>�D�Ǖ\���敪�v���p�e�B</summary>
        /// <value>0:�����@1:���i&#38;�����@2:���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrimeDisplayCode
        {
            get { return _primeDisplayCode; }
            set { _primeDisplayCode = value; }
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

        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
        /// <summary>
        /// �D�ǐݒ�ڍז��̂Q(�H�����)
        /// </summary>
        /// <value>�����H��E����H��Ȃǂ������\�Ȑ����� (���p�S�p����)</value>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// <summary>
        /// �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
        /// </summary>
        /// <value>�J�[�I�[�i�[�������\�Ȑ����� (���p�S�p����)</value>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

        /// <summary>
        /// �D�ǐݒ�i���[�U�[�o�^���j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmSettingUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrmSettingUWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmSettingUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br></br>
    /// <br>Update Note      : 11070266-00�@SCM������ �b������ʑΉ� </br>
    /// <br>Programmer       : 30757 ���X�� �M�p</br>
    /// <br>Date             : 2015/02/24</br>
    /// <br></br>
    /// </remarks>
    public class PrmSettingUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      : 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>Programmer       : 30757 ���X�� �M�p</br>
        /// <br>Date             : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSettingUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSettingUWork || graph is ArrayList || graph is PrmSettingUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmSettingUWork).FullName));

            if (graph != null && graph is PrmSettingUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSettingUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSettingUWork[])graph).Length;
            }
            else if (graph is PrmSettingUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //���[�J�[�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerDispOrder
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //�D�Ǖ\������
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDispOrder
            //�D�ǐݒ�ڍ׃R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //�D�ǐݒ�ڍז��̂P
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //�D�ǐݒ�ڍז��̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //�D�Ǖ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDisplayCode
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForFacRF
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForCOwRF
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSettingUWork)
            {
                PrmSettingUWork temp = (PrmSettingUWork)graph;

                SetPrmSettingUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSettingUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSettingUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSettingUWork temp in lst)
                {
                    SetPrmSettingUWork(writer, temp);
                }

            }


        }


        //---DEL�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
        ///// <summary>
        ///// PrmSettingUWork�����o��(public�v���p�e�B��)
        ///// </summary>
        //private const int currentMemberCount = 21;
        //---DEL�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
        /// <summary>
        /// PrmSettingUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;
        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

        /// <summary>
        ///  PrmSettingUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      : 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>Programmer       : 30757 ���X�� �M�p</br>
        /// <br>Date             : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private void SetPrmSettingUWork(System.IO.BinaryWriter writer, PrmSettingUWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //���[�J�[�\������
            writer.Write(temp.MakerDispOrder);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //�D�Ǖ\������
            writer.Write(temp.PrimeDispOrder);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //�D�ǐݒ�ڍז��̂P
            writer.Write(temp.PrmSetDtlName1);
            //�D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            //�D�ǐݒ�ڍז��̂Q
            writer.Write(temp.PrmSetDtlName2);
            //�D�Ǖ\���敪
            writer.Write(temp.PrimeDisplayCode);
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            writer.Write(temp.PrmSetDtlName2ForFac);
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            writer.Write(temp.PrmSetDtlName2ForCOw);
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

        }

        /// <summary>
        ///  PrmSettingUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmSettingUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      : 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>Programmer       : 30757 ���X�� �M�p</br>
        /// <br>Date             : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private PrmSettingUWork GetPrmSettingUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmSettingUWork temp = new PrmSettingUWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //���[�J�[�\������
            temp.MakerDispOrder = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //�D�Ǖ\������
            temp.PrimeDispOrder = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //�D�ǐݒ�ڍז��̂P
            temp.PrmSetDtlName1 = reader.ReadString();
            //�D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //�D�ǐݒ�ڍז��̂Q
            temp.PrmSetDtlName2 = reader.ReadString();
            //�D�Ǖ\���敪
            temp.PrimeDisplayCode = reader.ReadInt32();
            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
            //�D�ǐݒ�ڍז��̂Q(�H�����)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            //�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();
            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

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
        /// <returns>PrmSettingUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingUWork temp = GetPrmSettingUWork(reader, serInfo);
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
                    retValue = (PrmSettingUWork[])lst.ToArray(typeof(PrmSettingUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

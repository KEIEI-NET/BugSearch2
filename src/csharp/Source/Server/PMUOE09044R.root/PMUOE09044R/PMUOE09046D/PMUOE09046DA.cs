//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ���Аݒ�}�X�^�f�[�^�p�����[�^
//                  :   PMUOE09046D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOESettingWork
    /// <summary>
    ///                      UOE���Аݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE���Аݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/22  ����</br>
    /// <br>                 :   �����ڒǉ��i�L�[�ύX�j</br>
    /// <br>                 :   �@���_�R�[�h</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOESettingWork : IFileHeader
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

        /// <summary>�`�[�o�͋敪</summary>
        /// <remarks>�`�[�o�͔��s�敪</remarks>
        private Int32 _slipOutputDivCd;

        /// <summary>�t�H���[�`�[�o�͋敪</summary>
        /// <remarks>�t�H���[�`�[�o�͌`��</remarks>
        private Int32 _followSlipOutputDiv;

        /// <summary>�v����t�敪</summary>
        /// <remarks>�`���U������t</remarks>
        private Int32 _addUpADateDiv;

        /// <summary>�݌Ɉꊇ�i�ԋ敪</summary>
        /// <remarks>�݌Ɉꊇ��֕i�ԋ敪</remarks>
        private Int32 _stockBlnktPrtNoDiv;

        /// <summary>���[�J�[�t�H���[�v��敪</summary>
        /// <remarks>���[�J�[�t�H���[�v��敪</remarks>
        private Int32 _makerFollowAddUpDiv;

        /// <summary>����G���[����敪</summary>
        /// <remarks>����װؽĈ���敪</remarks>
        private Int32 _circuitErrPrtDiv;

        /// <summary>�������ɍX�V�敪</summary>
        /// <remarks>�������ɍX�V�敪</remarks>
        private Int32 _distEnterDiv;

        /// <summary>�������_�ݒ�敪</summary>
        /// <remarks>�����c�Ə��ݒ�敪</remarks>
        private Int32 _distSectionSetDiv;

        /// <summary>�����p���}�[�N�敪</summary>
        /// <remarks>�����p�U���}�[�N�敪</remarks>
        private Int32 _meijiRemark;

        /// <summary>����͌������}�[�N</summary>
        /// <remarks>����͌������}�[�N</remarks>
        private string _inpSearchRemark = "";

        /// <summary>�݌Ɉꊇ��[���}�[�N</summary>
        /// <remarks>�݌Ɉꊇ��[���}�[�N</remarks>
        private string _stockBlnktRemark = "";

        /// <summary>�`�����}�[�N</summary>
        /// <remarks>�`���U���}�[�N</remarks>
        private string _slipOutputRemark = "";

        /// <summary>�`�����}�[�N�敪</summary>
        /// <remarks>�`���U���}�[�N�敪 ���\����1:�ϰ�(��)�𓝍�������</remarks>
        private Int32 _slipOutputRemarkDiv;

        /// <summary>UOE�`�[���s�敪</summary>
        /// <remarks>UOE�`�[���s�敪</remarks>
        private Int32 _uOESlipPrtDiv;

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

        /// public propaty name  :  SlipOutputDivCd
        /// <summary>�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>�`�[�o�͔��s�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipOutputDivCd
        {
            get { return _slipOutputDivCd; }
            set { _slipOutputDivCd = value; }
        }

        /// public propaty name  :  FollowSlipOutputDiv
        /// <summary>�t�H���[�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>�t�H���[�`�[�o�͌`��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FollowSlipOutputDiv
        {
            get { return _followSlipOutputDiv; }
            set { _followSlipOutputDiv = value; }
        }

        /// public propaty name  :  AddUpADateDiv
        /// <summary>�v����t�敪�v���p�e�B</summary>
        /// <value>�`���U������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpADateDiv
        {
            get { return _addUpADateDiv; }
            set { _addUpADateDiv = value; }
        }

        /// public propaty name  :  StockBlnktPrtNoDiv
        /// <summary>�݌Ɉꊇ�i�ԋ敪�v���p�e�B</summary>
        /// <value>�݌Ɉꊇ��֕i�ԋ敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ�i�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockBlnktPrtNoDiv
        {
            get { return _stockBlnktPrtNoDiv; }
            set { _stockBlnktPrtNoDiv = value; }
        }

        /// public propaty name  :  MakerFollowAddUpDiv
        /// <summary>���[�J�[�t�H���[�v��敪�v���p�e�B</summary>
        /// <value>���[�J�[�t�H���[�v��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�t�H���[�v��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerFollowAddUpDiv
        {
            get { return _makerFollowAddUpDiv; }
            set { _makerFollowAddUpDiv = value; }
        }

        /// public propaty name  :  CircuitErrPrtDiv
        /// <summary>����G���[����敪�v���p�e�B</summary>
        /// <value>����װؽĈ���敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����G���[����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CircuitErrPrtDiv
        {
            get { return _circuitErrPrtDiv; }
            set { _circuitErrPrtDiv = value; }
        }

        /// public propaty name  :  DistEnterDiv
        /// <summary>�������ɍX�V�敪�v���p�e�B</summary>
        /// <value>�������ɍX�V�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ɍX�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DistEnterDiv
        {
            get { return _distEnterDiv; }
            set { _distEnterDiv = value; }
        }

        /// public propaty name  :  DistSectionSetDiv
        /// <summary>�������_�ݒ�敪�v���p�e�B</summary>
        /// <value>�����c�Ə��ݒ�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DistSectionSetDiv
        {
            get { return _distSectionSetDiv; }
            set { _distSectionSetDiv = value; }
        }

        /// public propaty name  :  MeijiRemark
        /// <summary>�����p���}�[�N�敪�v���p�e�B</summary>
        /// <value>�����p�U���}�[�N�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����p���}�[�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MeijiRemark
        {
            get { return _meijiRemark; }
            set { _meijiRemark = value; }
        }

        /// public propaty name  :  InpSearchRemark
        /// <summary>����͌������}�[�N�v���p�e�B</summary>
        /// <value>����͌������}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����͌������}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSearchRemark
        {
            get { return _inpSearchRemark; }
            set { _inpSearchRemark = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>�݌Ɉꊇ��[���}�[�N�v���p�e�B</summary>
        /// <value>�݌Ɉꊇ��[���}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ��[���}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemark
        /// <summary>�`�����}�[�N�v���p�e�B</summary>
        /// <value>�`���U���}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�����}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipOutputRemark
        {
            get { return _slipOutputRemark; }
            set { _slipOutputRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemarkDiv
        /// <summary>�`�����}�[�N�敪�v���p�e�B</summary>
        /// <value>�`���U���}�[�N�敪 ���\����1:�ϰ�(��)�𓝍�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�����}�[�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipOutputRemarkDiv
        {
            get { return _slipOutputRemarkDiv; }
            set { _slipOutputRemarkDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE�`�[���s�敪�v���p�e�B</summary>
        /// <value>UOE�`�[���s�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
        }


        /// <summary>
        /// UOE���Аݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOESettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>UOESettingWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class UOESettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOESettingWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOESettingWork || graph is ArrayList || graph is UOESettingWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UOESettingWork).FullName));

            if (graph != null && graph is UOESettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOESettingWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOESettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOESettingWork[])graph).Length;
            }
            else if (graph is UOESettingWork)
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
            //�`�[�o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipOutputDivCd
            //�t�H���[�`�[�o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FollowSlipOutputDiv
            //�v����t�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADateDiv
            //�݌Ɉꊇ�i�ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockBlnktPrtNoDiv
            //���[�J�[�t�H���[�v��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowAddUpDiv
            //����G���[����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CircuitErrPrtDiv
            //�������ɍX�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DistEnterDiv
            //�������_�ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DistSectionSetDiv
            //�����p���}�[�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MeijiRemark
            //����͌������}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //InpSearchRemark
            //�݌Ɉꊇ��[���}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //StockBlnktRemark
            //�`�����}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //SlipOutputRemark
            //�`�����}�[�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipOutputRemarkDiv
            //UOE�`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESlipPrtDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is UOESettingWork)
            {
                UOESettingWork temp = (UOESettingWork)graph;

                SetUOESettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOESettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOESettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOESettingWork temp in lst)
                {
                    SetUOESettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOESettingWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  UOESettingWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetUOESettingWork(System.IO.BinaryWriter writer, UOESettingWork temp)
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
            //�`�[�o�͋敪
            writer.Write(temp.SlipOutputDivCd);
            //�t�H���[�`�[�o�͋敪
            writer.Write(temp.FollowSlipOutputDiv);
            //�v����t�敪
            writer.Write(temp.AddUpADateDiv);
            //�݌Ɉꊇ�i�ԋ敪
            writer.Write(temp.StockBlnktPrtNoDiv);
            //���[�J�[�t�H���[�v��敪
            writer.Write(temp.MakerFollowAddUpDiv);
            //����G���[����敪
            writer.Write(temp.CircuitErrPrtDiv);
            //�������ɍX�V�敪
            writer.Write(temp.DistEnterDiv);
            //�������_�ݒ�敪
            writer.Write(temp.DistSectionSetDiv);
            //�����p���}�[�N�敪
            writer.Write(temp.MeijiRemark);
            //����͌������}�[�N
            writer.Write(temp.InpSearchRemark);
            //�݌Ɉꊇ��[���}�[�N
            writer.Write(temp.StockBlnktRemark);
            //�`�����}�[�N
            writer.Write(temp.SlipOutputRemark);
            //�`�����}�[�N�敪
            writer.Write(temp.SlipOutputRemarkDiv);
            //UOE�`�[���s�敪
            writer.Write(temp.UOESlipPrtDiv);

        }

        /// <summary>
        ///  UOESettingWork�C���X�^���X�擾
        /// </summary>
        /// <returns>UOESettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private UOESettingWork GetUOESettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            UOESettingWork temp = new UOESettingWork();

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
            //�`�[�o�͋敪
            temp.SlipOutputDivCd = reader.ReadInt32();
            //�t�H���[�`�[�o�͋敪
            temp.FollowSlipOutputDiv = reader.ReadInt32();
            //�v����t�敪
            temp.AddUpADateDiv = reader.ReadInt32();
            //�݌Ɉꊇ�i�ԋ敪
            temp.StockBlnktPrtNoDiv = reader.ReadInt32();
            //���[�J�[�t�H���[�v��敪
            temp.MakerFollowAddUpDiv = reader.ReadInt32();
            //����G���[����敪
            temp.CircuitErrPrtDiv = reader.ReadInt32();
            //�������ɍX�V�敪
            temp.DistEnterDiv = reader.ReadInt32();
            //�������_�ݒ�敪
            temp.DistSectionSetDiv = reader.ReadInt32();
            //�����p���}�[�N�敪
            temp.MeijiRemark = reader.ReadInt32();
            //����͌������}�[�N
            temp.InpSearchRemark = reader.ReadString();
            //�݌Ɉꊇ��[���}�[�N
            temp.StockBlnktRemark = reader.ReadString();
            //�`�����}�[�N
            temp.SlipOutputRemark = reader.ReadString();
            //�`�����}�[�N�敪
            temp.SlipOutputRemarkDiv = reader.ReadInt32();
            //UOE�`�[���s�敪
            temp.UOESlipPrtDiv = reader.ReadInt32();


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
        /// <returns>UOESettingWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESettingWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOESettingWork temp = GetUOESettingWork(reader, serInfo);
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
                    retValue = (UOESettingWork[])lst.ToArray(typeof(UOESettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

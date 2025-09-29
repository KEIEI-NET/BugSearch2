using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OprtnHisLogWork
    /// <summary>
    ///                      ���엚�����O�\���N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���엚�����O�\���N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OprtnHisLogWork : IFileHeader
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

        /// <summary>���O�f�[�^�쐬����</summary>
        private DateTime _logDataCreateDateTime;

        /// <summary>���O�f�[�^GUID</summary>
        private Guid _logDataGuid;

        /// <summary>���O�C�����_�R�[�h</summary>
        private string _loginSectionCd = "";

        /// <summary>���O�f�[�^��ʋ敪�R�[�h</summary>
        /// <remarks>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</remarks>
        private Int32 _logDataKindCd;

        /// <summary>���O�f�[�^�[����</summary>
        private string _logDataMachineName = "";

        /// <summary>���O�f�[�^�S���҃R�[�h</summary>
        private string _logDataAgentCd = "";

        /// <summary>���O�f�[�^�S���Җ�</summary>
        private string _logDataAgentNm = "";

        /// <summary>���O�f�[�^�ΏۋN���v���O��������</summary>
        /// <remarks>���O���������񂾃A�Z���u���̋N���v���O��������</remarks>
        private string _logDataObjBootProgramNm = "";

        /// <summary>���O�f�[�^�ΏۃA�Z���u��ID</summary>
        /// <remarks>���O���������񂾃A�Z���u��ID</remarks>
        private string _logDataObjAssemblyID = "";

        /// <summary>���O�f�[�^�ΏۃA�Z���u������</summary>
        /// <remarks>���O���������񂾃A�Z���u������</remarks>
        private string _logDataObjAssemblyNm = "";

        /// <summary>���O�f�[�^�ΏۃN���XID</summary>
        /// <remarks>���O�ɏ������ތ����ƂȂ����N���XID</remarks>
        private string _logDataObjClassID = "";

        /// <summary>���O�f�[�^�Ώۏ�����</summary>
        /// <remarks>���O���������ލۂ̏�����(���\�b�h��)</remarks>
        private string _logDataObjProcNm = "";

        /// <summary>���O�f�[�^�I�y���[�V�����R�[�h</summary>
        /// <remarks>������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)</remarks>
        private Int32 _logDataOperationCd;

        /// <summary>���O�f�[�^�I�y���[�^�[�f�[�^�������x��</summary>
        /// <remarks>���ڰ����ް��������̾���è����</remarks>
        private string _logOperaterDtProcLvl = "";

        /// <summary>���O�f�[�^�I�y���[�^�[�@�\�������x��</summary>
        /// <remarks>���ڰ����ް��������̾���è����</remarks>
        private string _logOperaterFuncLvl = "";

        /// <summary>���O�f�[�^�V�X�e���o�[�W����</summary>
        /// <remarks>�v���O�����̃o�[�W�������̃o�[�W����</remarks>
        private string _logDataSystemVersion = "";

        /// <summary>���O�I�y���[�V�����X�e�[�^�X</summary>
        /// <remarks>�I�y���[�V�������ʃX�e�[�^�X</remarks>
        private Int32 _logOperationStatus;

        /// <summary>���O�f�[�^���b�Z�[�W</summary>
        /// <remarks>�G���[���e�E�������e�Ȃ�</remarks>
        private string _logDataMassage = "";

        /// <summary>���O�I�y���[�V�����f�[�^</summary>
        /// <remarks>�G���[�̌����ƂȂ����f�[�^��L�[���e�E����͏����ڍׂȂ�</remarks>
        private string _logOperationData = "";


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

        /// public propaty name  :  LogDataCreateDateTime
        /// <summary>���O�f�[�^�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LogDataCreateDateTime
        {
            get { return _logDataCreateDateTime; }
            set { _logDataCreateDateTime = value; }
        }

        /// public propaty name  :  LogDataGuid
        /// <summary>���O�f�[�^GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid LogDataGuid
        {
            get { return _logDataGuid; }
            set { _logDataGuid = value; }
        }

        /// public propaty name  :  LoginSectionCd
        /// <summary>���O�C�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginSectionCd
        {
            get { return _loginSectionCd; }
            set { _loginSectionCd = value; }
        }

        /// public propaty name  :  LogDataKindCd
        /// <summary>���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</summary>
        /// <value>0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^��ʋ敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogDataKindCd
        {
            get { return _logDataKindCd; }
            set { _logDataKindCd = value; }
        }

        /// public propaty name  :  LogDataMachineName
        /// <summary>���O�f�[�^�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
            set { _logDataMachineName = value; }
        }

        /// public propaty name  :  LogDataAgentCd
        /// <summary>���O�f�[�^�S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataAgentCd
        {
            get { return _logDataAgentCd; }
            set { _logDataAgentCd = value; }
        }

        /// public propaty name  :  LogDataAgentNm
        /// <summary>���O�f�[�^�S���Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�S���Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataAgentNm
        {
            get { return _logDataAgentNm; }
            set { _logDataAgentNm = value; }
        }

        /// public propaty name  :  LogDataObjBootProgramNm
        /// <summary>���O�f�[�^�ΏۋN���v���O�������̃v���p�e�B</summary>
        /// <value>���O���������񂾃A�Z���u���̋N���v���O��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�ΏۋN���v���O�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjBootProgramNm
        {
            get { return _logDataObjBootProgramNm; }
            set { _logDataObjBootProgramNm = value; }
        }

        /// public propaty name  :  LogDataObjAssemblyID
        /// <summary>���O�f�[�^�ΏۃA�Z���u��ID�v���p�e�B</summary>
        /// <value>���O���������񂾃A�Z���u��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�ΏۃA�Z���u��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjAssemblyID
        {
            get { return _logDataObjAssemblyID; }
            set { _logDataObjAssemblyID = value; }
        }

        /// public propaty name  :  LogDataObjAssemblyNm
        /// <summary>���O�f�[�^�ΏۃA�Z���u�����̃v���p�e�B</summary>
        /// <value>���O���������񂾃A�Z���u������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�ΏۃA�Z���u�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjAssemblyNm
        {
            get { return _logDataObjAssemblyNm; }
            set { _logDataObjAssemblyNm = value; }
        }

        /// public propaty name  :  LogDataObjClassID
        /// <summary>���O�f�[�^�ΏۃN���XID�v���p�e�B</summary>
        /// <value>���O�ɏ������ތ����ƂȂ����N���XID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�ΏۃN���XID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjClassID
        {
            get { return _logDataObjClassID; }
            set { _logDataObjClassID = value; }
        }

        /// public propaty name  :  LogDataObjProcNm
        /// <summary>���O�f�[�^�Ώۏ������v���p�e�B</summary>
        /// <value>���O���������ލۂ̏�����(���\�b�h��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�Ώۏ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjProcNm
        {
            get { return _logDataObjProcNm; }
            set { _logDataObjProcNm = value; }
        }

        /// public propaty name  :  LogDataOperationCd
        /// <summary>���O�f�[�^�I�y���[�V�����R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�I�y���[�V�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogDataOperationCd
        {
            get { return _logDataOperationCd; }
            set { _logDataOperationCd = value; }
        }

        /// public propaty name  :  LogOperaterDtProcLvl
        /// <summary>���O�f�[�^�I�y���[�^�[�f�[�^�������x���v���p�e�B</summary>
        /// <value>���ڰ����ް��������̾���è����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�I�y���[�^�[�f�[�^�������x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogOperaterDtProcLvl
        {
            get { return _logOperaterDtProcLvl; }
            set { _logOperaterDtProcLvl = value; }
        }

        /// public propaty name  :  LogOperaterFuncLvl
        /// <summary>���O�f�[�^�I�y���[�^�[�@�\�������x���v���p�e�B</summary>
        /// <value>���ڰ����ް��������̾���è����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�I�y���[�^�[�@�\�������x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogOperaterFuncLvl
        {
            get { return _logOperaterFuncLvl; }
            set { _logOperaterFuncLvl = value; }
        }

        /// public propaty name  :  LogDataSystemVersion
        /// <summary>���O�f�[�^�V�X�e���o�[�W�����v���p�e�B</summary>
        /// <value>�v���O�����̃o�[�W�������̃o�[�W����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�V�X�e���o�[�W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataSystemVersion
        {
            get { return _logDataSystemVersion; }
            set { _logDataSystemVersion = value; }
        }

        /// public propaty name  :  LogOperationStatus
        /// <summary>���O�I�y���[�V�����X�e�[�^�X�v���p�e�B</summary>
        /// <value>�I�y���[�V�������ʃX�e�[�^�X</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�I�y���[�V�����X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogOperationStatus
        {
            get { return _logOperationStatus; }
            set { _logOperationStatus = value; }
        }

        /// public propaty name  :  LogDataMassage
        /// <summary>���O�f�[�^���b�Z�[�W�v���p�e�B</summary>
        /// <value>�G���[���e�E�������e�Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataMassage
        {
            get { return _logDataMassage; }
            set { _logDataMassage = value; }
        }

        /// public propaty name  :  LogOperationData
        /// <summary>���O�I�y���[�V�����f�[�^�v���p�e�B</summary>
        /// <value>�G���[�̌����ƂȂ����f�[�^��L�[���e�E����͏����ڍׂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�I�y���[�V�����f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogOperationData
        {
            get { return _logOperationData; }
            set { _logOperationData = value; }
        }


        /// <summary>
        /// ���엚�����O�\���N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OprtnHisLogWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprtnHisLogWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>OprtnHisLogWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class OprtnHisLogWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OprtnHisLogWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OprtnHisLogWork || graph is ArrayList || graph is OprtnHisLogWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(OprtnHisLogWork).FullName));

            if (graph != null && graph is OprtnHisLogWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OprtnHisLogWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OprtnHisLogWork[])graph).Length;
            }
            else if (graph is OprtnHisLogWork)
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
            //���O�f�[�^�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //LogDataCreateDateTime
            //���O�f�[�^GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //LogDataGuid
            //���O�C�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //LoginSectionCd
            //���O�f�[�^��ʋ敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //LogDataKindCd
            //���O�f�[�^�[����
            serInfo.MemberInfo.Add(typeof(string)); //LogDataMachineName
            //���O�f�[�^�S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //LogDataAgentCd
            //���O�f�[�^�S���Җ�
            serInfo.MemberInfo.Add(typeof(string)); //LogDataAgentNm
            //���O�f�[�^�ΏۋN���v���O��������
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjBootProgramNm
            //���O�f�[�^�ΏۃA�Z���u��ID
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjAssemblyID
            //���O�f�[�^�ΏۃA�Z���u������
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjAssemblyNm
            //���O�f�[�^�ΏۃN���XID
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjClassID
            //���O�f�[�^�Ώۏ�����
            serInfo.MemberInfo.Add(typeof(string)); //LogDataObjProcNm
            //���O�f�[�^�I�y���[�V�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //LogDataOperationCd
            //���O�f�[�^�I�y���[�^�[�f�[�^�������x��
            serInfo.MemberInfo.Add(typeof(string)); //LogOperaterDtProcLvl
            //���O�f�[�^�I�y���[�^�[�@�\�������x��
            serInfo.MemberInfo.Add(typeof(string)); //LogOperaterFuncLvl
            //���O�f�[�^�V�X�e���o�[�W����
            serInfo.MemberInfo.Add(typeof(string)); //LogDataSystemVersion
            //���O�I�y���[�V�����X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //LogOperationStatus
            //���O�f�[�^���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //LogDataMassage
            //���O�I�y���[�V�����f�[�^
            serInfo.MemberInfo.Add(typeof(string)); //LogOperationData


            serInfo.Serialize(writer, serInfo);
            if (graph is OprtnHisLogWork)
            {
                OprtnHisLogWork temp = (OprtnHisLogWork)graph;

                SetOprtnHisLogWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OprtnHisLogWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OprtnHisLogWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OprtnHisLogWork temp in lst)
                {
                    SetOprtnHisLogWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OprtnHisLogWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  OprtnHisLogWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetOprtnHisLogWork(System.IO.BinaryWriter writer, OprtnHisLogWork temp)
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
            //���O�f�[�^�쐬����
            writer.Write((Int64)temp.LogDataCreateDateTime.Ticks);
            //���O�f�[�^GUID
            byte[] logDataGuidArray = temp.LogDataGuid.ToByteArray();
            writer.Write(logDataGuidArray.Length);
            writer.Write(temp.LogDataGuid.ToByteArray());
            //���O�C�����_�R�[�h
            writer.Write(temp.LoginSectionCd);
            //���O�f�[�^��ʋ敪�R�[�h
            writer.Write(temp.LogDataKindCd);
            //���O�f�[�^�[����
            writer.Write(temp.LogDataMachineName);
            //���O�f�[�^�S���҃R�[�h
            writer.Write(temp.LogDataAgentCd);
            //���O�f�[�^�S���Җ�
            writer.Write(temp.LogDataAgentNm);
            //���O�f�[�^�ΏۋN���v���O��������
            writer.Write(temp.LogDataObjBootProgramNm);
            //���O�f�[�^�ΏۃA�Z���u��ID
            writer.Write(temp.LogDataObjAssemblyID);
            //���O�f�[�^�ΏۃA�Z���u������
            writer.Write(temp.LogDataObjAssemblyNm);
            //���O�f�[�^�ΏۃN���XID
            writer.Write(temp.LogDataObjClassID);
            //���O�f�[�^�Ώۏ�����
            writer.Write(temp.LogDataObjProcNm);
            //���O�f�[�^�I�y���[�V�����R�[�h
            writer.Write(temp.LogDataOperationCd);
            //���O�f�[�^�I�y���[�^�[�f�[�^�������x��
            writer.Write(temp.LogOperaterDtProcLvl);
            //���O�f�[�^�I�y���[�^�[�@�\�������x��
            writer.Write(temp.LogOperaterFuncLvl);
            //���O�f�[�^�V�X�e���o�[�W����
            writer.Write(temp.LogDataSystemVersion);
            //���O�I�y���[�V�����X�e�[�^�X
            writer.Write(temp.LogOperationStatus);
            //���O�f�[�^���b�Z�[�W
            writer.Write(temp.LogDataMassage);
            //���O�I�y���[�V�����f�[�^
            writer.Write(temp.LogOperationData);

        }

        /// <summary>
        ///  OprtnHisLogWork�C���X�^���X�擾
        /// </summary>
        /// <returns>OprtnHisLogWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private OprtnHisLogWork GetOprtnHisLogWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            OprtnHisLogWork temp = new OprtnHisLogWork();

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
            //���O�f�[�^�쐬����
            temp.LogDataCreateDateTime = new DateTime(reader.ReadInt64());
            //���O�f�[�^GUID
            int lenOfLogDataGuidArray = reader.ReadInt32();
            byte[] logDataGuidArray = reader.ReadBytes(lenOfLogDataGuidArray);
            temp.LogDataGuid = new Guid(logDataGuidArray);
            //���O�C�����_�R�[�h
            temp.LoginSectionCd = reader.ReadString();
            //���O�f�[�^��ʋ敪�R�[�h
            temp.LogDataKindCd = reader.ReadInt32();
            //���O�f�[�^�[����
            temp.LogDataMachineName = reader.ReadString();
            //���O�f�[�^�S���҃R�[�h
            temp.LogDataAgentCd = reader.ReadString();
            //���O�f�[�^�S���Җ�
            temp.LogDataAgentNm = reader.ReadString();
            //���O�f�[�^�ΏۋN���v���O��������
            temp.LogDataObjBootProgramNm = reader.ReadString();
            //���O�f�[�^�ΏۃA�Z���u��ID
            temp.LogDataObjAssemblyID = reader.ReadString();
            //���O�f�[�^�ΏۃA�Z���u������
            temp.LogDataObjAssemblyNm = reader.ReadString();
            //���O�f�[�^�ΏۃN���XID
            temp.LogDataObjClassID = reader.ReadString();
            //���O�f�[�^�Ώۏ�����
            temp.LogDataObjProcNm = reader.ReadString();
            //���O�f�[�^�I�y���[�V�����R�[�h
            temp.LogDataOperationCd = reader.ReadInt32();
            //���O�f�[�^�I�y���[�^�[�f�[�^�������x��
            temp.LogOperaterDtProcLvl = reader.ReadString();
            //���O�f�[�^�I�y���[�^�[�@�\�������x��
            temp.LogOperaterFuncLvl = reader.ReadString();
            //���O�f�[�^�V�X�e���o�[�W����
            temp.LogDataSystemVersion = reader.ReadString();
            //���O�I�y���[�V�����X�e�[�^�X
            temp.LogOperationStatus = reader.ReadInt32();
            //���O�f�[�^���b�Z�[�W
            temp.LogDataMassage = reader.ReadString();
            //���O�I�y���[�V�����f�[�^
            temp.LogOperationData = reader.ReadString();


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
        /// <returns>OprtnHisLogWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLogWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OprtnHisLogWork temp = GetOprtnHisLogWork(reader, serInfo);
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
                    retValue = (OprtnHisLogWork[])lst.ToArray(typeof(OprtnHisLogWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

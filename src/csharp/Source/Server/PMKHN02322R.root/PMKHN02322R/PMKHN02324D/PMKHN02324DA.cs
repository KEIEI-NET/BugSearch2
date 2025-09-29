//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͑��샍�O�o�^����
// �v���O�����T�v   : �e�L�X�g�o�͑��샍�O�o�^�����o�^�p
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00  �쐬�S�� : �c����
// �� �� ��  2019/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TextOutPutOprtnHisLogWork
    /// <summary>
    ///                      �e�L�X�g�o�͑��샍�O�o�^�����o�^�p���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �e�L�X�g�o�͑��샍�O�o�^�����o�^�p���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2019/08/12</br>
    /// <br>Genarated Date   :   2019/08/12  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TextOutPutOprtnHisLogWork : IFileHeader
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

        /// <summary>�e�L�X�g�o�̓��ONo</summary>
        private Int64 _textOutLogNo;

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

        /// <summary>���O�I�y���[�V�����X�e�[�^�X</summary>
        /// <remarks>���O�f�[�^���o�f�[�^����</remarks>
        private Int32 _logDataCount;

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

        /// public propaty name  :  TextOutLogNo
        /// <summary>�e�L�X�g�o�̓��ONo</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�L�X�g�o�̓��ONo</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TextOutLogNo
        {
            get { return _textOutLogNo; }
            set { _textOutLogNo = value; }
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

        /// public propaty name  :  LogDataCount
        /// <summary>���O�I�y���[�V�����X�e�[�^�X�v���p�e�B</summary>
        /// <value>���O�f�[�^���o�f�[�^����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^���o�f�[�^�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogDataCount
        {
            get { return _logDataCount; }
            set { _logDataCount = value; }
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
        /// �e�L�X�g�o�͑��샍�O�o�^�����o�^�p�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TextOutPutOprtnHisLogWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TextOutPutOprtnHisLogWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TextOutPutOprtnHisLogWork()
        {
        }

    }
}

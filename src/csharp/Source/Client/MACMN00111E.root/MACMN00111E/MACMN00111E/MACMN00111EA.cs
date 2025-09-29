using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OprtnHisLog
    /// <summary>
    ///                      ���엚�����O�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���엚�����O�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/12/15</br>
    /// <br>Genarated Date   :   2008/12/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/10/27  �ؑ� ����</br>
    /// <br>                 :   ���O�f�[�^�I�y���[�V�������׃R�[�h�ǉ�</br>
    /// <br>                 :   ���O�f�[�^���b�Z�[�W���e�폜</br>
    /// <br>                 :   ���O�I�y���[�V�����f�[�^�T�C�Y�ύX</br>
    /// <br>                 :   ���O�f�[�^�쐬�����@DD�ύX</br>
    /// <br>                 :   ���O�f�[�^�ΏۋN���v���O�������́@DD�ύX</br>
    /// <br>                 :   ���O�I�y���[�V�����f�[�^�T�v�@�ǉ�</br>
    /// <br>                 :   �������x��1�@�ǉ�</br>
    /// <br>                 :   �������x��2�@�ǉ�</br>
    /// </remarks>
    public class OprtnHisLog
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
        private DateTime _logDataCreateDtTm;

        /// <summary>���O�f�[�^GUID</summary>
        private Guid _logDataGuid;

        /// <summary>���O�C�����_�R�[�h</summary>
        private string _loginSectionCd = "";

        /// <summary>���O�f�[�^��ʋ敪�R�[�h</summary>
        /// <remarks>0:�L�^,1:�G���[,9:�V�X�e��</remarks>
        private Int32 _logDataKindCd;

        /// <summary>���O�f�[�^�[����</summary>
        private string _logDataMachineName = "";

        /// <summary>���O�f�[�^�S���҃R�[�h</summary>
        private string _logDataAgentCd = "";

        /// <summary>���O�f�[�^�S���Җ�</summary>
        private string _logDataAgentNm = "";

        /// <summary>���O�f�[�^�ΏۋN���v���O��������</summary>
        /// <remarks>���O���������񂾃A�Z���u���̋N���v���O��������</remarks>
        private string _logDataObjBootPgName = "";

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
        /// <remarks>������e�R�[�h0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��</remarks>
        private Int32 _logDataOperationCd;

        /// <summary>���O�f�[�^�I�y���[�^�[�f�[�^�������x��</summary>
        /// <remarks>�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��</remarks>
        private string _logOperaterDtProcLvl = "";

        /// <summary>���O�f�[�^�I�y���[�^�[�@�\�������x��</summary>
        /// <remarks>�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��</remarks>
        private string _logOperaterFuncLvl = "";

        /// <summary>���O�f�[�^�V�X�e���o�[�W����</summary>
        /// <remarks>�v���O�����̃o�[�W�������̃o�[�W����</remarks>
        private string _logDataSystemVersion = "";

        /// <summary>���O�f�[�^�X�e�[�^�X</summary>
        /// <remarks>�G���[�R�[�h�A����(���폈���E����E���f)�Ȃ�</remarks>
        private Int32 _logOperationStatus;

        /// <summary>���O�f�[�^�I�y���[�V�������׃R�[�h</summary>
        /// <remarks>�R�[�f�B���O���x���̏����R�[�h���Z�b�g</remarks>
        private Int32 _logDataOprtnDtlCd;

        /// <summary>���O�I�y���[�V�����f�[�^�T�v</summary>
        private string _logOprtnDataSummary = "";

        /// <summary>���O�I�y���[�V�����f�[�^</summary>
        /// <remarks>�G���[�̌����ƂȂ����f�[�^��L�[���e���邢�͏����ڍׂȂ�</remarks>
        private string _logOperationData = "";

        /// <summary>�������x��1</summary>
        /// <remarks>10:����(�A���o�C�g),20:����(���Ј�),40:�o�b�N���[�h�S����,60:�X���̔���(�A���o�C�g),70:�X���̔���(���Ј�),71�`75:�O���[�v1�`5,80:�X��</remarks>
        private Int32 _authorityLevel1;

        /// <summary>�������x��2</summary>
        /// <remarks>10:�A���o�C�g,50:���Ј�</remarks>
        private Int32 _authorityLevel2;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  LogDataCreateDtTm
        /// <summary>���O�f�[�^�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LogDataCreateDtTm
        {
            get { return _logDataCreateDtTm; }
            set { _logDataCreateDtTm = value; }
        }

        /// public propaty name  :  LogDataCreateDtTmJpFormal
        /// <summary>���O�f�[�^�쐬���� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataCreateDtTmJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmJpInFormal
        /// <summary>���O�f�[�^�쐬���� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataCreateDtTmJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmAdFormal
        /// <summary>���O�f�[�^�쐬���� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataCreateDtTmAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _logDataCreateDtTm); }
            set { }
        }

        /// public propaty name  :  LogDataCreateDtTmAdInFormal
        /// <summary>���O�f�[�^�쐬���� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataCreateDtTmAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _logDataCreateDtTm); }
            set { }
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
        /// <value>0:�L�^,1:�G���[,9:�V�X�e��</value>
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

        /// public propaty name  :  LogDataObjBootPgName
        /// <summary>���O�f�[�^�ΏۋN���v���O�������̃v���p�e�B</summary>
        /// <value>���O���������񂾃A�Z���u���̋N���v���O��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�ΏۋN���v���O�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogDataObjBootPgName
        {
            get { return _logDataObjBootPgName; }
            set { _logDataObjBootPgName = value; }
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
        /// <value>������e�R�[�h0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��</value>
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
        /// <value>�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��</value>
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
        /// <value>�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��</value>
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
        /// <summary>���O�f�[�^�X�e�[�^�X�v���p�e�B</summary>
        /// <value>�G���[�R�[�h�A����(���폈���E����E���f)�Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogOperationStatus
        {
            get { return _logOperationStatus; }
            set { _logOperationStatus = value; }
        }

        /// public propaty name  :  LogDataOprtnDtlCd
        /// <summary>���O�f�[�^�I�y���[�V�������׃R�[�h�v���p�e�B</summary>
        /// <value>�R�[�f�B���O���x���̏����R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�f�[�^�I�y���[�V�������׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogDataOprtnDtlCd
        {
            get { return _logDataOprtnDtlCd; }
            set { _logDataOprtnDtlCd = value; }
        }

        /// public propaty name  :  LogOprtnDataSummary
        /// <summary>���O�I�y���[�V�����f�[�^�T�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�I�y���[�V�����f�[�^�T�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LogOprtnDataSummary
        {
            get { return _logOprtnDataSummary; }
            set { _logOprtnDataSummary = value; }
        }

        /// public propaty name  :  LogOperationData
        /// <summary>���O�I�y���[�V�����f�[�^�v���p�e�B</summary>
        /// <value>�G���[�̌����ƂȂ����f�[�^��L�[���e���邢�͏����ڍׂȂ�</value>
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

        /// public propaty name  :  AuthorityLevel1
        /// <summary>�������x��1�v���p�e�B</summary>
        /// <value>10:����(�A���o�C�g),20:����(���Ј�),40:�o�b�N���[�h�S����,60:�X���̔���(�A���o�C�g),70:�X���̔���(���Ј�),71�`75:�O���[�v1�`5,80:�X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevel1
        {
            get { return _authorityLevel1; }
            set { _authorityLevel1 = value; }
        }

        /// public propaty name  :  AuthorityLevel2
        /// <summary>�������x��2�v���p�e�B</summary>
        /// <value>10:�A���o�C�g,50:���Ј�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevel2
        {
            get { return _authorityLevel2; }
            set { _authorityLevel2 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// ���엚�����O�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>OprtnHisLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprtnHisLog()
        {
        }

        /// <summary>
        /// ���엚�����O�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="logDataCreateDtTm">���O�f�[�^�쐬����</param>
        /// <param name="logDataGuid">���O�f�[�^GUID</param>
        /// <param name="loginSectionCd">���O�C�����_�R�[�h</param>
        /// <param name="logDataKindCd">���O�f�[�^��ʋ敪�R�[�h(0:�L�^,1:�G���[,9:�V�X�e��)</param>
        /// <param name="logDataMachineName">���O�f�[�^�[����</param>
        /// <param name="logDataAgentCd">���O�f�[�^�S���҃R�[�h</param>
        /// <param name="logDataAgentNm">���O�f�[�^�S���Җ�</param>
        /// <param name="logDataObjBootPgName">���O�f�[�^�ΏۋN���v���O��������(���O���������񂾃A�Z���u���̋N���v���O��������)</param>
        /// <param name="logDataObjAssemblyID">���O�f�[�^�ΏۃA�Z���u��ID(���O���������񂾃A�Z���u��ID)</param>
        /// <param name="logDataObjAssemblyNm">���O�f�[�^�ΏۃA�Z���u������(���O���������񂾃A�Z���u������)</param>
        /// <param name="logDataObjClassID">���O�f�[�^�ΏۃN���XID(���O�ɏ������ތ����ƂȂ����N���XID)</param>
        /// <param name="logDataObjProcNm">���O�f�[�^�Ώۏ�����(���O���������ލۂ̏�����(���\�b�h��))</param>
        /// <param name="logDataOperationCd">���O�f�[�^�I�y���[�V�����R�[�h(������e�R�[�h0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)</param>
        /// <param name="logOperaterDtProcLvl">���O�f�[�^�I�y���[�^�[�f�[�^�������x��(�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��)</param>
        /// <param name="logOperaterFuncLvl">���O�f�[�^�I�y���[�^�[�@�\�������x��(�I�y���[�^�̃f�[�^�������̃Z�L�����e�B���x��)</param>
        /// <param name="logDataSystemVersion">���O�f�[�^�V�X�e���o�[�W����(�v���O�����̃o�[�W�������̃o�[�W����)</param>
        /// <param name="logOperationStatus">���O�f�[�^�X�e�[�^�X(�G���[�R�[�h�A����(���폈���E����E���f)�Ȃ�)</param>
        /// <param name="logDataOprtnDtlCd">���O�f�[�^�I�y���[�V�������׃R�[�h(�R�[�f�B���O���x���̏����R�[�h���Z�b�g)</param>
        /// <param name="logOprtnDataSummary">���O�I�y���[�V�����f�[�^�T�v</param>
        /// <param name="logOperationData">���O�I�y���[�V�����f�[�^(�G���[�̌����ƂȂ����f�[�^��L�[���e���邢�͏����ڍׂȂ�)</param>
        /// <param name="authorityLevel1">�������x��1(10:����(�A���o�C�g),20:����(���Ј�),40:�o�b�N���[�h�S����,60:�X���̔���(�A���o�C�g),70:�X���̔���(���Ј�),71�`75:�O���[�v1�`5,80:�X��)</param>
        /// <param name="authorityLevel2">�������x��2(10:�A���o�C�g,50:���Ј�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>OprtnHisLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprtnHisLog(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, DateTime logDataCreateDtTm, Guid logDataGuid, string loginSectionCd, Int32 logDataKindCd, string logDataMachineName, string logDataAgentCd, string logDataAgentNm, string logDataObjBootPgName, string logDataObjAssemblyID, string logDataObjAssemblyNm, string logDataObjClassID, string logDataObjProcNm, Int32 logDataOperationCd, string logOperaterDtProcLvl, string logOperaterFuncLvl, string logDataSystemVersion, Int32 logOperationStatus, Int32 logDataOprtnDtlCd, string logOprtnDataSummary, string logOperationData, Int32 authorityLevel1, Int32 authorityLevel2, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this.LogDataCreateDtTm = logDataCreateDtTm;
            this.LogDataGuid = logDataGuid;
            this._loginSectionCd = loginSectionCd;
            this._logDataKindCd = logDataKindCd;
            this._logDataMachineName = logDataMachineName;
            this._logDataAgentCd = logDataAgentCd;
            this._logDataAgentNm = logDataAgentNm;
            this._logDataObjBootPgName = logDataObjBootPgName;
            this._logDataObjAssemblyID = logDataObjAssemblyID;
            this._logDataObjAssemblyNm = logDataObjAssemblyNm;
            this._logDataObjClassID = logDataObjClassID;
            this._logDataObjProcNm = logDataObjProcNm;
            this._logDataOperationCd = logDataOperationCd;
            this._logOperaterDtProcLvl = logOperaterDtProcLvl;
            this._logOperaterFuncLvl = logOperaterFuncLvl;
            this._logDataSystemVersion = logDataSystemVersion;
            this._logOperationStatus = logOperationStatus;
            this._logDataOprtnDtlCd = logDataOprtnDtlCd;
            this._logOprtnDataSummary = logOprtnDataSummary;
            this._logOperationData = logOperationData;
            this._authorityLevel1 = authorityLevel1;
            this._authorityLevel2 = authorityLevel2;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���엚�����O�f�[�^��������
        /// </summary>
        /// <returns>OprtnHisLog�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OprtnHisLog�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OprtnHisLog Clone()
        {
            return new OprtnHisLog(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._logDataCreateDtTm, this._logDataGuid, this._loginSectionCd, this._logDataKindCd, this._logDataMachineName, this._logDataAgentCd, this._logDataAgentNm, this._logDataObjBootPgName, this._logDataObjAssemblyID, this._logDataObjAssemblyNm, this._logDataObjClassID, this._logDataObjProcNm, this._logDataOperationCd, this._logOperaterDtProcLvl, this._logOperaterFuncLvl, this._logDataSystemVersion, this._logOperationStatus, this._logDataOprtnDtlCd, this._logOprtnDataSummary, this._logOperationData, this._authorityLevel1, this._authorityLevel2, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// ���엚�����O�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OprtnHisLog�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(OprtnHisLog target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.LogDataCreateDtTm == target.LogDataCreateDtTm)
                 && (this.LogDataGuid == target.LogDataGuid)
                 && (this.LoginSectionCd == target.LoginSectionCd)
                 && (this.LogDataKindCd == target.LogDataKindCd)
                 && (this.LogDataMachineName == target.LogDataMachineName)
                 && (this.LogDataAgentCd == target.LogDataAgentCd)
                 && (this.LogDataAgentNm == target.LogDataAgentNm)
                 && (this.LogDataObjBootPgName == target.LogDataObjBootPgName)
                 && (this.LogDataObjAssemblyID == target.LogDataObjAssemblyID)
                 && (this.LogDataObjAssemblyNm == target.LogDataObjAssemblyNm)
                 && (this.LogDataObjClassID == target.LogDataObjClassID)
                 && (this.LogDataObjProcNm == target.LogDataObjProcNm)
                 && (this.LogDataOperationCd == target.LogDataOperationCd)
                 && (this.LogOperaterDtProcLvl == target.LogOperaterDtProcLvl)
                 && (this.LogOperaterFuncLvl == target.LogOperaterFuncLvl)
                 && (this.LogDataSystemVersion == target.LogDataSystemVersion)
                 && (this.LogOperationStatus == target.LogOperationStatus)
                 && (this.LogDataOprtnDtlCd == target.LogDataOprtnDtlCd)
                 && (this.LogOprtnDataSummary == target.LogOprtnDataSummary)
                 && (this.LogOperationData == target.LogOperationData)
                 && (this.AuthorityLevel1 == target.AuthorityLevel1)
                 && (this.AuthorityLevel2 == target.AuthorityLevel2)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���엚�����O�f�[�^��r����
        /// </summary>
        /// <param name="oprtnHisLog1">
        ///                    ��r����OprtnHisLog�N���X�̃C���X�^���X
        /// </param>
        /// <param name="oprtnHisLog2">��r����OprtnHisLog�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(OprtnHisLog oprtnHisLog1, OprtnHisLog oprtnHisLog2)
        {
            return ((oprtnHisLog1.CreateDateTime == oprtnHisLog2.CreateDateTime)
                 && (oprtnHisLog1.UpdateDateTime == oprtnHisLog2.UpdateDateTime)
                 && (oprtnHisLog1.EnterpriseCode == oprtnHisLog2.EnterpriseCode)
                 && (oprtnHisLog1.FileHeaderGuid == oprtnHisLog2.FileHeaderGuid)
                 && (oprtnHisLog1.UpdEmployeeCode == oprtnHisLog2.UpdEmployeeCode)
                 && (oprtnHisLog1.UpdAssemblyId1 == oprtnHisLog2.UpdAssemblyId1)
                 && (oprtnHisLog1.UpdAssemblyId2 == oprtnHisLog2.UpdAssemblyId2)
                 && (oprtnHisLog1.LogicalDeleteCode == oprtnHisLog2.LogicalDeleteCode)
                 && (oprtnHisLog1.LogDataCreateDtTm == oprtnHisLog2.LogDataCreateDtTm)
                 && (oprtnHisLog1.LogDataGuid == oprtnHisLog2.LogDataGuid)
                 && (oprtnHisLog1.LoginSectionCd == oprtnHisLog2.LoginSectionCd)
                 && (oprtnHisLog1.LogDataKindCd == oprtnHisLog2.LogDataKindCd)
                 && (oprtnHisLog1.LogDataMachineName == oprtnHisLog2.LogDataMachineName)
                 && (oprtnHisLog1.LogDataAgentCd == oprtnHisLog2.LogDataAgentCd)
                 && (oprtnHisLog1.LogDataAgentNm == oprtnHisLog2.LogDataAgentNm)
                 && (oprtnHisLog1.LogDataObjBootPgName == oprtnHisLog2.LogDataObjBootPgName)
                 && (oprtnHisLog1.LogDataObjAssemblyID == oprtnHisLog2.LogDataObjAssemblyID)
                 && (oprtnHisLog1.LogDataObjAssemblyNm == oprtnHisLog2.LogDataObjAssemblyNm)
                 && (oprtnHisLog1.LogDataObjClassID == oprtnHisLog2.LogDataObjClassID)
                 && (oprtnHisLog1.LogDataObjProcNm == oprtnHisLog2.LogDataObjProcNm)
                 && (oprtnHisLog1.LogDataOperationCd == oprtnHisLog2.LogDataOperationCd)
                 && (oprtnHisLog1.LogOperaterDtProcLvl == oprtnHisLog2.LogOperaterDtProcLvl)
                 && (oprtnHisLog1.LogOperaterFuncLvl == oprtnHisLog2.LogOperaterFuncLvl)
                 && (oprtnHisLog1.LogDataSystemVersion == oprtnHisLog2.LogDataSystemVersion)
                 && (oprtnHisLog1.LogOperationStatus == oprtnHisLog2.LogOperationStatus)
                 && (oprtnHisLog1.LogDataOprtnDtlCd == oprtnHisLog2.LogDataOprtnDtlCd)
                 && (oprtnHisLog1.LogOprtnDataSummary == oprtnHisLog2.LogOprtnDataSummary)
                 && (oprtnHisLog1.LogOperationData == oprtnHisLog2.LogOperationData)
                 && (oprtnHisLog1.AuthorityLevel1 == oprtnHisLog2.AuthorityLevel1)
                 && (oprtnHisLog1.AuthorityLevel2 == oprtnHisLog2.AuthorityLevel2)
                 && (oprtnHisLog1.EnterpriseName == oprtnHisLog2.EnterpriseName)
                 && (oprtnHisLog1.UpdEmployeeName == oprtnHisLog2.UpdEmployeeName));
        }
        /// <summary>
        /// ���엚�����O�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OprtnHisLog�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(OprtnHisLog target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.LogDataCreateDtTm != target.LogDataCreateDtTm) resList.Add("LogDataCreateDtTm");
            if (this.LogDataGuid != target.LogDataGuid) resList.Add("LogDataGuid");
            if (this.LoginSectionCd != target.LoginSectionCd) resList.Add("LoginSectionCd");
            if (this.LogDataKindCd != target.LogDataKindCd) resList.Add("LogDataKindCd");
            if (this.LogDataMachineName != target.LogDataMachineName) resList.Add("LogDataMachineName");
            if (this.LogDataAgentCd != target.LogDataAgentCd) resList.Add("LogDataAgentCd");
            if (this.LogDataAgentNm != target.LogDataAgentNm) resList.Add("LogDataAgentNm");
            if (this.LogDataObjBootPgName != target.LogDataObjBootPgName) resList.Add("LogDataObjBootPgName");
            if (this.LogDataObjAssemblyID != target.LogDataObjAssemblyID) resList.Add("LogDataObjAssemblyID");
            if (this.LogDataObjAssemblyNm != target.LogDataObjAssemblyNm) resList.Add("LogDataObjAssemblyNm");
            if (this.LogDataObjClassID != target.LogDataObjClassID) resList.Add("LogDataObjClassID");
            if (this.LogDataObjProcNm != target.LogDataObjProcNm) resList.Add("LogDataObjProcNm");
            if (this.LogDataOperationCd != target.LogDataOperationCd) resList.Add("LogDataOperationCd");
            if (this.LogOperaterDtProcLvl != target.LogOperaterDtProcLvl) resList.Add("LogOperaterDtProcLvl");
            if (this.LogOperaterFuncLvl != target.LogOperaterFuncLvl) resList.Add("LogOperaterFuncLvl");
            if (this.LogDataSystemVersion != target.LogDataSystemVersion) resList.Add("LogDataSystemVersion");
            if (this.LogOperationStatus != target.LogOperationStatus) resList.Add("LogOperationStatus");
            if (this.LogDataOprtnDtlCd != target.LogDataOprtnDtlCd) resList.Add("LogDataOprtnDtlCd");
            if (this.LogOprtnDataSummary != target.LogOprtnDataSummary) resList.Add("LogOprtnDataSummary");
            if (this.LogOperationData != target.LogOperationData) resList.Add("LogOperationData");
            if (this.AuthorityLevel1 != target.AuthorityLevel1) resList.Add("AuthorityLevel1");
            if (this.AuthorityLevel2 != target.AuthorityLevel2) resList.Add("AuthorityLevel2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���엚�����O�f�[�^��r����
        /// </summary>
        /// <param name="oprtnHisLog1">��r����OprtnHisLog�N���X�̃C���X�^���X</param>
        /// <param name="oprtnHisLog2">��r����OprtnHisLog�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OprtnHisLog�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(OprtnHisLog oprtnHisLog1, OprtnHisLog oprtnHisLog2)
        {
            ArrayList resList = new ArrayList();
            if (oprtnHisLog1.CreateDateTime != oprtnHisLog2.CreateDateTime) resList.Add("CreateDateTime");
            if (oprtnHisLog1.UpdateDateTime != oprtnHisLog2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oprtnHisLog1.EnterpriseCode != oprtnHisLog2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (oprtnHisLog1.FileHeaderGuid != oprtnHisLog2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (oprtnHisLog1.UpdEmployeeCode != oprtnHisLog2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (oprtnHisLog1.UpdAssemblyId1 != oprtnHisLog2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (oprtnHisLog1.UpdAssemblyId2 != oprtnHisLog2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (oprtnHisLog1.LogicalDeleteCode != oprtnHisLog2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oprtnHisLog1.LogDataCreateDtTm != oprtnHisLog2.LogDataCreateDtTm) resList.Add("LogDataCreateDtTm");
            if (oprtnHisLog1.LogDataGuid != oprtnHisLog2.LogDataGuid) resList.Add("LogDataGuid");
            if (oprtnHisLog1.LoginSectionCd != oprtnHisLog2.LoginSectionCd) resList.Add("LoginSectionCd");
            if (oprtnHisLog1.LogDataKindCd != oprtnHisLog2.LogDataKindCd) resList.Add("LogDataKindCd");
            if (oprtnHisLog1.LogDataMachineName != oprtnHisLog2.LogDataMachineName) resList.Add("LogDataMachineName");
            if (oprtnHisLog1.LogDataAgentCd != oprtnHisLog2.LogDataAgentCd) resList.Add("LogDataAgentCd");
            if (oprtnHisLog1.LogDataAgentNm != oprtnHisLog2.LogDataAgentNm) resList.Add("LogDataAgentNm");
            if (oprtnHisLog1.LogDataObjBootPgName != oprtnHisLog2.LogDataObjBootPgName) resList.Add("LogDataObjBootPgName");
            if (oprtnHisLog1.LogDataObjAssemblyID != oprtnHisLog2.LogDataObjAssemblyID) resList.Add("LogDataObjAssemblyID");
            if (oprtnHisLog1.LogDataObjAssemblyNm != oprtnHisLog2.LogDataObjAssemblyNm) resList.Add("LogDataObjAssemblyNm");
            if (oprtnHisLog1.LogDataObjClassID != oprtnHisLog2.LogDataObjClassID) resList.Add("LogDataObjClassID");
            if (oprtnHisLog1.LogDataObjProcNm != oprtnHisLog2.LogDataObjProcNm) resList.Add("LogDataObjProcNm");
            if (oprtnHisLog1.LogDataOperationCd != oprtnHisLog2.LogDataOperationCd) resList.Add("LogDataOperationCd");
            if (oprtnHisLog1.LogOperaterDtProcLvl != oprtnHisLog2.LogOperaterDtProcLvl) resList.Add("LogOperaterDtProcLvl");
            if (oprtnHisLog1.LogOperaterFuncLvl != oprtnHisLog2.LogOperaterFuncLvl) resList.Add("LogOperaterFuncLvl");
            if (oprtnHisLog1.LogDataSystemVersion != oprtnHisLog2.LogDataSystemVersion) resList.Add("LogDataSystemVersion");
            if (oprtnHisLog1.LogOperationStatus != oprtnHisLog2.LogOperationStatus) resList.Add("LogOperationStatus");
            if (oprtnHisLog1.LogDataOprtnDtlCd != oprtnHisLog2.LogDataOprtnDtlCd) resList.Add("LogDataOprtnDtlCd");
            if (oprtnHisLog1.LogOprtnDataSummary != oprtnHisLog2.LogOprtnDataSummary) resList.Add("LogOprtnDataSummary");
            if (oprtnHisLog1.LogOperationData != oprtnHisLog2.LogOperationData) resList.Add("LogOperationData");
            if (oprtnHisLog1.AuthorityLevel1 != oprtnHisLog2.AuthorityLevel1) resList.Add("AuthorityLevel1");
            if (oprtnHisLog1.AuthorityLevel2 != oprtnHisLog2.AuthorityLevel2) resList.Add("AuthorityLevel2");
            if (oprtnHisLog1.EnterpriseName != oprtnHisLog2.EnterpriseName) resList.Add("EnterpriseName");
            if (oprtnHisLog1.UpdEmployeeName != oprtnHisLog2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �T�C�Y�擾
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 0;

            // �쐬����
            size += sizeof(Int64);

            // �X�V����
            size += sizeof(Int64);

            // ��ƃR�[�h
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._enterpriseCode);

            // GUID
            size += System.Runtime.InteropServices.Marshal.SizeOf(this._fileHeaderGuid);

            // �X�V�]�ƈ��R�[�h
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updEmployeeCode);

            // �X�V�A�Z���u��ID1
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updAssemblyId1);

            // �X�V�A�Z���u��ID2
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._updAssemblyId2);

            // �_���폜�敪
            size += sizeof(Int32);

            // ���O�f�[�^�쐬����
            size += sizeof(Int64);

            // ���O�f�[�^GUID
            size += System.Runtime.InteropServices.Marshal.SizeOf(this._logDataGuid);

            // ���O�C�����_�R�[�h
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._loginSectionCd);

            // ���O�f�[�^��ʋ敪�R�[�h
            size += sizeof(Int32);

            // ���O�f�[�^�[����
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataMachineName);

            // ���O�f�[�^�S���҃R�[�h
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataAgentCd);

            // ���O�f�[�^�S���Җ�
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataAgentNm);

            // ���O�f�[�^�ΏۋN���v���O��������
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjBootPgName);

            // ���O�f�[�^�ΏۃA�Z���u��ID
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjAssemblyID);

            // ���O�f�[�^�ΏۃA�Z���u������
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjAssemblyNm);

            // ���O�f�[�^�ΏۃN���XID
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjClassID);

            // ���O�f�[�^�Ώۏ�����
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataObjProcNm);

            // ���O�f�[�^�I�y���[�V�����R�[�h
            size += sizeof(Int32);

            // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperaterDtProcLvl);

            // ���O�f�[�^�I�y���[�^�[�@�\�������x��
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperaterFuncLvl);

            // ���O�f�[�^�V�X�e���o�[�W����
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logDataSystemVersion);

            // ���O�I�y���[�V�����X�e�[�^�X
            size += sizeof(Int32);

            // ������2008.12.16 T-Kidate ADD
            // ���O�f�[�^�I�y���[�V�������׃R�[�h
            size += sizeof(Int32);

            // ���O�f�[�^���b�Z�[�W���e
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOprtnDataSummary);

            // ���O�I�y���[�V�����f�[�^
            size += System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(this._logOperationData);

            // ������2008.12.16 T-Kidate ADD
            // �������x���P
            size += sizeof(Int32);
            // �������x���Q
            size += sizeof(Int32);

            return size;
        }


    }
}

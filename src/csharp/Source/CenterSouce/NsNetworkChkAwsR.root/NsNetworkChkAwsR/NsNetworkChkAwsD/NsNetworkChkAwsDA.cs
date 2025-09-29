using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AWSComRsltWork
    /// <summary>
    ///                      AWS�ʐM�e�X�g���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   AWS�ʐM�e�X�g���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2018/12/27</br>
    /// <br>Genarated Date   :   2019/02/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2019/2/6  �O�c�@��</br>
    /// <br>                 :   Windows�o�[�W�����̍��ڒǉ�</br>
    /// <br>                 :   WindowsOS���̍��ڒǉ�</br>
    /// <br>                 :   �\�����ڂP�̍��ڒǉ�</br>
    /// <br>                 :   �\�����ڂQ�̍��ڒǉ�</br>
    /// <br>                 :   �\�����ڂR�̍��ڒǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AWSComRsltWork : IFileHeader
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
        /// <remarks>���O�C���̋��_</remarks>
        private string _sectionCode = "";

        /// <summary>���[�U�[�ݒ莯��ID</summary>
        /// <remarks>�e���[�U�[�[���P�ʂň�ӂƂȂ�ID</remarks>
        private string _userSetDiscId = "";

        /// <summary>�`�F�b�N���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _checkDate;

        /// <summary>�`�F�b�N����</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _checkTime;

        /// <summary>�R���s���[�^����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _computerName = "";

        /// <summary>�e�X�g����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _testName = "";

        /// <summary>�T�[�o�[�^�C�v</summary>
        /// <remarks>0:WEB,1:AP,2:�z�M,3:�v���L�V</remarks>
        private Int16 _serverType;

        /// <summary>�e�X�g�^�C�v</summary>
        /// <remarks>0:�e�X�g���Ȃ�,1:HTTP���N�G�X�g,2:�|�[�g�`�F�b�N,3:�z�M</remarks>
        private Int16 _testType;

        /// <summary>�e�X�g�ΏۃA�h���X</summary>
        /// <remarks>(���p�S�p����) �Í���</remarks>
        private string _testObjAddr = "";

        /// <summary>�`�F�b�N����</summary>
        /// <remarks>0:�ʐM����,1:�ʐM���s</remarks>
        private Int16 _checkRslt;

        /// <summary>���N�G�X�g�X�e�[�^�XNo</summary>
        /// <remarks>(��)200:���N�G�X�g����,404:�����[�g�T�[�o�[��������܂���</remarks>
        private Int32 _requestStatusNo;

        /// <summary>���N�G�X�g���b�Z�[�W</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _requestMessage = "";

        /// <summary>Windows�o�[�W����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _windowsVersion = "";

        /// <summary>WindowsOS��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _windowsOSName = "";

        /// <summary>�\�����ڂP</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _awsReserved1 = "";

        /// <summary>�\�����ڂQ</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _awsReserved2 = "";

        /// <summary>�\�����ڂR</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _awsReserved3 = "";


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
        /// <value>���O�C���̋��_</value>
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

        /// public propaty name  :  UserSetDiscId
        /// <summary>���[�U�[�ݒ莯��ID�v���p�e�B</summary>
        /// <value>�e���[�U�[�[���P�ʂň�ӂƂȂ�ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�ݒ莯��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UserSetDiscId
        {
            get { return _userSetDiscId; }
            set { _userSetDiscId = value; }
        }

        /// public propaty name  :  CheckDate
        /// <summary>�`�F�b�N���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckDate
        {
            get { return _checkDate; }
            set { _checkDate = value; }
        }

        /// public propaty name  :  CheckTime
        /// <summary>�`�F�b�N���ԃv���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckTime
        {
            get { return _checkTime; }
            set { _checkTime = value; }
        }

        /// public propaty name  :  ComputerName
        /// <summary>�R���s���[�^���̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R���s���[�^���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; }
        }

        /// public propaty name  :  TestName
        /// <summary>�e�X�g���̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�X�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        /// public propaty name  :  ServerType
        /// <summary>�T�[�o�[�^�C�v�v���p�e�B</summary>
        /// <value>0:WEB,1:AP,2:�z�M,3:�v���L�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �T�[�o�[�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ServerType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        /// public propaty name  :  TestType
        /// <summary>�e�X�g�^�C�v�v���p�e�B</summary>
        /// <value>0:�e�X�g���Ȃ�,1:HTTP���N�G�X�g,2:�|�[�g�`�F�b�N,3:�z�M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�X�g�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 TestType
        {
            get { return _testType; }
            set { _testType = value; }
        }

        /// public propaty name  :  TestObjAddr
        /// <summary>�e�X�g�ΏۃA�h���X�v���p�e�B</summary>
        /// <value>(���p�S�p����) �Í���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�X�g�ΏۃA�h���X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TestObjAddr
        {
            get { return _testObjAddr; }
            set { _testObjAddr = value; }
        }

        /// public propaty name  :  CheckRslt
        /// <summary>�`�F�b�N���ʃv���p�e�B</summary>
        /// <value>0:�ʐM����,1:�ʐM���s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CheckRslt
        {
            get { return _checkRslt; }
            set { _checkRslt = value; }
        }

        /// public propaty name  :  RequestStatusNo
        /// <summary>���N�G�X�g�X�e�[�^�XNo�v���p�e�B</summary>
        /// <value>(��)200:���N�G�X�g����,404:�����[�g�T�[�o�[��������܂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�G�X�g�X�e�[�^�XNo�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RequestStatusNo
        {
            get { return _requestStatusNo; }
            set { _requestStatusNo = value; }
        }

        /// public propaty name  :  RequestMessage
        /// <summary>���N�G�X�g���b�Z�[�W�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�G�X�g���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RequestMessage
        {
            get { return _requestMessage; }
            set { _requestMessage = value; }
        }

        /// public propaty name  :  WindowsVersion
        /// <summary>Windows�o�[�W�����v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Windows�o�[�W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WindowsVersion
        {
            get { return _windowsVersion; }
            set { _windowsVersion = value; }
        }

        /// public propaty name  :  WindowsOSName
        /// <summary>WindowsOS���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WindowsOS���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WindowsOSName
        {
            get { return _windowsOSName; }
            set { _windowsOSName = value; }
        }

        /// public propaty name  :  AwsReserved1
        /// <summary>�\�����ڂP�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ڂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AwsReserved1
        {
            get { return _awsReserved1; }
            set { _awsReserved1 = value; }
        }

        /// public propaty name  :  AwsReserved2
        /// <summary>�\�����ڂQ�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ڂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AwsReserved2
        {
            get { return _awsReserved2; }
            set { _awsReserved2 = value; }
        }

        /// public propaty name  :  AwsReserved3
        /// <summary>�\�����ڂR�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ڂR�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AwsReserved3
        {
            get { return _awsReserved3; }
            set { _awsReserved3 = value; }
        }


        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AWSComRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AWSComRsltWork()
        {
        }

        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(���O�C���̋��_)</param>
        /// <param name="userSetDiscId">���[�U�[�ݒ莯��ID(�e���[�U�[�[���P�ʂň�ӂƂȂ�ID)</param>
        /// <param name="checkDate">�`�F�b�N���t(YYYYMMDD)</param>
        /// <param name="checkTime">�`�F�b�N����(HHMMSS)</param>
        /// <param name="computerName">�R���s���[�^����((���p�S�p����))</param>
        /// <param name="testName">�e�X�g����((���p�S�p����))</param>
        /// <param name="serverType">�T�[�o�[�^�C�v(0:WEB,1:AP,2:�z�M,3:�v���L�V)</param>
        /// <param name="testType">�e�X�g�^�C�v(0:�e�X�g���Ȃ�,1:HTTP���N�G�X�g,2:�|�[�g�`�F�b�N,3:�z�M)</param>
        /// <param name="testObjAddr">�e�X�g�ΏۃA�h���X((���p�S�p����) �Í���)</param>
        /// <param name="checkRslt">�`�F�b�N����(0:�ʐM����,1:�ʐM���s)</param>
        /// <param name="requestStatusNo">���N�G�X�g�X�e�[�^�XNo((��)200:���N�G�X�g����,404:�����[�g�T�[�o�[��������܂���)</param>
        /// <param name="requestMessage">���N�G�X�g���b�Z�[�W((���p�S�p����))</param>
        /// <param name="windowsVersion">Windows�o�[�W����((���p�S�p����))</param>
        /// <param name="windowsOSName">WindowsOS��((���p�S�p����))</param>
        /// <param name="awsReserved1">�\�����ڂP((���p�S�p����))</param>
        /// <param name="awsReserved2">�\�����ڂQ((���p�S�p����))</param>
        /// <param name="awsReserved3">�\�����ڂR((���p�S�p����))</param>
        /// <returns>AWSComRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AWSComRsltWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string userSetDiscId, Int32 checkDate, Int32 checkTime, string computerName, string testName, Int16 serverType, Int16 testType, string testObjAddr, Int16 checkRslt, Int32 requestStatusNo, string requestMessage, string windowsVersion, string windowsOSName, string awsReserved1, string awsReserved2, string awsReserved3)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._userSetDiscId = userSetDiscId;
            this._checkDate = checkDate;
            this._checkTime = checkTime;
            this._computerName = computerName;
            this._testName = testName;
            this._serverType = serverType;
            this._testType = testType;
            this._testObjAddr = testObjAddr;
            this._checkRslt = checkRslt;
            this._requestStatusNo = requestStatusNo;
            this._requestMessage = requestMessage;
            this._windowsVersion = windowsVersion;
            this._windowsOSName = windowsOSName;
            this._awsReserved1 = awsReserved1;
            this._awsReserved2 = awsReserved2;
            this._awsReserved3 = awsReserved3;

        }

        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N��������
        /// </summary>
        /// <returns>AWSComRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AWSComRsltWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AWSComRsltWork Clone()
        {
            return new AWSComRsltWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._userSetDiscId, this._checkDate, this._checkTime, this._computerName, this._testName, this._serverType, this._testType, this._testObjAddr, this._checkRslt, this._requestStatusNo, this._requestMessage, this._windowsVersion, this._windowsOSName, this._awsReserved1, this._awsReserved2, this._awsReserved3);
        }

        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AWSComRsltWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AWSComRsltWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UserSetDiscId == target.UserSetDiscId)
                 && (this.CheckDate == target.CheckDate)
                 && (this.CheckTime == target.CheckTime)
                 && (this.ComputerName == target.ComputerName)
                 && (this.TestName == target.TestName)
                 && (this.ServerType == target.ServerType)
                 && (this.TestType == target.TestType)
                 && (this.TestObjAddr == target.TestObjAddr)
                 && (this.CheckRslt == target.CheckRslt)
                 && (this.RequestStatusNo == target.RequestStatusNo)
                 && (this.RequestMessage == target.RequestMessage)
                 && (this.WindowsVersion == target.WindowsVersion)
                 && (this.WindowsOSName == target.WindowsOSName)
                 && (this.AwsReserved1 == target.AwsReserved1)
                 && (this.AwsReserved2 == target.AwsReserved2)
                 && (this.AwsReserved3 == target.AwsReserved3));
        }

        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N��r����
        /// </summary>
        /// <param name="aWSComRslt1">
        ///                    ��r����AWSComRsltWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="aWSComRslt2">��r����AWSComRsltWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AWSComRsltWork aWSComRslt1, AWSComRsltWork aWSComRslt2)
        {
            return ((aWSComRslt1.CreateDateTime == aWSComRslt2.CreateDateTime)
                 && (aWSComRslt1.UpdateDateTime == aWSComRslt2.UpdateDateTime)
                 && (aWSComRslt1.EnterpriseCode == aWSComRslt2.EnterpriseCode)
                 && (aWSComRslt1.FileHeaderGuid == aWSComRslt2.FileHeaderGuid)
                 && (aWSComRslt1.UpdEmployeeCode == aWSComRslt2.UpdEmployeeCode)
                 && (aWSComRslt1.UpdAssemblyId1 == aWSComRslt2.UpdAssemblyId1)
                 && (aWSComRslt1.UpdAssemblyId2 == aWSComRslt2.UpdAssemblyId2)
                 && (aWSComRslt1.LogicalDeleteCode == aWSComRslt2.LogicalDeleteCode)
                 && (aWSComRslt1.SectionCode == aWSComRslt2.SectionCode)
                 && (aWSComRslt1.UserSetDiscId == aWSComRslt2.UserSetDiscId)
                 && (aWSComRslt1.CheckDate == aWSComRslt2.CheckDate)
                 && (aWSComRslt1.CheckTime == aWSComRslt2.CheckTime)
                 && (aWSComRslt1.ComputerName == aWSComRslt2.ComputerName)
                 && (aWSComRslt1.TestName == aWSComRslt2.TestName)
                 && (aWSComRslt1.ServerType == aWSComRslt2.ServerType)
                 && (aWSComRslt1.TestType == aWSComRslt2.TestType)
                 && (aWSComRslt1.TestObjAddr == aWSComRslt2.TestObjAddr)
                 && (aWSComRslt1.CheckRslt == aWSComRslt2.CheckRslt)
                 && (aWSComRslt1.RequestStatusNo == aWSComRslt2.RequestStatusNo)
                 && (aWSComRslt1.RequestMessage == aWSComRslt2.RequestMessage)
                 && (aWSComRslt1.WindowsVersion == aWSComRslt2.WindowsVersion)
                 && (aWSComRslt1.WindowsOSName == aWSComRslt2.WindowsOSName)
                 && (aWSComRslt1.AwsReserved1 == aWSComRslt2.AwsReserved1)
                 && (aWSComRslt1.AwsReserved2 == aWSComRslt2.AwsReserved2)
                 && (aWSComRslt1.AwsReserved3 == aWSComRslt2.AwsReserved3));
        }
        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AWSComRsltWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AWSComRsltWork target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UserSetDiscId != target.UserSetDiscId) resList.Add("UserSetDiscId");
            if (this.CheckDate != target.CheckDate) resList.Add("CheckDate");
            if (this.CheckTime != target.CheckTime) resList.Add("CheckTime");
            if (this.ComputerName != target.ComputerName) resList.Add("ComputerName");
            if (this.TestName != target.TestName) resList.Add("TestName");
            if (this.ServerType != target.ServerType) resList.Add("ServerType");
            if (this.TestType != target.TestType) resList.Add("TestType");
            if (this.TestObjAddr != target.TestObjAddr) resList.Add("TestObjAddr");
            if (this.CheckRslt != target.CheckRslt) resList.Add("CheckRslt");
            if (this.RequestStatusNo != target.RequestStatusNo) resList.Add("RequestStatusNo");
            if (this.RequestMessage != target.RequestMessage) resList.Add("RequestMessage");
            if (this.WindowsVersion != target.WindowsVersion) resList.Add("WindowsVersion");
            if (this.WindowsOSName != target.WindowsOSName) resList.Add("WindowsOSName");
            if (this.AwsReserved1 != target.AwsReserved1) resList.Add("AwsReserved1");
            if (this.AwsReserved2 != target.AwsReserved2) resList.Add("AwsReserved2");
            if (this.AwsReserved3 != target.AwsReserved3) resList.Add("AwsReserved3");

            return resList;
        }

        /// <summary>
        /// AWS�ʐM�e�X�g���ʃ��[�N��r����
        /// </summary>
        /// <param name="aWSComRslt1">��r����AWSComRsltWork�N���X�̃C���X�^���X</param>
        /// <param name="aWSComRslt2">��r����AWSComRsltWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AWSComRsltWork aWSComRslt1, AWSComRsltWork aWSComRslt2)
        {
            ArrayList resList = new ArrayList();
            if (aWSComRslt1.CreateDateTime != aWSComRslt2.CreateDateTime) resList.Add("CreateDateTime");
            if (aWSComRslt1.UpdateDateTime != aWSComRslt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (aWSComRslt1.EnterpriseCode != aWSComRslt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (aWSComRslt1.FileHeaderGuid != aWSComRslt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (aWSComRslt1.UpdEmployeeCode != aWSComRslt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (aWSComRslt1.UpdAssemblyId1 != aWSComRslt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (aWSComRslt1.UpdAssemblyId2 != aWSComRslt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (aWSComRslt1.LogicalDeleteCode != aWSComRslt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (aWSComRslt1.SectionCode != aWSComRslt2.SectionCode) resList.Add("SectionCode");
            if (aWSComRslt1.UserSetDiscId != aWSComRslt2.UserSetDiscId) resList.Add("UserSetDiscId");
            if (aWSComRslt1.CheckDate != aWSComRslt2.CheckDate) resList.Add("CheckDate");
            if (aWSComRslt1.CheckTime != aWSComRslt2.CheckTime) resList.Add("CheckTime");
            if (aWSComRslt1.ComputerName != aWSComRslt2.ComputerName) resList.Add("ComputerName");
            if (aWSComRslt1.TestName != aWSComRslt2.TestName) resList.Add("TestName");
            if (aWSComRslt1.ServerType != aWSComRslt2.ServerType) resList.Add("ServerType");
            if (aWSComRslt1.TestType != aWSComRslt2.TestType) resList.Add("TestType");
            if (aWSComRslt1.TestObjAddr != aWSComRslt2.TestObjAddr) resList.Add("TestObjAddr");
            if (aWSComRslt1.CheckRslt != aWSComRslt2.CheckRslt) resList.Add("CheckRslt");
            if (aWSComRslt1.RequestStatusNo != aWSComRslt2.RequestStatusNo) resList.Add("RequestStatusNo");
            if (aWSComRslt1.RequestMessage != aWSComRslt2.RequestMessage) resList.Add("RequestMessage");
            if (aWSComRslt1.WindowsVersion != aWSComRslt2.WindowsVersion) resList.Add("WindowsVersion");
            if (aWSComRslt1.WindowsOSName != aWSComRslt2.WindowsOSName) resList.Add("WindowsOSName");
            if (aWSComRslt1.AwsReserved1 != aWSComRslt2.AwsReserved1) resList.Add("AwsReserved1");
            if (aWSComRslt1.AwsReserved2 != aWSComRslt2.AwsReserved2) resList.Add("AwsReserved2");
            if (aWSComRslt1.AwsReserved3 != aWSComRslt2.AwsReserved3) resList.Add("AwsReserved3");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AWSComRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AWSComRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AWSComRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AWSComRsltWork || graph is ArrayList || graph is AWSComRsltWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AWSComRsltWork).FullName));

            if (graph != null && graph is AWSComRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AWSComRsltWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AWSComRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AWSComRsltWork[])graph).Length;
            }
            else if (graph is AWSComRsltWork)
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
            //���[�U�[�ݒ莯��ID
            serInfo.MemberInfo.Add(typeof(string)); //UserSetDiscId
            //�`�F�b�N���t
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckDate
            //�`�F�b�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckTime
            //�R���s���[�^����
            serInfo.MemberInfo.Add(typeof(string)); //ComputerName
            //�e�X�g����
            serInfo.MemberInfo.Add(typeof(string)); //TestName
            //�T�[�o�[�^�C�v
            serInfo.MemberInfo.Add(typeof(Int16)); //ServerType
            //�e�X�g�^�C�v
            serInfo.MemberInfo.Add(typeof(Int16)); //TestType
            //�e�X�g�ΏۃA�h���X
            serInfo.MemberInfo.Add(typeof(string)); //TestObjAddr
            //�`�F�b�N����
            serInfo.MemberInfo.Add(typeof(Int16)); //CheckRslt
            //���N�G�X�g�X�e�[�^�XNo
            serInfo.MemberInfo.Add(typeof(Int32)); //RequestStatusNo
            //���N�G�X�g���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //RequestMessage
            //Windows�o�[�W����
            serInfo.MemberInfo.Add(typeof(string)); //WindowsVersion
            //WindowsOS��
            serInfo.MemberInfo.Add(typeof(string)); //WindowsOSName
            //�\�����ڂP
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved1
            //�\�����ڂQ
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved2
            //�\�����ڂR
            serInfo.MemberInfo.Add(typeof(string)); //AwsReserved3


            serInfo.Serialize(writer, serInfo);
            if (graph is AWSComRsltWork)
            {
                AWSComRsltWork temp = (AWSComRsltWork)graph;

                SetAWSComRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AWSComRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AWSComRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AWSComRsltWork temp in lst)
                {
                    SetAWSComRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AWSComRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  AWSComRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAWSComRsltWork(System.IO.BinaryWriter writer, AWSComRsltWork temp)
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
            //���[�U�[�ݒ莯��ID
            writer.Write(temp.UserSetDiscId);
            //�`�F�b�N���t
            writer.Write(temp.CheckDate);
            //�`�F�b�N����
            writer.Write(temp.CheckTime);
            //�R���s���[�^����
            writer.Write(temp.ComputerName);
            //�e�X�g����
            writer.Write(temp.TestName);
            //�T�[�o�[�^�C�v
            writer.Write(temp.ServerType);
            //�e�X�g�^�C�v
            writer.Write(temp.TestType);
            //�e�X�g�ΏۃA�h���X
            writer.Write(temp.TestObjAddr);
            //�`�F�b�N����
            writer.Write(temp.CheckRslt);
            //���N�G�X�g�X�e�[�^�XNo
            writer.Write(temp.RequestStatusNo);
            //���N�G�X�g���b�Z�[�W
            writer.Write(temp.RequestMessage);
            //Windows�o�[�W����
            writer.Write(temp.WindowsVersion);
            //WindowsOS��
            writer.Write(temp.WindowsOSName);
            //�\�����ڂP
            writer.Write(temp.AwsReserved1);
            //�\�����ڂQ
            writer.Write(temp.AwsReserved2);
            //�\�����ڂR
            writer.Write(temp.AwsReserved3);

        }

        /// <summary>
        ///  AWSComRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AWSComRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AWSComRsltWork GetAWSComRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AWSComRsltWork temp = new AWSComRsltWork();

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
            //���[�U�[�ݒ莯��ID
            temp.UserSetDiscId = reader.ReadString();
            //�`�F�b�N���t
            temp.CheckDate = reader.ReadInt32();
            //�`�F�b�N����
            temp.CheckTime = reader.ReadInt32();
            //�R���s���[�^����
            temp.ComputerName = reader.ReadString();
            //�e�X�g����
            temp.TestName = reader.ReadString();
            //�T�[�o�[�^�C�v
            temp.ServerType = reader.ReadInt16();
            //�e�X�g�^�C�v
            temp.TestType = reader.ReadInt16();
            //�e�X�g�ΏۃA�h���X
            temp.TestObjAddr = reader.ReadString();
            //�`�F�b�N����
            temp.CheckRslt = reader.ReadInt16();
            //���N�G�X�g�X�e�[�^�XNo
            temp.RequestStatusNo = reader.ReadInt32();
            //���N�G�X�g���b�Z�[�W
            temp.RequestMessage = reader.ReadString();
            //Windows�o�[�W����
            temp.WindowsVersion = reader.ReadString();
            //WindowsOS��
            temp.WindowsOSName = reader.ReadString();
            //�\�����ڂP
            temp.AwsReserved1 = reader.ReadString();
            //�\�����ڂQ
            temp.AwsReserved2 = reader.ReadString();
            //�\�����ڂR
            temp.AwsReserved3 = reader.ReadString();


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
        /// <returns>AWSComRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AWSComRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AWSComRsltWork temp = GetAWSComRsltWork(reader, serInfo);
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
                    retValue = (AWSComRsltWork[])lst.ToArray(typeof(AWSComRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

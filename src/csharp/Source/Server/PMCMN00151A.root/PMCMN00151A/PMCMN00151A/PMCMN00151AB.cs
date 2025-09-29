//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������
// �v���O�����T�v   : �������A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15   �C�����e : �d�a�d�΍�
//----------------------------------------------------------------------------//
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ݒ�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>Note		: �e�������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvAcsParam
    {
        #region �� Private Members

        #endregion �� Private Members

        #region �񋓑�

        /// <summary>
        /// �������̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�擾���Ȃ�</summary>
            None = 1
          , /// <summary>�擾�ł��Ȃ�</summary>
            NotFound = 4
          , /// <summary>Error</summary>
            Error = 9
          , /// <summary>�F�؎擾����O�G���[</summary>
            Error1001 = 1001
          , /// <summary>ExError</summary>
            ExError = 2000
          , /// <summary>PC���擾����O�G���[</summary>
            GetMachineNameExError = 5000
          , /// <summary>�V�X�e���`�ԗ�O�G���[</summary>
            GetSystemFormExError = 5010
          , /// <summary>CPU�g�p���擾��O�G���[</summary>
            GetCpuUsageExError = 5020
          , /// <summary>�������g�p��/�e�ʎ擾��O�G���[</summary>
            GetMemUsageCapExError = 5030
          , /// <summary>�f�B�X�N�g�p��/�e�ʎ擾��O�G���[</summary>
            GetDiskUsageCapExError = 5040
          , /// <summary>�S�̃o�b�N�A�b�v�擾��O�G���[</summary>
            GetFullBackupExError = 5040
          , /// <summary>�}�X�^�����擾��O�G���[</summary>
            GetMstCountExError = 5040
          , /// <summary>CLC���O�o�͗�O�G���[</summary>
            ClcLogOutputExError = 6000
          , /// <summary>�p�����[�^�G���[</summary>
            ParamErr = 8000
        };

        /// <summary>
        /// �������̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum GetInfo
        {
            /// <summary>�擾����</summary>
            ON = 0
          , /// <summary>�擾���Ȃ�</summary>
            OFF = 1
        };

        /// <summary>
        /// ���ݏ��񋓑�
        /// </summary>
        public enum GetExistInfo
        {
            /// <summary>���݂���</summary>
            Exist = 0
          , /// <summary>���݂��Ȃ�</summary>
            NotExist = 1
        };

        #endregion //�񋓑�

        #region �萔

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00151A_Setting.xml";

        /// <summary>
        /// ���g���C��
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 5000;

        /// <summary>
        /// PC�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_MACHINE_NAME_INFO = 0;

        /// <summary>
        /// �V�X�e���`�Ԃ��擾�i�X�^���h�A�����AC/S�j�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_SYSTEM_FORM_INFO = 0;

        /// <summary>
        /// CPU�g�p�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_CPU_USAGE_INFO = 0;

        /// <summary>
        /// �������g�p��/�e�ʂ��擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_MEM_USAGE_INFO = 0;

        /// <summary>
        /// �f�B�X�N�g�p��/�e�ʂ��擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_DISK_USAGE_INFO = 0;

        /// <summary>
        /// �S�̃o�b�N�A�b�v�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_FULL_BACKUP_INFO = 0;

        /// <summary>
        /// ���i�}�X�^�̌������擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private const int GET_TABLE_CNT_INFO = 0;


        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        public const int GET_CLC_LOG_OUTPUT_INFO = 0;

        /// <summary>
        /// NA
        /// </summary>
        public const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// EXNA
        /// </summary>
        public const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// PC�i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// �V�X�e���`�� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_SYSFORM = "{0},";

        /// <summary>
        /// �X�^���h�A����
        /// </summary>
        public const string LOGOUTPUT_SA = "SA";

        /// <summary>
        /// C/S
        /// </summary>
        public const string LOGOUTPUT_CS = "CS";

        /// <summary>
        /// �I�v�V���� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_OPT = "{0},";

        /// <summary>
        /// �I�v�V���� �ݒ肠��
        /// </summary>
        public const string LOGOUTPUT_ON = "ON";

        /// <summary>
        /// �I�v�V���� �ݒ�Ȃ�
        /// </summary>
        public const string LOGOUTPUT_OFF = "OFF";

        /// <summary>
        /// CPU�g�p�� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_CPU = "CPU(%)={0},";

        /// <summary>
        /// �������g�p��/�e�� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// �f�B�X�N�g�p��/�e�� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0},";

        /// <summary>
        /// �S�̃o�b�N�A�b�v �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_FULLBACKUP = "{0}={1},{2},{3},{4},{5},{6},{7},";

        /// <summary>
        /// �S�̃o�b�N�A�b�v�G���[�� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_FULLBACKUP_ERR = "DB={0},";

        /// <summary>
        /// �}�X�^���� �i���O�o�́j
        /// </summary>
        public const string LOGOUTPUT_INFO_MSTCNT = "{0}={1},";

        /// <summary>
        /// �}�X�^
        /// </summary>
        public const string LOGOUTPUT_MST = "MST";

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// ���g���C��
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// ���g���C�Ԋu
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// PC�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _machineNameInfo;

        /// <summary>
        /// �V�X�e���`�Ԃ��擾�i�X�^���h�A�����AC/S�j�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _systemFormInfo;

        /// <summary>
        /// CPU�g�p�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _cpuUsageInfo;

        /// <summary>
        /// �������g�p��/�e�ʂ��擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _memUsageInfo;

        /// <summary>
        /// �f�B�X�N�g�p��/�e�ʂ��擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _diskUsageInfo;

        /// <summary>
        /// �S�̃o�b�N�A�b�v�����擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _fullBackupInfo;

        /// <summary>
        /// ���i�}�X�^�̌������擾�i0�F�擾����A1�F�擾���Ȃ��j
        /// </summary>
        private int _tableCntInfo;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private int _clcLogOutputInfo;

        // EnvSurvCommn
        private EnvSurvCommn esc = null;

        #endregion //�v���C�x�[�g�t�B�[���h


        # region �� Constructor

        /// <summary>
        /// �e�������A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�������A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvAcsParam()
        {
            try
            {
                // EnvSurvCommn
                esc = new EnvSurvCommn();

                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _retryCount = RETRY_COUNT_DEFAULT;                     // ���g���C��
                _retryInterval = RETRY_INTERVAL_DEFAULT;               // ���g���C�Ԋu(�b)
                _machineNameInfo = GET_MACHINE_NAME_INFO;              // PC�����擾
                _systemFormInfo = GET_SYSTEM_FORM_INFO;                // �V�X�e���`�Ԃ��擾
                _cpuUsageInfo = GET_CPU_USAGE_INFO;                    // CPU�g�p�����擾
                _memUsageInfo = GET_MEM_USAGE_INFO;                    // �������g�p��/�e�ʂ��擾
                _diskUsageInfo = GET_DISK_USAGE_INFO;                  // �f�B�X�N�g�p��/�e�ʂ��擾
                _fullBackupInfo = GET_FULL_BACKUP_INFO;                // �S�̃o�b�N�A�b�v�����擾
                _tableCntInfo = GET_TABLE_CNT_INFO;                    // �����擾�Ώۃe�[�u���̌������擾
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;           // CLC�T�[�o�Ƀ��O�o��

                string fileName = this.InitializeXmlSettings();

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    try
                    {
                        using (XmlReader reader = XmlReader.Create(fileName, settings))
                        {
                            while (reader.Read())
                            {
                                if (reader.IsStartElement("RetryCount")) _retryCount = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("RetryInterval")) _retryInterval = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetMachineNameInfo")) _machineNameInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetSystemFormInfo")) _systemFormInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetCpuUsageInfo")) _cpuUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetMemUsageInfo")) _memUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetDiskUsageInfo")) _diskUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetFullBackupInfo")) _fullBackupInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetTableCntInfo")) _tableCntInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        //���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB EnvSurvAcsParam Exception", ex.Message));
                    }
                }
                #endregion // �^�C���A�E�g


            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
            }
        }

        # endregion �� Constructor

        #region �� Public Methods

        #region �v���p�e�B

        /// <summary>
        /// ���g���C��
        /// </summary>
        public int RetryCount
        {
            get { return _retryCount; }
            set { _retryCount = value; }
        }

        /// <summary>
        /// ���g���C�Ԋu(�b)
        /// </summary>
        public int RetryInterval
        {
            get { return _retryInterval; }
            set { _retryInterval = value; }
        }

        /// <summary>
        /// PC�����擾
        /// </summary>
        public int MachineNameInfo
        {
            get { return _machineNameInfo; }
            set { _machineNameInfo = value; }
        }

        /// <summary>
        ///�V�X�e���`�Ԃ��擾
        /// </summary>
        public int SystemFormInfo
        {
            get { return _systemFormInfo; }
            set { _systemFormInfo = value; }
        }

        /// <summary>
        /// CPU�g�p�����擾
        /// </summary>
        public int CpuUsageInfo
        {
            get { return _cpuUsageInfo; }
            set { _cpuUsageInfo = value; }
        }

        /// <summary>
        /// �������g�p��/�e�ʂ��擾
        /// </summary>
        public int MemUsageInfo
        {
            get { return _memUsageInfo; }
            set { _memUsageInfo = value; }
        }

        /// <summary>
        /// �f�B�X�N�g�p��/�e�ʂ��擾
        /// </summary>
        public int DiskUsageInfo
        {
            get { return _diskUsageInfo; }
            set { _diskUsageInfo = value; }
        }

        /// <summary>
        /// �S�̃o�b�N�A�b�v�����擾
        /// </summary>
        public int FullBackupInfo
        {
            get { return _fullBackupInfo; }
            set { _fullBackupInfo = value; }
        }

        /// <summary>
        /// ���i�}�X�^�̌������擾
        /// </summary>
        public int TableCntInfo
        {
            get { return _tableCntInfo; }
            set { _tableCntInfo = value; }
        }

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o��
        /// </summary>
        public int ClcLogOutputInfo
        {
            get { return _clcLogOutputInfo; }
            set { _clcLogOutputInfo = value; }
        }

        #endregion  // �v���p�e�B

        #endregion // �� Public Methods

        #region �� Private Methods

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C���ݒ���擾����
        /// �t�@�C�������݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch(Exception ex)
            {
                //���O�o��
                esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB InitializeXmlSettings Exception", ex.Message));
            }

            return path;
        }
        #endregion  //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�̃p�X�擾
        /// �t�H���_�����݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = esc.GetRegistryKeyUserAP();

                if (keyForUSERAP == null)
                {
                    // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g��
                    // �^�p�゠�肦�Ȃ��P�[�X
                    homeDir = defaultDir;
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch(Exception ex)
            {
                //���O�o��
                esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // �J�����g�t�H���_


        #endregion // �� Private Methods
    }
}

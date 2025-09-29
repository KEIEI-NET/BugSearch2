//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�b�N�A�b�v�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�b�N�A�b�v���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ����
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00 �쐬�S�� : ����
// �C �� ��  2021/09/09  �C�����e : ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�vConvObjSingleBkDBParam
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�vConvObjSingleBkDBParam</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkDBParam
    {
        #region �񋓑�

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�����i�R���o�[�g�Ȃ��j</summary>
            NormalNotFound = 4
          , /// <summary>Error</summary>
            Error = 9
          , /// <summary>�o�b�N�A�b�v�����J�n</summary>
            BkStart = 1000

          , /// <summary>���i�}�X�^�擾</summary>
            MstGet = 2000
          , /// <summary>DataTable�쐬</summary>
            DataTableCreate = 2001
          , /// <summary>���i�}�X�^�擾SQL��O�G���[(2008)</summary>
            MstGetSqlExError = 2008
          , /// <summary>���i�}�X�^�擾��O�G���[(2009)</summary>
            MstGetExError = 2009
          , /// <summary>DataTable�W�J</summary>
            DataTableDeploy = 2010
          , /// <summary>DataTable�o�b�N�A�b�v</summary>
            DataTableBackup = 2020
          , /// <summary>DataTable�o�b�N�A�b�v�G���[(2027)</summary>
            DataTableBackupError2027 = 2027
          , /// <summary>DataTable�o�b�N�A�b�v��O�G���[(2028)</summary>
            DataTableBackupError2028 = 2028
          , /// <summary>DataTable�o�b�N�A�b�v�G���[(2029)</summary>
            DataTableBackupExError = 2029
          , /// <summary>�o�b�N�A�b�v�����C���X�^���X����</summary>
            ConvObjBackupCreate = 2080
          , /// <summary>�o�b�N�A�b�v���k</summary>
            ConvObjBackupZipEntry = 2082
          , /// <summary>�o�b�N�A�b�v�C���X�^���X�����O�G���[</summary>
            ConvObjBackupZipEntryExError = 2083
          , /// <summary>�o�b�N�A�b�v���o�^</summary>
            BkInfoEnt = 2100
          , /// <summary>�o�b�N�A�b�v���o�^�G���[</summary>
            BkInfoEntError = 2101
          , /// <summary>�o�b�N�A�b�v���o�^�p�����[�^�G���[(2107)</summary>
            BkInfoEntParamError = 2107
          , /// <summary>�o�b�N�A�b�v���o�^SQL��O�G���[(2108)</summary>
            BkInfoEntSqlExError = 2108
          , /// <summary>�o�b�N�A�b�v���o�^��O�G���[(2109)</summary>
            BkInfoEntExError = 2109
          , /// <summary>�o�b�N�A�b�v��ƃf�B���N�g���擾</summary>
            BkGetDirectory = 2300
          , /// <summary>�o�b�N�A�b�v�f�[�^������ϊ�</summary>
            BkConvStr = 2301
          , /// <summary>�o�b�N�A�b�v�f�[�^�Í���</summary>
            BkEncrypt = 2302
          , /// <summary>�o�b�N�A�b�v�t�@�C������</summary>
            BkStream = 2303
          , /// <summary>�o�b�N�A�b�v�f�[�^�G���g���}��(2304)</summary>
            BkEntryPut = 2304
          , /// <summary>�o�b�N�A�b�v�f�[�^��������</summary>
            BkWrite = 2305
          , /// <summary>�o�b�N�A�b�v�f�[�^���k���t�@�C���폜(2306)</summary>
            BkSourceDel = 2306

          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�f�[�^�x�[�X�ڑ��G���[(3001)</summary>
            COAUPError3001 = 3001
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�g�����U�N�V�����J�n�G���[(3002)</summary>
            COAUPError3002 = 3002
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�A�v���P�[�V�������b�N�@���\�[�X���擾�G���[(3003)</summary>
            COAUPError3003 = 3003
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�A�v���P�[�V�������b�N�G���[(3004)</summary>
            COAUPError3004 = 3004
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�o�b�N�A�b�v���擾�G���[(3005)</summary>
            COAUPError3005 = 3005
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�o�b�N�A�b�v����擾(3006)</summary>
            COAUPError3006 = 3006
          , /// <summary>�R���o�[�g�Ώۃo�b�N�A�b�v�@�A�v���P�[�V�������b�N�����[�X�G���[(3008)</summary>
            COAUPError3008 = 3008

          , /// <summary>AWS�A�b�v���[�h(4001)</summary>
            AWSUpload = 4001
          , /// <summary>AWS�A�b�v���[�h��O�G���[(4009)</summary>
            AWSUploadExError = 4001

          , /// <summary>���o�b�N�A�b�v�폜��O�G���[(4109)</summary>
            OldBkDeleteExError = 4109
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^�擾�G���[(4111)</summary>
            OldBkDeleteGetConvObjBkMngError = 4111
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^�擾SQL�G���[(4118)</summary>
            OldBkDeleteGetConvObjBkMngSqlError = 4118
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^�擾��O�G���[(4119)</summary>
            OldBkDeleteGetConvObjBkMngExError = 4119
          , /// <summary>���o�b�N�A�b�v�폜 AWS�t�@�C���폜�G���[(4121)</summary>
            OldBkDeleteAWSDeleteError = 4121
          , /// <summary>���o�b�N�A�b�v�폜 AWS�t�@�C����O�G���[(4129)</summary>
            OldBkDeleteAWSDeleteExError = 4129
          , /// <summary>���o�b�N�A�b�v�폜 ���[�J���t�@�C���폜�G���[(4131)</summary>
            OldBkDeleteLocalDeleteError = 4131
          , /// <summary>���o�b�N�A�b�v�폜 ���[�J���t�@�C����O�G���[(4139)</summary>
            OldBkDeleteLocalDeleteExError = 4139
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^�폜�G���[(4131)</summary>
            OldBkDeleteUpdConvObjBkMngError = 4141
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^SQL��O�G���[(4139)</summary>
            OldBkDeleteUpdConvObjBkMngSqlExError = 4149
          , /// <summary>���o�b�N�A�b�v�폜 �R���o�[�g�ΏۊǗ��}�X�^��O�G���[(4139)</summary>
            OldBkDeleteUpdConvObjBkMngExError = 4149
          // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
          , /// <summary>���o�b�N�A�b�v�폜 ���[�J���o�b�N�A�b�v�t�@�C���p�X�擾��O�G���[(4159)</summary>
            OldBkDeleteGetLocalFilesExError = 4159
          // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

          , /// <summary>�f�[�^�x�[�X�ڑ��G���[(5001)</summary>
            GetDataBaseConnectError = 5001
          , /// <summary>�f�[�^�x�[�X�ڑ���O�G���[(5009)</summary>
            GetDataBaseConnectExError = 5009
          , /// <summary>�f�[�^�x�[�X�ڑ��G���[(5101)</summary>
            AWSGetDataBaseConnectError = 5101
          , /// <summary>�f�[�^�x�[�X�ڑ���O�G���[(5109)</summary>
            AWSGetDataBaseConnectExError = 5109
          , /// <summary>�g�����U�N�V�����J�n�G���[(6001)</summary>
            GetDataBaseTransactionError = 6001
          , /// <summary>�g�����U�N�V�����J�n��O�G���[(6009)</summary>
            GetDataBaseTransactionExError = 6009
          , /// <summary>�o�b�N�A�b�v���`�F�b�N�G���[(7001)</summary>
            EnvBackupInfError = 7001
          , /// <summary>�o�b�N�A�b�v�擾�ς�(7002)</summary>
            EnvBackupExists = 7002
          , /// <summary>�o�b�N�A�b�vSQL��O�G���[(7008)</summary>
            EnvBackupInfSqlExError = 7008
          , /// <summary>�o�b�N�A�b�v��O�G���[(7009)</summary>
            EnvBackupInfExError = 7009
          , /// <summary>�o�b�N�A�b�v���擾�G���[(7101)</summary>
            EnvBackupInfGetError = 7101
          , /// <summary>�o�b�N�A�b�v���擾SQL��O�G���[(7108)</summary>
            EnvBackupInfGetSqlExError = 7108
          , /// <summary>�o�b�N�A�b�v���擾��O�G���[(7109)</summary>
            EnvBackupInfGetExError = 7109
          , /// <summary>�R���o�[�g�ΏۃG���[(8001)</summary>
            VerObjMstBkProcError = 8001
          , /// <summary>DB�A�v���P�[�V�������b�N�G���[(9001)</summary>
            GetApplicationLockError = 9001
          , /// <summary>DB�A�v���P�[�V�������b�N�^�C���A�E�g�G���[(9004)</summary>
            GetApplicationLockTimeout = 9004
          , /// <summary>DB�A�v���P�[�V�������b�N��O�G���[(9009)</summary>
            GetApplicationLockExError = 9009
        };

        /// <summary>
        /// ����i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        public enum CheckObjCode
        {
            /// <summary>�`�F�b�N����</summary>
            ON = 0
          , /// <summary>�`�F�b�N���Ȃ�</summary>
            OFF = 1
        };

        /// <summary>
        /// �o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        public enum OutputCode
        {
            /// <summary>�o�͂���</summary>
            ON = 0
          , /// <summary>�o�͂��Ȃ�</summary>
            OFF = 1
        };

        #endregion //�񋓑�

        #region �萔

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00163R_Setting.xml";

        /// <summary>
        /// ���g���C��
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)�@10000�~���b�E�E�E�@10�b
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 10000;

        /// <summary>
        /// �o�b�N�A�b�v����
        /// </summary>
        private const int BK_GENERATION = 3;

        /// <summary>
        /// DB�R�}���h�^�C���A�E�g�i�b�j�@1800�b�E�E�E30��
        /// </summary>
        private const int DB_COMMAND_TIMEOUT = 1800;

        /// <summary>
        /// �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j 1800000�~���b�E�E�E30��
        /// </summary>
        private const int APPLICATION_LOCK_TIMEOUT = 1800000;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private const int GET_CLC_LOG_OUTPUT_INFO = 1;

        /// <summary>
        ///  WebRequest Access Check�i0�F����A1�F���Ȃ��j
        /// </summary>
        private const int GET_WEB_ACCESS_CHECK_CONTROL = 0;

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// ���g���C��
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// �o�b�N�A�b�v����
        /// </summary>
        private int _bkGeneration;

        /// <summary>
        /// DB�R�}���h�^�C���A�E�g�i�b�j
        /// </summary>
        private int _dbCommandTimeout;

        /// <summary>
        /// �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j
        /// </summary>
        private int _dbApplicationLockTimeout;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// WebRequest Access Check�i0�F����A1�F���Ȃ��j
        /// </summary>
        private int _webAccessCheckControl;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�p�����[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjSingleBkDBParam()
        {
            try
            {
                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _retryCount = RETRY_COUNT_DEFAULT;                                      // ���g���C��
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // ���g���C�Ԋu(�~���b)
                _bkGeneration = BK_GENERATION;                                          // �o�b�N�A�b�v����
                _dbCommandTimeout = DB_COMMAND_TIMEOUT;                                 // DB�R�}���h�^�C���A�E�g�i�b�j
                _dbApplicationLockTimeout = APPLICATION_LOCK_TIMEOUT;                   // �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLC�T�[�o�Ƀ��O�o��
                _webAccessCheckControl = GET_WEB_ACCESS_CHECK_CONTROL;                  // WebRequest Access Check

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
                                if (reader.IsStartElement("BkGeneration")) _bkGeneration = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbCommandTimeout")) _dbCommandTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbApplicationLockTimeout")) _dbApplicationLockTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebAccessCheckControl")) _webAccessCheckControl = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch
                    {
                        //���O�o��
                    }
                }
                #endregion // �ݒ�t�@�C���擾

            }
            catch
            {
                // �I�t���C������null���Z�b�g
            }
        }

        #endregion //�R���X�g���N�^

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
        /// �o�b�N�A�b�v����
        /// </summary>
        public int BkGeneration
        {
            get { return _bkGeneration; }
            set { _bkGeneration = value; }
        }

        /// <summary>
        /// DB�R�}���h�^�C���A�E�g�i�b�j
        /// </summary>
        public int DbCommandTimeout
        {
            get { return _dbCommandTimeout; }
            set { _dbCommandTimeout = value; }
        }

        /// <summary>
        /// �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j
        /// </summary>
        public int DbApplicationLockTimeout
        {
            get { return _dbApplicationLockTimeout; }
            set { _dbApplicationLockTimeout = value; }
        }

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o��
        /// </summary>
        public int ClcLogOutputInfo
        {
            get { return _clcLogOutputInfo; }
            set { _clcLogOutputInfo = value; }
        }

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        public int WebAccessCheckControl
        {
            get { return _webAccessCheckControl; }
            set { _webAccessCheckControl = value; }
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
        /// <br>Programmer : ����</br>
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
            catch
            {
                //���O�o��
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
        /// <br>Programmer : ����</br>
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
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
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
            catch
            {
                //���O�o��
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

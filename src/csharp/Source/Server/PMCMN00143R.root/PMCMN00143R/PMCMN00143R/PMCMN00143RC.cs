//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�VConvObjDBParam
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�VConvObjDBParam</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjDBParam
    {
        #region �񋓑�

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�����i�R���o�[�g�Ȃ��j</summary>
            NormalNotFound = 4
          , /// <summary>Error</summary>
            Error = 9
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
          , /// <summary>DataTable�ϊ�</summary>
            DataTableConv = 2030
          , /// <summary>�ꎞ�e�[�u���쐬</summary>
            TempTableCreate = 2040
          , /// <summary>�ꎞ�e�[�u���쐬SQL��O�G���[(2048)</summary>
            TempTableCreateSqlExError = 2048
          , /// <summary>�ꎞ�e�[�u���o�^</summary>
            TempTableIns = 2050
          , /// <summary>�ꎞ�e�[�u���o�^SQL��O�G���[(2051)</summary>
            TempTableInsSqlExError = 2051
          , /// <summary>�ꎞ�e�[�u���ŏI�o�^</summary>
            TempTableLastIns = 2052
          , /// <summary>�ꎞ�e�[�u���ŏI�o�^SQL��O�G���[(2053)</summary>
            TempTableLastInsSqlExError = 2053
          , /// <summary>�}�X�^�X�V</summary>
            MstUpd = 2060
          , /// <summary>�}�X�^�X�VSQL��O�G���[(2068)</summary>
            MstUpdSqlExError = 2068
          , /// <summary>�}�X�^�X�V��O�G���[(2069)</summary>
            MstUpdExError = 2069
          , /// <summary>�ꎞ�e�[�u���폜</summary>
            TempTableDelete = 2070
          , /// <summary>�ꎞ�e�[�u���폜SQL��O�G���[</summary>
            TempTableDeleteSqlExError = 2078
          , /// <summary>�o�b�N�A�b�v�����C���X�^���X����</summary>
            ConvObjBackupCreate = 2080
          , /// <summary>�o�b�N�A�b�v�����C���X�^���X������O�G���[</summary>
            ConvObjBackupCreateExError = 2081
          , /// <summary>�o�b�N�A�b�v�C���X�^���X���</summary>
            ConvObjBackupDispose = 2082
          , /// <summary>�o�b�N�A�b�v�C���X�^���X�����O�G���[</summary>
            ConvObjBackupDisposeExError = 2083
          , /// <summary>�o�[�W�����Ǘ��}�X�^�X�V</summary>
            VerObjVerMstUpd = 2100
          , /// <summary>�o�[�W�����Ǘ��}�X�^�X�VSQL��O�G���[(2108)</summary>
            VerObjVerMstUpdSqlExError = 2108
          , /// <summary>XACT_ABORT ON</summary>
            XactAbortOn = 2150
          , /// <summary>���i�}�X�^�����擾</summary>
            MstCntGet = 2200
          , /// <summary>���i�}�X�^�����擾SQL��O�G���[(2008)</summary>
            MstCntGetSqlExError = 2208
          , /// <summary>���i�}�X�^�����擾��O�G���[(2009)</summary>
            MstCntGetExError = 2209
          , /// <summary>�P��o�b�N�A�b�v��ƃf�B���N�g���擾</summary>
            BkGetDirectory = 2300
          , /// <summary>�o�b�N�A�b�v�f�[�^������ϊ�</summary>
            BkConvStr = 2301
          , /// <summary>�o�b�N�A�b�v�f�[�^�Í���</summary>
            BkEncrypt = 2302
          , /// <summary>�o�b�N�A�b�v�t�@�C������</summary>
            BkStream = 2303
          , /// <summary>�o�b�N�A�b�v�f�[�^�G���g���}��(2310)</summary>
            BkEntryPut = 2304
          , /// <summary>�o�b�N�A�b�v�f�[�^��������</summary>
            BkWrite = 2305

          , /// <summary>�R���o�[�g�Ώێ����X�V�@�f�[�^�x�[�X�ڑ��G���[(3001)</summary>
            COAUPError3001 = 3001
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�g�����U�N�V�����J�n�G���[(3002)</summary>
            COAUPError3002 = 3002
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�A�v���P�[�V�������b�N�@���\�[�X���擾�G���[(3003)</summary>
            COAUPError3003 = 3003
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�A�v���P�[�V�������b�N�G���[(3004)</summary>
            COAUPError3004 = 3004
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�S�̃o�b�N�A�b�v�͈͊O�i�Â��j(3005)</summary>
            COAUPError3005 = 3005
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�S�̃o�b�N�A�b�v����Ă��Ȃ�(3006)</summary>
            COAUPError3006 = 3006
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�S�̃o�b�N�A�b�v���擾�G���[(3007)</summary>
            COAUPError3007 = 3007
          , /// <summary>�R���o�[�g�Ώێ����X�V�@�A�v���P�[�V�������b�N�����[�X�G���[(3008)</summary>
            COAUPError3008 = 3008

          , /// <summary>�f�[�^�x�[�X�ڑ��G���[(5001)</summary>
            GetDataBaseConnectError = 5001
          , /// <summary>�f�[�^�x�[�X�ڑ���O�G���[(5009)</summary>
            GetDataBaseConnectExError = 5009
          , /// <summary>�g�����U�N�V�����J�n�G���[(6001)</summary>
            GetDataBaseTransactionError = 6001
          , /// <summary>�g�����U�N�V�����J�n��O�G���[(6009)</summary>
            GetDataBaseTransactionExError = 6009
          , /// <summary>�S�̃o�b�N�A�b�v�G���[(7001)</summary>
            EnvFullBackupInfError = 7001
          , /// <summary>�S�̃o�b�N�A�b�v�͈͊O(7002)</summary>
            EnvFullBackupInfOutOfRange = 7002
          , /// <summary>�S�̃o�b�N�A�b�v�����{���f(7003)</summary>
            EnvFullBackupInfInterruption = 7003
          , /// <summary>�S�̃o�b�N�A�b�vSQL��O�G���[(7008)</summary>
            EnvFullBackupInfSqlExError = 7008
          , /// <summary>�S�̃o�b�N�A�b�v��O�G���[(7009)</summary>
            EnvFullBackupInfExError = 7009
          , /// <summary>�S�̃o�b�N�A�b�v�w���`�F�b�N�G���[(7010)</summary>
            EnvFullBackupInfPurchaseError = 7010
          , /// <summary>�S�̃o�b�N�A�b�v�w���`�F�b�N��O�G���[(7011)</summary>
            EnvFullBackupInfPurchaseExError = 7011
          , /// <summary>�R���o�[�g�ΏۃG���[(8001)</summary>
            VerObjMstUpdProcError = 8001
          , /// <summary>DB�A�v���P�[�V�������b�N�G���[(9001)</summary>
            GetApplicationLockError = 9001
          , /// <summary>DB�A�v���P�[�V�������b�N�^�C���A�E�g�G���[(9004)</summary>
            GetApplicationLockTimeout = 9004
          , /// <summary>DB�A�v���P�[�V�������b�N��O�G���[(9009)</summary>
            GetApplicationLockExError = 9009
        };

        /// <summary>
        /// �R���o�[�g�Ώۂ��ǂ����𔻒f�i0�F���f����A1�F���f���������I�ɐݒ肷��A2�F���f���������I�ɉ�������j
        /// </summary>
        public enum ConvObjCode
        {
            /// <summary>���f����</summary>
            Decide = 0
          , /// <summary>���f���������I�ɐݒ肷��</summary>
            ForceSetting = 1
          , /// <summary>���f���������I�ɉ�������</summary>
            ForceCancel = 2
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

        #region �萔��`

        /// <summary>
        /// �R���o�[�g�Ώ۔���@�R���o�[�g�Ώ�
        /// </summary>
        public const bool CONVOBJ_ON = true;

        /// <summary>
        /// �R���o�[�g�Ώ۔���@�R���o�[�g�ΏۊO
        /// </summary>
        public const bool CONVOBJ_OFF = false;

        /// <summary>
        /// DB��
        /// </summary>
        public const string PMUSERDBName = "PM_USER_DB";

        /// <summary>
        /// �o�b�N�A�b�v�̎��
        /// </summary>
        public const string PMUSERDBType = "D";


        #endregion //�萔��`

        #region �萔

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "�R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B";

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_Setting.xml";

        /// <summary>
        /// ���g���C��
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)�@10000�~���b�E�E�E�@10�b
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 10000;

        /// <summary>
        /// DB�R�}���h�^�C���A�E�g�i�b�j�@1800�b�E�E�E30��
        /// </summary>
        private const int DB_COMMAND_TIMEOUT = 1800;

        /// <summary>
        /// �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j 1800000�~���b�E�E�E30��
        /// </summary>
        private const int APPLICATION_LOCK_TIMEOUT = 1800000;

        /// <summary>
        /// �A�v���P�[�V�������b�N�E�����[�X�𐧌�i0�F���b�N�E�����[�X����A1�F���b�N�E�����[�X���Ȃ��j
        /// </summary>
        private const int APPLICATION_LOCK_RELEASE_CONTROL = 0;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_CONTROL = 0;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v����Ă��Ȃ��ꍇ�A�����𒆒f���邩����i0�F���f����A1�F���f���Ȃ��j
        /// </summary>
        private const int DB_FULL_BACKUP_SUSPENSION_CONTROL = 0;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈́i0�F��������A1�F�����Ȃ��j
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_RANGE_CONTROL = 0;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈͎��ԁi0�F���s���Ԃ��N�_��48���Ԉȓ��A999�F���s���Ԃ��N�_�Ɏw�莞�Ԉȓ��j�@�P�ʁF����
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_RANGE_TIME = 0;

        /// <summary>
        /// �R���o�[�g�Ώۂ��ǂ����𔻒f�i0�F���f����A1�F���f���������I�ɐݒ肷��A2�F���f���������I�ɉ�������j
        /// </summary>
        private const int CONVERSION_TARGET_CONTROL = 0;

        /// <summary>
        /// ���i�}�X�^�̃o�b�N�A�b�v�𐧌�i0�F�A�b�N�A�b�v����A1�F�o�b�N�A�b�v���Ȃ��j
        /// </summary>
        private const int MST_BACKUP_CONTROL = 0;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private const int GET_CLC_LOG_OUTPUT_INFO = 0;

        /// <summary>
        ///  WebRequest Access Check�i0�F����A1�F���Ȃ��j
        /// </summary>
        private const int GET_WEB_ACCESS_CHECK_CONTROL = 0;

        /// <summary>
        ///  ���i�}�X�^�X�V�P�ʌ����i�X�V�����j
        /// </summary>
        private const int MST_UPDATE_BREAK_COUNT = 100000;

        /// <summary>
        /// �����^�C�v�̃I�v�V�����`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        private const int SEARCH_TYPE_OPTION_CHECK_CONTROL = 0;

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
        /// DB�R�}���h�^�C���A�E�g�i�b�j
        /// </summary>
        private int _dbCommandTimeout;

        /// <summary>
        /// �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j
        /// </summary>
        private int _dbApplicationLockTimeout;

        /// <summary>
        /// �A�v���P�[�V�������b�N�E�����[�X�𐧌�i0�F���b�N�E�����[�X����A1�F���b�N�E�����[�X���Ȃ��j
        /// </summary>
        private int _applicationLockReleaseControl;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        private int _dbFullBackupCheckControl;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v����Ă��Ȃ��ꍇ�A�����𒆒f���邩����i0�F���f����A1�F���f���Ȃ��j
        /// </summary>
        private int _dbFullBackupSuspensionControl;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈́i0�F��������A1�F�����Ȃ��j
        /// </summary>
        private int _dbFullBackupCheckRangeControl;

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈͎��ԁi0�F���s���Ԃ��N�_��48���Ԉȓ��A999�F���s���Ԃ��N�_�Ɏw�莞�Ԉȓ��j�@�P�ʁF����
        /// </summary>
        private int _dbFullBackupCheckRangeTime;

        /// <summary>
        /// �R���o�[�g�Ώۂ��ǂ����𔻒f�i0�F���f����A1�F���f���������I�ɐݒ肷��A2�F���f���������I�ɉ�������j
        /// </summary>
        private int _conversionTargetControl;

        /// <summary>
        /// ���i�}�X�^�̃o�b�N�A�b�v�𐧌�i0�F�A�b�N�A�b�v����A1�F�o�b�N�A�b�v���Ȃ��j
        /// </summary>
        private int _mstBackupControl;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// WebRequest Access Check�i0�F����A1�F���Ȃ��j
        /// </summary>
        private int _webAccessCheckControl;

        /// <summary>
        /// ���i�}�X�^�X�V�P�ʌ����i�X�V�����j
        /// </summary>
        private int _mstUpdateBreakCount;

        /// <summary>
        /// �����^�C�v�̃I�v�V�����`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        private int _searchTypeOptionCheckControl;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�p�����[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDBParam()
        {
            try
            {
                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _retryCount = RETRY_COUNT_DEFAULT;                                      // ���g���C��
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // ���g���C�Ԋu(�~���b)
                _dbCommandTimeout = DB_COMMAND_TIMEOUT;                                 // DB�R�}���h�^�C���A�E�g�i�b�j
                _dbApplicationLockTimeout = APPLICATION_LOCK_TIMEOUT;                   // �A�v���P�[�V�������b�N�^�C���A�E�g�i�~���b�j
                _applicationLockReleaseControl = APPLICATION_LOCK_RELEASE_CONTROL;      // �A�v���P�[�V�������b�N�E�����[�X�𐧌�i0�F���b�N�E�����[�X����A1�F���b�N�E�����[�X���Ȃ��j
                _dbFullBackupCheckControl = DB_FULL_BACKUP_CHECK_CONTROL;               // DB�S�̃o�b�N�A�b�v�`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
                _dbFullBackupSuspensionControl = DB_FULL_BACKUP_SUSPENSION_CONTROL;     // DB�S�̃o�b�N�A�b�v����Ă��Ȃ��ꍇ�A�����𒆒f���邩����i0�F���f����A1�F���f���Ȃ��j
                _dbFullBackupCheckRangeControl = DB_FULL_BACKUP_CHECK_RANGE_CONTROL;    // DB�S�̃o�b�N�A�b�v�`�F�b�N�͈́i0�F��������A1�F�����Ȃ��j
                _dbFullBackupCheckRangeTime = DB_FULL_BACKUP_CHECK_RANGE_TIME;          // DB�S�̃o�b�N�A�b�v�`�F�b�N�͈͎��ԁi0�F���s���Ԃ��N�_��48���Ԉȓ��A999�F���s���Ԃ��N�_�Ɏw�莞�Ԉȓ��j�@�P�ʁF����
                _conversionTargetControl = CONVERSION_TARGET_CONTROL;                   // �R���o�[�g�Ώۂ��ǂ����𔻒f�i0�F���f����A1�F���f���������I�ɐݒ肷��A2�F���f���������I�ɉ�������j
                _mstBackupControl = MST_BACKUP_CONTROL;                                 // ���i�}�X�^�̃o�b�N�A�b�v�𐧌�i0�F�A�b�N�A�b�v����A1�F�o�b�N�A�b�v���Ȃ��j
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLC�T�[�o�Ƀ��O�o��
                _webAccessCheckControl = GET_WEB_ACCESS_CHECK_CONTROL;                  // WebRequest Access Check
                _mstUpdateBreakCount = MST_UPDATE_BREAK_COUNT;                          // ���i�}�X�^�X�V�P�ʌ����i�X�V�����j
                _searchTypeOptionCheckControl = SEARCH_TYPE_OPTION_CHECK_CONTROL;       // �����^�C�v�̃I�v�V�����`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j

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
                                if (reader.IsStartElement("DbCommandTimeout")) _dbCommandTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbApplicationLockTimeout")) _dbApplicationLockTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("ApplicationLockReleaseControl")) _applicationLockReleaseControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckControl")) _dbFullBackupCheckControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupSuspensionControl")) _dbFullBackupSuspensionControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckRangeControl")) _dbFullBackupCheckRangeControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckRangeTime")) _dbFullBackupCheckRangeTime = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("ConversionTargetControl")) _conversionTargetControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("MstBackupControl")) _mstBackupControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebAccessCheckControl")) _webAccessCheckControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("MstUpdateBreakCount")) _mstUpdateBreakCount = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("SearchTypeOptionCheckControl")) _searchTypeOptionCheckControl = reader.ReadElementContentAsInt();
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
        /// �A�v���P�[�V�������b�N�E�����[�X�𐧌�i0�F���b�N�E�����[�X����A1�F���b�N�E�����[�X���Ȃ��j
        /// </summary>
        public int ApplicationLockReleaseControl
        {
            get { return _applicationLockReleaseControl; }
            set { _applicationLockReleaseControl = value; }
        }

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        public int DbFullBackupCheckControl
        {
            get { return _dbFullBackupCheckControl; }
            set { _dbFullBackupCheckControl = value; }
        }

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v����Ă��Ȃ��ꍇ�A�����𒆒f���邩����i0�F���f����A1�F���f���Ȃ��j
        /// </summary>
        public int DbFullBackupSuspensionControl
        {
            get { return _dbFullBackupSuspensionControl; }
            set { _dbFullBackupSuspensionControl = value; }
        }

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈́i0�F��������A1�F�����Ȃ��j
        /// </summary>
        public int DbFullBackupCheckRangeControl
        {
            get { return _dbFullBackupCheckRangeControl; }
            set { _dbFullBackupCheckRangeControl = value; }
        }

        /// <summary>
        /// DB�S�̃o�b�N�A�b�v�`�F�b�N�͈͎��ԁi0�F���s���Ԃ��N�_��48���Ԉȓ��A999�F���s���Ԃ��N�_�Ɏw�莞�Ԉȓ��j�@�P�ʁF����
        /// </summary>
        public int DbFullBackupCheckRangeTime
        {
            get { return _dbFullBackupCheckRangeTime; }
            set { _dbFullBackupCheckRangeTime = value; }
        }

        /// <summary>
        /// �R���o�[�g�Ώۂ��ǂ����𔻒f�i0�F���f����A1�F���f���������I�ɐݒ肷��A2�F���f���������I�ɉ�������j
        /// </summary>
        public int ConversionTargetControl
        {
            get { return _conversionTargetControl; }
            set { _conversionTargetControl = value; }
        }

        /// <summary>
        /// ���i�}�X�^�̃o�b�N�A�b�v�𐧌�i0�F�A�b�N�A�b�v����A1�F�o�b�N�A�b�v���Ȃ��j
        /// </summary>
        public int MstBackupControl
        {
            get { return _mstBackupControl; }
            set { _mstBackupControl = value; }
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

        /// <summary>
        /// ���i�}�X�^�X�V�P�ʌ����i�X�V�����j
        /// </summary>
        public int MstUpdateBreakCount
        {
            get { return _mstUpdateBreakCount; }
            set { _mstUpdateBreakCount = value; }
        }

        /// <summary>
        /// �����^�C�v�̃I�v�V�����`�F�b�N�𐧌�i0�F�`�F�b�N����A1�F�`�F�b�N���Ȃ��j
        /// </summary>
        public int SearchTypeOptionCheckControl
        {
            get { return _searchTypeOptionCheckControl; }
            set { _searchTypeOptionCheckControl = value; }
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

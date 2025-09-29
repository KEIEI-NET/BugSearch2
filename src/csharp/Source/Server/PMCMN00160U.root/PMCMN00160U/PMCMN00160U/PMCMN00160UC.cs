//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����o�b�N�A�b�v
// �v���O�����T�v   : �R���o�[�g�Ώێ����o�b�N�A�b�v
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ����
// �� �� ��  2020/06/15   �C�����e : �d�a�d�΍�
//----------------------------------------------------------------------------//
using Broadleaf.Application.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ݒ�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>Note		: �R���o�[�g�Ώێ����o�b�N�A�b�v�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class ConvObjBkParam
    {

        #region �� Private Members

        /// <summary>
        /// ���W�X�g�L�[������iCLIENT�j
        /// </summary>
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";

        /// <summary>
        /// ���W�X�g�L�[������iUSER_AP�j
        /// </summary>
        private const string REG_KEY_USER_AP = @"Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// ���W�X�g�L�[������iKEY32�j
        /// </summary>
        private const string REG_KEY32 = @"SOFTWARE\";

        /// <summary>
        /// ���W�X�g�L�[������iKEY64�j ���擾�ł��Ȃ��ꍇ
        /// </summary>
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";

        #endregion // �� Private Members

        #region �񋓑�

        /// <summary>
        /// �R���o�[�g�Ώێ����o�b�N�A�b�v�̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�����i�R���o�[�g�Ȃ��j</summary>
            NormalNotFound = 4
          , /// <summary>�I�v�V��������</summary>
            OptPmSecurityMeasuresInvalid = -1
          , /// <summary>�v���I�G���[</summary>
            Error = -1000
          , /// <summary>�v���I�G���[(1001)</summary>
            Error1001 = -1001
          , /// <summary>�v���I�G���[(1002)</summary>
            Error1002 = -1002
          , /// <summary>�v���I�G���[(1003)</summary>
            Error1003 = -1003
          , /// <summary>�v���I�G���[(1004)</summary>
            Error1004 = -1004
          , /// <summary>�v���I�G���[(1005)</summary>
            Error1005 = -1005
          , /// <summary>�p�����[�^�s��(1009)</summary>
            ParamErr = -1009
          , /// <summary>�v���I�G���[(1010)</summary>
            Error1010 = -1010
          , /// <summary>�v���I�G���[(1011)</summary>
            Error1011 = -1011
          , /// <summary>�v���I�G���[(1012)</summary>
            Error1012 = -1012
          , /// <summary>�v���I�G���[(1013)</summary>
            Error1013 = -1013
        };

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        public enum CLCOutputCode
        {
            /// <summary>�o�͂���</summary>
            Enable = 0
          , /// <summary>�o�͂��Ȃ�</summary>
            Disable = 1
        };

        #endregion //�񋓑�

        #region �萔

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00160U_Setting.xml";

        /// <summary>
        /// ���g���C��
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 5000;

        /// <summary>
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        public const int GET_CLC_LOG_OUTPUT_INFO = 1;

        /// <summary>
        /// �o�b�N�A�b�v�쐬�҂�����(�~���b)
        /// </summary>
        public const int BK_CREATE_WAIT_DEFAULT = 60000;

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
        /// CLC�T�[�o�Ƀ��O�o�́i0�F�o�͂���A1�F�o�͂��Ȃ��j
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// �o�b�N�A�b�v�쐬�҂�����(�~���b)
        /// </summary>
        private int _bkCreateWait;

        /// <summary>
        /// ���O�o��
        /// </summary>
        private static LogInfoAllCls logInfoAllCls = null;

        #endregion //�v���C�x�[�g�t�B�[���h


        # region �� Constructor

        /// <summary>
        /// �ݒ�p�����[�^�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ݒ�p�����[�^�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public ConvObjBkParam()
        {
            try
            {
                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _retryCount = RETRY_COUNT_DEFAULT;                                      // ���g���C��
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // ���g���C�Ԋu(�b)
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLC�T�[�o�Ƀ��O�o��
                _bkCreateWait = BK_CREATE_WAIT_DEFAULT;                                 // �o�b�N�A�b�v�쐬�҂�����

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
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("BkCreateWait")) _bkCreateWait = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        if (_clcLogOutputInfo == (int)CLCOutputCode.Enable)
                        {
                            //���O�o��
                            logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC ConvObjBkParam Exception", ex.Message));
                        }
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
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        public int RetryInterval
        {
            get { return _retryInterval; }
            set { _retryInterval = value; }
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
        /// �o�b�N�A�b�v�쐬�҂�����(�~���b)
        /// </summary>
        public int BkCreateWait
        {
            get { return _bkCreateWait; }
            set { _bkCreateWait = value; }
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
            catch(Exception ex)
            {
                //���O�o��
                logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC InitializeXmlSettings Exception", ex.Message));
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
                RegistryKey keyForUSERAP = GetRegistryKeyUserAP();

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
                logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // �J�����g�t�H���_

        #region USER_AP���W�X�g���擾

        /// <summary>
        /// USER_AP���W�X�g���擾
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private RegistryKey GetRegistryKeyUserAP()
        {
            RegistryKey registryKey = null;

            try
            {
                // ���W�X�g�������USER_AP�̃L�[�����擾
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + REG_KEY_USER_AP);
                if (registryKey == null)
                {
                    // �擾�ł��Ȃ��ꍇ�A�O�̂���
                    registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + REG_KEY_USER_AP);
                }
            }
            catch (Exception ex)
            {
                // ��O
                registryKey = null;
                if (_clcLogOutputInfo == (int)CLCOutputCode.Enable)
                {
                    logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC GetRegistryKeyUserAP Exception", ex.Message));
                }
            }

            return registryKey;
        }

        #endregion // USER_AP���W�X�g���擾

        #endregion // �� Private Methods
    }
}

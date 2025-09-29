//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���g���C�擾���i
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11770032-00  �쐬�S�� : 杍^
// �� �� ��  2021/06/10   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Microsoft.Win32;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���g���C�ݒ�擾�o�͕��i
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���g���C�ݒ�擾���s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2021/06/10</br>
    /// </remarks>
    public class RetryXmlGetCommon
    { 
        #region �萔
        /// <summary>
        /// ���W�X�g�L�[������iSERVER�j
        /// </summary>
        private const string REG_KEY_SERVER = @"Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// ���W�X�g�L�[������iKEY32�j
        /// </summary>
        private const string REG_KEY32 = @"SOFTWARE\";

        /// <summary>
        /// ���W�X�g�L�[������iKEY64�j ���擾�ł��Ȃ��ꍇ
        /// </summary>
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";

        /// <summary>
        /// ���W�X�g��������i�C���X�g�[���f�B���N�g���j
        /// </summary>
        private const string REG_INSTALL_DIRECTORY = @"InstallDirectory";

        /// <summary>
        // ���g���C�ݒ�XML�t�@�C��
        /// </summary>
        private const string XML_FILE_NAME = @"{0}_RetrySetting.xml";
        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        public RetryXmlGetCommon()
        {
        }

        #endregion // �R���X�g���N�^

        #region public���\�b�h 
        /// <summary>
        /// XML���擾
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="retryCount">���g���C��(default)</param> 
        /// <param name="retryInterval">���g���C�Ԋu(default)</param>
        /// <param name="retrySettingInfo">���g���C�ݒ胏�[�N</param> 
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        public void GetXmlInfo(string pgid, int retryCount, int retryInterval, ref RetrySet retrySettingInfo)
        {
            // XML�z�u�p�X
            string installDir = string.Empty;
            // XML�ݒ�t�@�C��
            string xmlFile = string.Empty;
            try
            {
                retrySettingInfo = new RetrySet();
                // �J�����g�f�B���N�g���擾
                installDir = GetCurrentDirectory(REG_KEY_SERVER);

                // XML�t�@�C�����@PGID_RetrySetting.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                if (UserSettingController.ExistUserSetting(Path.Combine(installDir, xmlFile)))
                {
                    // XML���烊�g���C�񐔂ƃ��g���C�Ԋu���擾����
                    retrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(installDir, xmlFile));
                }
                else
                {
                    // ���g���C��-�f�t�H���g
                    retrySettingInfo.RetryCount = retryCount;
                    // ���g���C�Ԋu-�f�t�H���g
                    retrySettingInfo.RetryInterval = retryInterval;
                }
            }
            catch
            {
                if (retrySettingInfo == null) retrySettingInfo = new RetrySet();
                // ���g���C��-�f�t�H���g
                retrySettingInfo.RetryCount = retryCount;
                // ���g���C�Ԋu-�f�t�H���g
                retrySettingInfo.RetryInterval = retryInterval;
            }
        }

        #endregion // public���\�b�h

        #region private���\�b�h

        #region �J�����g�f�B���N�g���擾

        /// <summary>
        /// �J�����g�f�B���N�g���̃p�X�擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <returns>�J�����g�f�B���N�g���t���p�X</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        private string GetCurrentDirectory(string regKeyStr)
        {
            string defaultDir = string.Empty;

            // �߂�l�����l
            string homeDir = string.Empty;

            try
            {
                // ���s�t�@�C���i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch
            {
                // �����f�B���N�g���͔O�̂��߂̏����̂��߁A
                // �擾�ł��Ȃ��Ă��������s����
            }

            try
            {
                // ���W�X�g�������L�[�����擾
                RegistryKey registryKey = GetRegistryKey(regKeyStr);

                if (registryKey != null)
                {
                    homeDir = registryKey.GetValue(REG_INSTALL_DIRECTORY, defaultDir).ToString();
                }
            }
            catch
            {
                // ��O�������f�B���N�g���擾�\�������邽�ߏ������s
            }

            // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
            if (!Directory.Exists(homeDir))
            {
                homeDir = defaultDir;
            }

            return homeDir;
        }

        #endregion // �J�����g�f�B���N�g���擾

        #region ���W�X�g���L�[���擾

        /// <summary>
        /// ���W�X�g���L�[���擾
        /// ���֐��ŗ�O�����͕s�v�Ȃ��ߌĂяo�����Ŏ�������
        /// </summary>
        /// <param name="regKeyStr">�擾���W�X�g���L�[</param>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        private RegistryKey GetRegistryKey(string regKeyStr)
        {
            RegistryKey registryKey = null;

            // ���W�X�g�������L�[�����擾
            registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + regKeyStr);

            if (registryKey == null)
            {
                // �擾�ł��Ȃ��ꍇ�A�O�̂���
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + regKeyStr);
            }

            return registryKey;
        }

        #endregion // ���W�X�g���擾

        #endregion // private���\�b�h

    }

    # region
    /// <summary>
    /// ���g���C�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���g���C�ݒ�N���X</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2021/06/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // ���g���C��
        private int _retryCount;

        // ���g���C�Ԋu
        private int _retryInterval;

        /// <summary>
        /// ���g���C�ݒ�N���X
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>���g���C��</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>���g���C�Ԋu</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
}

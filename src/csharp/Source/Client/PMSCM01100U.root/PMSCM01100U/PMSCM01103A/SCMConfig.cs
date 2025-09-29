//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.IO;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM�̃R���t�B�O�N���X
    /// </summary>
    public static class SCMConfig
    {
        /// <summary>�f�t�H���g�z�[���p�X</summary>
        private const string DEFAULT_HOME_PATH = ".\\Log";

        /// <summary>�f�t�H���g���O�t�H���_����</summary>
        private const string DEFAULT_LOG_FOLDER_NAME = "SCMSend";

        /// <summary>���M�t�H���_����</summary>
        private const string SENDING_FOLDER_NAME = "Send";

        /// <summary>��M�t�H���_����</summary>
        private const string RECEIVED_FOLDER_NAME = "Recv";

        /// <summary>
        /// �f�t�H���g�̃��O�f�[�^�̃p�X���擾���܂��B
        /// </summary>
        /// <param name="path">�p�X</param>
        /// <returns>.\Log\SCMSend</returns>
        public static string GetSCMDefaultLogPath(string path)
        {
            MakeFolderIf(DEFAULT_HOME_PATH);
            MakeFolderIf(Path.Combine(DEFAULT_HOME_PATH, DEFAULT_LOG_FOLDER_NAME));
            return Path.Combine(DEFAULT_HOME_PATH, DEFAULT_LOG_FOLDER_NAME);
        }

        #region <���M�p�t�H���_>

        /// <summary>
        /// ���M�pSCM�񓚃f�[�^�̃p�X���擾���܂��B
        /// </summary>
        /// <param name="scmTotalSetting">SCM�S�̐ݒ�</param>
        /// <returns>
        /// SCM�S�̐ݒ�.���V�X�e���A�g�t�H���_ + "\Send" ��<c>string.Empty</c>�܂��͑��݂��Ȃ��p�X�̏ꍇ�A�f�t�H���g�p�X + "\Send"
        /// </returns>
        public static string GetSCMSendingDataPath(SCMTtlSt scmTotalSetting)
        {
            MakeFolderIf(scmTotalSetting.OldSysCoopFolder.Trim());
            return GetSCMSendingDataPath(scmTotalSetting.OldSysCoopFolder.Trim());
        }

        /// <summary>
        /// ���M�pSCM�񓚃f�[�^�̃p�X���擾���܂��B
        /// </summary>
        /// <param name="path">�p�X</param>
        /// <returns>
        /// �p�X + "\Send" ��<c>string.Empty</c>�܂��͑��݂��Ȃ��p�X�̏ꍇ�A�f�t�H���g�p�X + "\Send"
        /// </returns>
        private static string GetSCMSendingDataPath(string path)
        {
            return GetSCMDataPath(path, SENDING_FOLDER_NAME);
        }

        #endregion // </���M�p�t�H���_>

        #region <��M�p�t�H���_>

        /// <summary>
        /// ��M�pSCM�񓚃f�[�^�̃p�X���擾���܂��B
        /// </summary>
        /// <param name="scmTotalSetting">SCM�S�̐ݒ�</param>
        /// <returns>
        /// SCM�S�̐ݒ�.���V�X�e���A�g�t�H���_ + "\Recv" ��<c>string.Empty</c>�܂��͑��݂��Ȃ��p�X�̏ꍇ�A�f�t�H���g�p�X + "\Recv"
        /// </returns>
        public static string GetSCMReceivedDataPath(SCMTtlSt scmTotalSetting)
        {
            MakeFolderIf(scmTotalSetting.OldSysCoopFolder.Trim());
            return GetSCMReceivedDataPath(scmTotalSetting.OldSysCoopFolder.Trim());
        }

        /// <summary>
        /// ��M�pSCM�񓚃f�[�^�̃p�X���擾���܂��B
        /// </summary>
        /// <param name="path">�p�X</param>
        /// <returns>
        /// �p�X + "\Recv" ��<c>string.Empty</c>�܂��͑��݂��Ȃ��p�X�̏ꍇ�A�f�t�H���g�p�X + "\Recv"
        /// </returns>
        public static string GetSCMReceivedDataPath(string path)
        {
            MakeFolderIf(path);
            return GetSCMDataPath(path, RECEIVED_FOLDER_NAME);
        }

        #endregion // </��M�p�t�H���_>

        /// <summary>
        /// �A�g�p�f�[�^�p�X���擾���܂��B
        /// </summary>
        /// <param name="path">�p�X</param>
        /// <param name="folderName">���M�܂��͎�M�t�H���_����</param>
        /// <returns>
        /// �p�X + "\Send/Recv" ��<c>string.Empty</c>�܂��͑��݂��Ȃ��p�X�̏ꍇ�A�f�t�H���g�p�X + "\Send/Recv"
        /// </returns>
        private static string GetSCMDataPath(
            string path,
            string folderName
        )
        {
            // �� �܂��� �p�X�����݂��Ȃ��ꍇ�A�f�t�H���g�p�X��Ԃ�
            if (string.IsNullOrEmpty(path.Trim()) || !Directory.Exists(path))
            {
                string defaultDataPath = Path.Combine(DEFAULT_HOME_PATH, folderName);
                {
                    MakeFolderIf(DEFAULT_HOME_PATH);
                    MakeFolderIf(defaultDataPath);
                }
                return defaultDataPath;
            }
            DirectoryInfo dataPath = new DirectoryInfo(path);
            {
                if (dataPath.Name.Equals(folderName))
                {
                    return path;
                }
            }
            string dataPathName = Path.Combine(path, folderName);
            MakeFolderIf(dataPathName);
            return dataPathName;
        }

        /// <summary>
        /// �t�H���_�����݂��Ȃ���΁A�쐬���܂��B
        /// </summary>
        /// <param name="path">�t�H���_�p�X</param>
        public static void MakeFolderIf(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d�q����A�g�ݒ�
// �v���O�����T�v   : �d�q����A�g�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00 �쐬�S�� : 3H ����
// �� �� ��  2022/03/25  �V�K�쐬
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d�q����A�g�ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        :  �d�q����A�g�ݒ���s��</br>
    /// <br>Programmer	: 3H ����</br>
    /// <br>Date		: 2022/03/25</br>
    /// </remarks>
    public class EbooksLinkSetAcs
    {
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks>
        public EbooksLinkSetAcs()
        {
        }
        #endregion

        # region ��Private Members
        /// <summary>�d�q����A�g�T�|�[�g�ݒ�XML�t�@�C����</summary>
        private const string ctXML_EBOOKLINK_FILE_NAME = "MAKAU03000U_EbooksLinkSetting.XML";
        /// <summary>�C���X�g�[���f�B���N�g��</summary>
        private const string ctInstallDirectory = "InstallDirectory";
        /// <summary>�C���X�g�[�� ���W�X�g���L�[</summary>
        private const string ctRegistryKey = @"SOFTWARE\Broadleaf\Product\Partsman";
        /// <summary>����惊�X�g�󂯓n���t�H���_�����l</summary>
        private const string ctIniCustomFolderPath = @"eBooks\Customer";
        /// <summary>�d�q����󂯓n���t�H���_�����l</summary>
        private const string ctIniEBooksFolderPath = @"eBooks\eBooks";
        #endregion

        # region[�d�q����A�g�T�|�[�g�ݒ�����擾]
        /// <summary>
        /// �d�q����A�g�T�|�[�g�ݒ�����擾
        /// </summary>
        /// <returns>�d�q����󂯓n���t�H���_�p�X</returns>
        public void GetEBooksFolderPath(out EBooksLinkSetInfo eBooksLinkSetInfo)
        {
            eBooksLinkSetInfo = new EBooksLinkSetInfo();
            // Partsman�C���X�g�[���t�H���_>
            string sInstallFolderPath = GetInstallDirectory();

            // �d�q����󂯓n���t�H���_�@�f�t�H���g�l
            eBooksLinkSetInfo.EBooksFolder = Path.Combine(sInstallFolderPath, ctIniEBooksFolderPath);
            // ����惊�X�g�󂯓n���t�H���_�@�f�t�H���g�l
            eBooksLinkSetInfo.CustomFolder = Path.Combine(sInstallFolderPath, ctIniCustomFolderPath);

            // �d�q����A�g�T�|�[�g�ݒ���XML�t�@�C�����݂̔��f           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME)))
            {
                EBooksLinkSetInfo _eBooksLinkSetInfo = new EBooksLinkSetInfo();
                    _eBooksLinkSetInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));

                    // �d�q����󂯓n���t�H���_ �ݒ�̏ꍇ�A
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.EBooksFolder))
                    {
                        eBooksLinkSetInfo.EBooksFolder = _eBooksLinkSetInfo.EBooksFolder;
                    }

                    // ����惊�X�g�󂯓n���t�H���_ �ݒ�̏ꍇ�A
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.CustomFolder))
                    {
                        eBooksLinkSetInfo.CustomFolder = _eBooksLinkSetInfo.CustomFolder;
                    }
            }
        }
        # endregion

        # region[�d�q����A�g�T�|�[�g�ݒ������������]
        /// <summary>
        /// �d�q����A�g�T�|�[�g�ݒ������������
        /// </summary>
        /// <param name="_eBooksLinkSetInfo">�d�q����A�g�T�|�[�g�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteEBooksFolderPath(ref EBooksLinkSetInfo _eBooksLinkSetInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // �u�t�H���_�p�X�v�̏���XML�ɃV���A���C�Y����
                UserSettingController.SerializeUserSetting(_eBooksLinkSetInfo, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region [PMNS�̃C���X�g�[���p�X�擾]
        /// <summary>
        /// PMNS�̃C���X�g�[���p�X
        /// </summary>
        private string GetInstallDirectory()
        {
            // �N���C�A���g
            string sKeyPath = @String.Format(@ctRegistryKey);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(sKeyPath);
            string directoryPath = "";
            if (key.GetValue(ctInstallDirectory) != null)
            {
                directoryPath = (string)key.GetValue(ctInstallDirectory);
            }
            return directoryPath;
        }
        # endregion
    }

    # region [�d�q����A�g�T�|�[�g�ݒ���XML]
    /// <summary>
    /// �d�q����A�g�T�|�[�g�ݒ���
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class EBooksLinkSetInfo
    {
        /// <summary>
        /// �d�q����A�g�T�|�[�g�ݒ���
        /// </summary>
        public EBooksLinkSetInfo()
        {

        }

        /// <summary>�d�q����󂯓n���t�H���_</summary>
        private string _eBooksFolder;
        /// <summary>����惊�X�g�󂯓n���t�H���_</summary>
        private string _customFolder;

        /// <summary>�d�q����󂯓n���t�H���_</summary>
        public string EBooksFolder
        {
            get { return _eBooksFolder; }
            set { _eBooksFolder = value; }
        }

        /// <summary>����惊�X�g�󂯓n���t�H���_</summary>
        public string CustomFolder
        {
            get { return _customFolder; }
            set { _customFolder = value; }
        }
    }
    #endregion
}

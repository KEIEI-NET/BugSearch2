//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^�C���A�E�g�擾���i
// �v���O�����T�v   : �^�C���A�E�g�擾���i
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770032-00  �쐬�S�� : ���X�ؘj
// �� �� ��  2021/04/08   �C�����e : �^�C���A�E�g�擾���i�V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �^�C���A�E�g�擾���i
    /// </summary>
    /// <remarks>
    /// <br>Note		: �^�C���A�E�g�ݒ�l���擾���܂��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2021/04/08</br>
    /// </remarks>
    public class CommTimeoutConf
    {
        #region �� Private Members

        #endregion �� Private Members

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        // �^�C���A�E�g���Ԑݒ�t�@�C��
        /// </summary>
        private const string DBCOMMANDTIMEOUT_XML_FILE_NAME = "{0}_DbCmdTimeout.xml";

        /// <summary>
        // XML�t�@�C�����������̃f�t�H���g�l
        /// </summary>
        private const int DB_COMMAND_TIMEOUT_DEF = 120;

        /// <summary>
        // ���W�X�g��������l�̖��O
        /// </summary>
        private const string REG_STR_VALUE_NAME = "InstallDirectory";

        /// <summary>
        // XML�R�}���h�^�C���A�E�g���ږ�
        /// </summary>
        private const string XML_ELEMENT_SQL_COMMANDTIMEOUT = "SqlCommandTimeout";
        
        /// <summary>
        // ���W�X�g���T�u�L�[�i32bitOS�j
        /// </summary>
        private const string USER_AP_SUB_KEY_x86 = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        // ���W�X�g���T�u�L�[�i64bitOS�j
        /// </summary>
        private const string USER_AP_SUB_KEY_x64 = @"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP";


        #endregion //�v���C�x�[�g�t�B�[���h

        # region �� Constructor

        /// <summary>
        /// �^�C���A�E�g�ݒ�l�擾�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�C���A�E�g�ݒ�l�擾�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public CommTimeoutConf()
        {
        }

        #endregion �� Constructor

        #region �� Public Methods

        #region �^�C���A�E�g�ݒ�l�擾

        /// <summary>
        /// �^�C���A�E�g�ݒ�l�擾
        /// </summary>
        /// <param name="assemblyId">�ݒ�t�@�C�����̃A�Z���u��ID</param>
        /// <returns>�^�C���A�E�g���ԁi�b�j</returns>
        /// <remarks>
        /// <br>Note       : �^�C���A�E�g�l�擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public int GetDbCommandTimeout(string assemblyId)
        {
            return GetDbCommandTimeout(assemblyId, DB_COMMAND_TIMEOUT_DEF);
        }

        /// <summary>
        /// �^�C���A�E�g�ݒ�l�擾
        /// </summary>
        /// <param name="assemblyId">�ݒ�t�@�C�����̃A�Z���u��ID</param>
        /// <param name="defDbCommandTimeout">�f�t�H���g�^�C���A�E�g���ԁi�b�j</param>
        /// <returns>�^�C���A�E�g���ԁi�b�j</returns>
        /// <remarks>
        /// <br>Note       : �^�C���A�E�g�l�擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public int GetDbCommandTimeout(string assemblyId, int defDbCommandTimeout)
        {
            return GetXmlInfoDbCommandTimeout(assemblyId, defDbCommandTimeout);
        }

        #endregion // �^�C���A�E�g�ݒ�l�擾

        #endregion // �� Public Methods

        #region �� Private Methods

        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="assemblyId">�ݒ�t�@�C�����̃A�Z���u��ID</param>
        /// <param name="defDbCommandTimeout">�f�t�H���g�^�C���A�E�g���ԁi�b�j</param>
        /// <returns>�^�C���A�E�g���ԁi�b�j</returns>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : ���X�ؘj</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private int GetXmlInfoDbCommandTimeout(string assemblyId, int defDbCommandTimeout)
        {
            // �^�C���A�E�g���Ԑݒ�
            int retDbCommandTimeout = defDbCommandTimeout;

            // XML�t�@�C��FULLPATH
            string xmlFileName = string.Empty;

            XmlReaderSettings xmlReaderSettings = null;

            // XML�t�@�C��FULLPATH�擾
            xmlFileName = this.InitializeXmlSettings(assemblyId);

            if (xmlFileName != string.Empty)
            {
                xmlReaderSettings = new XmlReaderSettings();
                try
                {
                    using (XmlReader xmlReader = XmlReader.Create(xmlFileName, xmlReaderSettings))
                    {
                        while (xmlReader.Read())
                        {
                            // XML�t�@�C������^�C���A�E�g���Ԃ��擾
                            if (xmlReader.IsStartElement(XML_ELEMENT_SQL_COMMANDTIMEOUT))
                            {
                                retDbCommandTimeout = xmlReader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch
                {
                    // ��O�������̓f�t�H���g�l��ԋp
                    retDbCommandTimeout = DB_COMMAND_TIMEOUT_DEF;
                }
            }

            return retDbCommandTimeout;

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C�����擾
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <param name="assemblyId">�ݒ�t�@�C�����̃A�Z���u��ID</param>
        /// <returns>XML�t�@�C��FULLPATH</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : ���X�ؘj</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private string InitializeXmlSettings(string assemblyId)
        {
            string homeDir = string.Empty;
            string xmlFilePath = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C�����A��
                xmlFilePath = Path.Combine(homeDir, string.Format(DBCOMMANDTIMEOUT_XML_FILE_NAME, assemblyId));

                // �t�@�C�����݂��Ȃ��ꍇ�A�󔒂�ݒ肷��
                if (!File.Exists(xmlFilePath))
                {
                    xmlFilePath = string.Empty;
                }
            }
            catch
            {
                // ��O�������͋󔒂�ԋp
                xmlFilePath = string.Empty;
            }
            return xmlFilePath;
        }
        #endregion //XML�t�@�C�����擾

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>�J�����g�t�H���_</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�擾</br>
        /// <br>Programmer   : ���X�ؘj</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defCurrentDir = string.Empty;
            string retHomeDir = string.Empty;

            // XML�t�@�C���i�[�f�B���N�g���擾�i�J�����g�t�H���_�j
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defCurrentDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(USER_AP_SUB_KEY_x86);

                if (registryKey == null)
                {
                    registryKey = Registry.LocalMachine.OpenSubKey(USER_AP_SUB_KEY_x64);
                    if (registryKey == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        retHomeDir = defCurrentDir;
                    }
                    else
                    {
                        retHomeDir = registryKey.GetValue(REG_STR_VALUE_NAME, defCurrentDir).ToString();
                    }
                }
                else
                {
                    retHomeDir = registryKey.GetValue(REG_STR_VALUE_NAME, defCurrentDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(retHomeDir))
                {
                    retHomeDir = defCurrentDir;
                }
            }
            catch
            {
                // ��O���A�J�����g�t�H���_��ԋp
                if (!string.IsNullOrEmpty(defCurrentDir))
                {
                    retHomeDir = defCurrentDir;
                }
            }
            return retHomeDir;
        }
        #endregion // �J�����g�t�H���_

        #endregion �� Private Methods
    }
}

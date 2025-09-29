//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ����
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�VConvObjEnterpriseParamDB
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�VConvObjEnterpriseParamDB</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjEnterpriseParamDB : RemoteWithAppLockDB
    {
        #region �萔

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "�R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B";

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_EnterpriseSetting.xml";

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �R���o�[�g�ΏۊO��ƃR�[�h���X�g
        /// </summary>
        private string[] _convertOffEnterpriseCodeList;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�R���o�[�g�ΏۊO��ƃp�����[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjEnterpriseParamDB()
        {
            try
            {
                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _convertOffEnterpriseCodeList = null;                                   // �R���o�[�g�ΏۊO��ƃ��X�g

                string fileName = this.InitializeXmlSettings();
                string convertOffEnterpriseCode = string.Empty;

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("ConvertOffEnterpriseCodeList")) convertOffEnterpriseCode = reader.ReadElementContentAsString();
                        }

                        if (!string.IsNullOrEmpty(convertOffEnterpriseCode))
                        {
                            // �J���}��؂�̃��X�g��z��ɕϊ�
                            _convertOffEnterpriseCodeList = convertOffEnterpriseCode.Split(',');
                        }
                    }
                }
                else
                {
                    // ���O�o��
                    base.WriteErrorLog("ConvObjEnterpriseParamDB.ConvObjEnterpriseParamDB Exception");

                    // �ݒ�t�@�C�������݂��Ȃ��ꍇ���f
                    throw new Exception("ConvObjEnterpriseParamDB Exception");
                }
                #endregion // �ݒ�t�@�C���擾

            }
            catch(Exception ex)
            {
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjEnterpriseParamDB.ConvObjEnterpriseParamDB Exception");

                // �ݒ�t�@�C�������݂��Ȃ��ꍇ���f
                throw;
            }
        }

        #endregion //�R���X�g���N�^

        #region �� Public Methods

        #region �v���p�e�B

        /// <summary>
        /// �R���o�[�g�ΏۊO��ƃ��X�g
        /// </summary>
        public string[] ConvertOffEnterpriseCodeList
        {
            get { return _convertOffEnterpriseCodeList; }
            set { _convertOffEnterpriseCodeList = value; }
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

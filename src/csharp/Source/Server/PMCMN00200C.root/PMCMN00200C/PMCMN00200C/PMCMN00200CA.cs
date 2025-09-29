using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using Broadleaf.Application.Resources;
using System.Threading;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Text;
using System.Net;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���O�o�͕��i
    /// </summary>
    /// <remarks>
    /// <br>Note       : CLC���O�A���O�t�@�C���o�͂��s���N���X�ł��B</br>
    /// <br>Programmer : 32470 ����</br>
    /// <br>Date       : 2021/02/26</br>
    /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2021/03/25</br>
    /// </remarks>
    public class OutLogCommon
    { 
        #region �萔

        /// <summary>
        /// ���W�X�g�L�[������iCLIENT�j
        /// </summary>
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";

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
        /// UISettings�t�H���_
        /// </summary>
        private const string DIR_UISETTINGS = @"UISettings";

        /// <summary>
        /// ���O�o�͐���ݒ�t�@�C�����@���擪��PGID��t�^���Ďg�p
        /// </summary>
        private const string XML_FILE_NAME = @"{0}_LogOutCheckEnabler.xml";

        /// <summary>
        /// ���O�o�̓t�H���_
        /// Log\PGID�t�H���_�ɏo�͂���
        /// </summary>
        private const string LOG_DIRECTORY = @"Log\{0}";

        /// <summary>
        /// PGID
        /// </summary>
        private const string PGID = "PMCMN00200C";

        /// <summary>
        /// CLC���O�t�@�C����
        /// PMCMN00200C+PGID+DateTime��yyyyMMddmmssfff+�]�ƈ�ID+Guid.NewGuid()
        /// </summary>
        private const string CLC_LOGFILE_NAME = "PMCMN00200C_{0}_{1:yyyyMMddHHmmssfff}_{2}_{3}.clc";

        /// <summary>
        /// ���O�t�@�C����
        /// PGID+DateTime��yyyyMMdd+�]�ƈ�ID
        /// </summary>
        private const string OUTPUT_FILE_NAME = "{0}_{1:yyyyMMdd}_{2}.log";

        /// <summary>
        /// NA
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// EXNA
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ENTERPRISECODE�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_ENTERPRISECODE = "ENTERPRISECODE={0},";

        /// <summary>
        /// IP�A�h���X
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

        /// <summary>
        /// PC�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// CPU�g�p�� �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_CPU = "CPU(%)={0},";

        /// <summary>
        /// �������g�p��/�e�� �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// �f�B�X�N�g�p��/�e�� �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0},";

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        private const string LOGOUTPUT_MSG = "MSG={0},";

        /// <summary>
        /// ��O���b�Z�[�W
        /// </summary>
        private const string LOGOUTPUT_EXMSG = "EXMSG={0},";

        /// <summary>
        /// �X�^�b�N�g���[�X
        /// </summary>
        private const string LOGOUTPUT_STACKTRACE = "STACKTRACE={0}";

        /// <summary>
        /// CLC�o�̓��b�Z�[�W�ő啶����
        /// </summary>
        private const int CLCMSG_MAXCNT = 3000;

        // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
        /// <summary>
        /// Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)
        /// </summary>
        private const int EXECUTE_MODE = 0;

        /// <summary>
        /// �^�u���
        /// </summary>
        private const string TAB_DELIMITED = "\t";

        // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public OutLogCommon()
        {
        }

        #endregion // �R���X�g���N�^

        // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
        #region public���\�b�h
        /// <summary>
        /// �N���C�A���g���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="sleepMode">Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���g���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLogWithSettingSleep(string pgid, string message, string enterpriseCode, string employeeCode, int sleepMode)
        {
            try
            {
                OutputClientLogWithSettingSleep(pgid, message, enterpriseCode, employeeCode, null, sleepMode);
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }

        /// <summary>
        /// �N���C�A���g���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <param name="sleepMode">Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���g���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLogWithSettingSleep(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // �ݒ�t�@�C���擾
                GetClientXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLC���O�o��
                    OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex, sleepMode);

                }

                if (logOutFileDiv)
                {
                    // �J�����g�f�B���N�g���擾
                    installDir = GetCurrentDirectory(REG_KEY_CLIENT);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // �J�����g�f�B���N�g���擾�ł����ꍇ
                        // ���O�t�@�C���o��
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, sleepMode);
                    }
                }
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }
        #endregion
        // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<

        #region public���\�b�h 

        /// <summary>
        /// �N���C�A���g���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���g���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLog(string pgid, string message, string enterpriseCode, string employeeCode)
        {
            try
            {
                OutputClientLog(pgid, message, enterpriseCode, employeeCode, null);
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }
        
        /// <summary>
        /// �N���C�A���g���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���g���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // �ݒ�t�@�C���擾
                GetClientXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLC���O�o��
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex);
                    OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
    
                }

                if (logOutFileDiv)
                {
                    // �J�����g�f�B���N�g���擾
                    installDir = GetCurrentDirectory(REG_KEY_CLIENT);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // �J�����g�f�B���N�g���擾�ł����ꍇ
                        // ���O�t�@�C���o��
                        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                        //WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex);
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
                    }
                }
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }

        /// <summary>
        /// �T�[�o�[���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <remarks>
        /// <br>Note       : �T�[�o�[���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputServerLog(string pgid, string message, string enterpriseCode, string employeeCode)
        {
            try
            {
                OutputServerLog(pgid, message, enterpriseCode, employeeCode, null);
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }

        /// <summary>
        /// �T�[�o�[���O�o��
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O�o�̓��b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �T�[�o�[���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        public void OutputServerLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // �ݒ�t�@�C���擾
                GetServerXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLC���O�o��
                    OutputServerClcLog(pgid, message, enterpriseCode, employeeCode, ex);

                }

                if (logOutFileDiv)
                {
                    // �J�����g�f�B���N�g���擾
                    installDir = GetCurrentDirectory(REG_KEY_SERVER);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // �J�����g�f�B���N�g���擾�ł����ꍇ
                        // ���O�t�@�C���o��
                        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                        //WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex);
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
                    }
                }
            }
            catch
            {
                // ��O���͌㑱�����ɉe�������Ȃ�
            }
        }

        #endregion // public���\�b�h

        #region private���\�b�h

        #region �N���C�A���gXML���擾

        /// <summary>
        /// �N���C�A���gXML���擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="clcLogOutDiv">CLC���O�o�͐��� true:�o�͂��� false:�o�͂��Ȃ�</param>
        /// <param name="logOutFileDiv">���O�t�@�C���o�͐��� true:�o�͂��� false:�o�͂��Ȃ�</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���gXML���擾���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        private void GetClientXml(string pgid, out bool clcLogOutDiv, out bool logOutFileDiv)
        {
            string installDir = string.Empty;
            string uisettingsDir = string.Empty;
            string xmlFile = string.Empty;
            string xmlPath = string.Empty;

            // �߂�p�����[�^�����l
            clcLogOutDiv = false;
            logOutFileDiv = false;

            // �J�����g�f�B���N�g���擾
            installDir = GetCurrentDirectory(REG_KEY_CLIENT);

            if (!string.IsNullOrEmpty(installDir))
            {
                // �J�����g�f�B���N�g���擾�����������ꍇ
                // UISetting�t�H���_
                uisettingsDir = Path.Combine(installDir, DIR_UISETTINGS);

                // XML�t�@�C�����@PGID_LogOutCheckEnabler.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                // �t���p�X
                xmlPath = Path.Combine(uisettingsDir, xmlFile);

                if (UserSettingController.ExistUserSetting(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ���O�o�͉ې���t�@�C����ǂݍ���
                        while (reader.Read())
                        {
                            //CLC���O�o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("ClcLogOutDiv")) clcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //���O�t�@�C���o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("LogOutFileDiv")) logOutFileDiv = Convert.ToBoolean(reader.ReadElementString("LogOutFileDiv").Trim());
                        }
                    }
                }
            }
        }

        #endregion // �N���C�A���gXML���擾

        #region �N���C�A���gXML���擾

        /// <summary>
        /// �T�[�o�[XML���擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="clcLogOutDiv">CLC���O�o�͐��� true:�o�͂��� false:�o�͂��Ȃ�</param>
        /// <param name="logOutFileDiv">���O�t�@�C���o�͐��� true:�o�͂��� false:�o�͂��Ȃ�</param>
        /// <remarks>
        /// <br>Note       : �T�[�o�[XML���擾���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        private void GetServerXml(string pgid, out bool clcLogOutDiv, out bool logOutFileDiv)
        {
            string installDir = string.Empty;
            string xmlFile = string.Empty;
            string xmlPath = string.Empty;

            // �߂�p�����[�^�����l
            clcLogOutDiv = false;
            logOutFileDiv = false;

            // �J�����g�f�B���N�g���擾
            installDir = GetCurrentDirectory(REG_KEY_SERVER);

            if (!string.IsNullOrEmpty(installDir))
            {
                // �J�����g�f�B���N�g���擾�����������ꍇ

                // XML�t�@�C�����@PGID_LogOutCheckEnabler.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                // �t���p�X
                xmlPath = Path.Combine(installDir, xmlFile);

                // XML�ݒ���擾
                // XML�t�@�C�����Ȃ��ꍇ�̓��O�o�͂��Ȃ�
                if (File.Exists(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ���O�o�͉ې���t�@�C����ǂݍ���
                        while (reader.Read())
                        {
                            //CLC���O�o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("ClcLogOutDiv")) clcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //���O�t�@�C���o�͋敪(true:�o�͂���Gfalse:�o�͂��Ȃ�)
                            if (reader.IsStartElement("LogOutFileDiv")) logOutFileDiv = Convert.ToBoolean(reader.ReadElementString("LogOutFileDiv").Trim());
                        }
                    }
                }
            }
        }

        #endregion // �N���C�A���gXML���擾

        #region �J�����g�f�B���N�g���擾

        /// <summary>
        /// �J�����g�f�B���N�g���̃p�X�擾
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <returns>�J�����g�f�B���N�g���t���p�X</returns>
        /// <remarks>
        /// <br>Note       : �J�����g�f�B���N�g���̃p�X���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
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
        /// <br>Note       : ���W�X�g���L�[�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
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

        #region �N���C�A���gCLC���O�o��

        /// <summary>
        /// �N���C�A���gCLC���O�o��
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <param name="sleepMode">Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �N���C�A���gCLC���O�o��</br>
        /// <br>Programer  : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
        //private void OutputClientClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        private void OutputClientClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
        {
            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            string logContents = string.Empty;

            try
            {
                // ��ƃR�[�h�i�[
                builder.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, enterpriseCode));
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // �V�X�e�����i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //builder.Append(GetSysInfo());
                builder.Append(TAB_DELIMITED);
                builder.Append(GetSysInfo(sleepMode));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // ���b�Z�[�W�i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //builder.Append(string.Format(LOGOUTPUT_MSG, message));
                builder.Append(TAB_DELIMITED);
                builder.Append(string.Format(LOGOUTPUT_MSG, message).Replace("\r", " ").Replace("\n", " ").Replace("\t", " "));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }


            if (ex != null)
            {
                try
                {
                    // ��O���b�Z�[�W�W�J
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
                }
                catch
                {
                    // �ݒ莸�s�����������s
                }

                try
                {
                    // �X�^�b�N�g���[�X�W�J
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
                }
                catch
                {
                    // �ݒ莸�s�����������s
                }
            }
            // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
            //ex��null�̏ꍇ���A��̃^�u2�Ƃ����悤�ȏo�͂ɂ���
            else
            {
                builder.Append(TAB_DELIMITED);
                builder.Append(TAB_DELIMITED);
            }
            // 1�s�̍Ō�i�����j�ɁA�s���͋�̃^�u��t�^����
            builder.Append(TAB_DELIMITED);
            // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<

            if (builder.ToString().Length > CLCMSG_MAXCNT)
            {
                // CLC���b�Z�[�W�����񂪍ő吔�𒴂��Ă���ꍇ�A�ő吔�ɐݒ�
                logContents = builder.ToString().Substring(0, CLCMSG_MAXCNT);
            }
            else
            {
                logContents = builder.ToString();
            }

            // Guid�擾
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            // clc���O�t�@�C����:PMCMN00200C+PGID+DateTime��yyyyMMddmmssfff+�]�ƈ�ID+Guid.NewGuid()
            string ClclogFileName = string.Format(CLC_LOGFILE_NAME, pgid, now, employeeCode.Trim(), guid);

            // ProgramData���փ��O�o��
            KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
            log.WriteProductLogHeader(ConstantManagement_SF_PRO.ProductCode, ClclogFileName, logContents);
        }

        #endregion // �N���C�A���gCLC���O�o��

        #region �T�[�o�[CLC���O�o��

        /// <summary>
        /// �T�[�o�[CLC���O�o��
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �T�[�o�[CLC���O�o��</br>
        /// <br>Programer  : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        private void OutputServerClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            string logContents = string.Empty;

            try
            {
                // ��ƃR�[�h�i�[
                builder.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, enterpriseCode));
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // �V�X�e�����i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //builder.Append(GetSysInfo());
                builder.Append(TAB_DELIMITED);
                builder.Append(GetSysInfo(EXECUTE_MODE));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // ���b�Z�[�W�i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //builder.Append(string.Format(LOGOUTPUT_MSG, message));
                builder.Append(TAB_DELIMITED);
                builder.Append(string.Format(LOGOUTPUT_MSG, message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }


            if (ex != null)
            {
                try
                {
                    // ��O���b�Z�[�W�W�J
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                }
                catch
                {
                    // �ݒ莸�s�����������s
                }

                try
                {
                    // �X�^�b�N�g���[�X�W�J
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                }
                catch
                {
                    // �ݒ莸�s�����������s
                }
            }
            // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
            else
            {
                // ex��null�̏ꍇ���A��̃^�u2�Ƃ����悤�ȏo�͂ɂ���
                builder.Append(TAB_DELIMITED);
                builder.Append(TAB_DELIMITED);
            }
            // 1�s�̍Ō�i�����j�ɁA�s���͋�̃^�u��t�^����
            builder.Append(TAB_DELIMITED);
            // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<

            if (builder.ToString().Length > CLCMSG_MAXCNT)
            {
                // CLC���b�Z�[�W�����񂪍ő吔�𒴂��Ă���ꍇ�A�ő吔�ɐݒ�
                logContents = builder.ToString().Substring(0, CLCMSG_MAXCNT);
            }
            else
            {
                logContents = builder.ToString();
            }

            // Guid�擾
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            // clc���O�t�@�C����:PMCMN00200C+PGID+DateTime��yyyyMMddmmssfff+�]�ƈ�ID+Guid.NewGuid()
            string ClclogFileName = string.Format(CLC_LOGFILE_NAME, pgid, now, employeeCode.Trim(), guid);

            // ProgramData���փ��O�o��
            KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
            log.WriteServiceLogHeader(ConstantManagement_SF_PRO.ProductCode, PGID, ClclogFileName, logContents);
        }

        #endregion // �N���C�A���gCLC���O�o��

        #region �V�X�e�����擾
        /// <summary>
        /// �V�X�e�����擾
        /// </summary>
        /// <param name="sleepMode">Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</param>
        /// <returns>�V�X�e����񕶎���</returns>
        /// <remarks>
        /// <br>Note       : �N���C�A���gCLC���O�o��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
        //private string GetSysInfo()
        private string GetSysInfo(int sleepMode)
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
        {
            StringBuilder sysInfo = new StringBuilder();

            #region PC���擾
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, Environment.MachineName));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, LOGOUTPUT_EXNA));
            }
            #endregion PC���擾

            #region IP�A�h���X�擾
            try
            {
                IPAddress[] adrList = Dns.GetHostAddresses(Environment.MachineName);
                StringBuilder ipAddress = new StringBuilder();
                foreach (IPAddress address in adrList)
                {
                    ipAddress.Append(address.ToString());
                    ipAddress.Append(" ");
                }
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, ipAddress.ToString()));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, LOGOUTPUT_EXNA));
            }
            #endregion PC���擾

            #region CPU�g�p���擾
            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                string cpuUsage = (cpuCounter.NextValue()).ToString("0");

                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //Thread.Sleep(1000);
                if (sleepMode == EXECUTE_MODE) Thread.Sleep(1000);
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<

                // 2��ڂ̒l���擾����
                cpuUsage = (cpuCounter.NextValue()).ToString("0");

                if (!string.IsNullOrEmpty(cpuUsage))
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_CPU, cpuUsage));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_NA));
                }
            }
            catch
            {
                try
                {
                    // ���s����Processor Information����擾
                    PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

                    string cpuUsage = (cpuCounter.NextValue()).ToString("0");

                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //Thread.Sleep(1000);
                    if (sleepMode == EXECUTE_MODE) Thread.Sleep(1000);
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<

                    // 2��ڂ̒l���擾����
                    cpuUsage = (cpuCounter.NextValue()).ToString("0");

                    if (!string.IsNullOrEmpty(cpuUsage))
                    {
                        // ���O�o�͓��e�i�[
                        sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, cpuUsage));
                    }
                    else
                    {
                        // ���O�o�͓��e�i�[
                        sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_NA));
                    }
                }
                catch
                {
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_EXNA));
                }
            }
            #endregion CPU�g�p���擾

            #region �������g�p�ʎ擾
            try
            {
                ComputerInfo ci = new ComputerInfo();

                string avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
                string totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();

                string memUsageCap = string.Format("{0}/{1}", avaliableMemory, totalMemory);
                if (!string.IsNullOrEmpty(memUsageCap))
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ���O�o�͓��e�i�[
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
            }
            #endregion �������g�p�ʎ擾

            #region �f�B�X�N�e�ʎ擾
            try
            {
                DriveInfo[] driveList = null;

                string avaliableCapDisk = string.Empty;
                string defaultDir = string.Empty;

                driveList = DriveInfo.GetDrives();

                foreach (DriveInfo di in driveList)
                {
                    if ((di.IsReady == true) && (di.DriveType == DriveType.Fixed))
                    {
                        avaliableCapDisk += string.Format("{0}{1}/{2} ",
                            di.Name.TrimEnd('\\'),
                            (Convert.ToInt64(di.AvailableFreeSpace.ToString()) / 1024 / 1024).ToString(),
                            (Convert.ToInt64(di.TotalSize.ToString()) / 1024 / 1024).ToString());
                    }
                }

                if (!string.IsNullOrEmpty(avaliableCapDisk))
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, avaliableCapDisk));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ���O�o�͓��e�i�[
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_EXNA));
            }
            #endregion �f�B�X�N�g�p�ʎ擾

            return sysInfo.ToString();
        }

        #endregion // �V�X�e�����擾

        #region LOG�t�H���_�փ��O�o��

        /// <summary>
        /// LOG�t�H���_�փ��O�o��
        /// ���֐��Ŕ��������O�����͌Ăяo�����Ŕj������
        /// </summary>
        /// <param name="currentDir">�J�����g�f�B���N�g��</param>
        /// <param name="pgid">�v���O����ID</param>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <param name="sleepMode">Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : LOG�t�H���_�փ��O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()�����s����邩���䃁�\�b�h��ǉ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// </remarks>
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
        //private void WriteLog(string currentDir, string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        private void WriteLog(string currentDir, string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
        {
            string logDirName = string.Empty;
            string logDir = string.Empty;
            string logFileName = string.Empty;
            string logPath = string.Empty;

            DateTime now = DateTime.Now;

            StringBuilder logContents = new StringBuilder();

            try
            {
                // ���O�o�͓����i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //logContents.AppendLine(now.ToString());
                logContents.Append(now.ToString());
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // �V�X�e�����i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //logContents.AppendLine(GetSysInfo());
                logContents.Append(TAB_DELIMITED);
                logContents.Append(GetSysInfo(sleepMode));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                // ���b�Z�[�W�i�[
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                //logContents.AppendLine(string.Format(LOGOUTPUT_MSG, message));
                logContents.Append(TAB_DELIMITED);
                logContents.Append(string.Format(LOGOUTPUT_MSG, message.Replace(TAB_DELIMITED, " ").Replace("\r", " ").Replace("\n", " ")));
                // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            try
            {
                if (ex != null)
                {
                    // ��O���i�[
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                    //logContents.AppendLine(ex.ToString());
                    logContents.Append(TAB_DELIMITED);
                    logContents.Append(ex.ToString().Replace(TAB_DELIMITED, " ").Replace("\r", " ").Replace("\n", " "));
                    // ---UPD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
                }
                // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------>>>>>
                else
                {
                    // ex��null�̏ꍇ���A��̃^�u2�Ƃ����悤�ȏo�͂ɂ���
                    logContents.Append(TAB_DELIMITED);
                    logContents.Append(TAB_DELIMITED);
                }
                // ---ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή� ------<<<<<
            }
            catch
            {
                // �ݒ莸�s�����������s
            }

            // 1�s�̍Ō�i�����j�ɁA�s���͋�̃^�u��t�^����
            logContents.Append(TAB_DELIMITED);// ADD ���O 2021/03/25 PMKOBETSU-4133�̑Ή�
            // ���O�t�@�C�����@PGID+DateTime��yyyyMMdd+�]�ƈ�ID
            logFileName = string.Format(OUTPUT_FILE_NAME, pgid, now, employeeCode.Trim());

            // ���O�t�H���_���ݒ�
            logDirName = string.Format(LOG_DIRECTORY, PGID);

            // ���O�t�H���_
            logDir = Path.Combine(currentDir, logDirName);

            if (!Directory.Exists(logDir))
            {
                // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                Directory.CreateDirectory(logDir);
            }

            logPath = Path.Combine(logDir, logFileName);

            // ���O�o��
            using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.Default))
            {
                writer.WriteLine(logContents.ToString());
            }
        }

        #endregion // LOG�t�H���_�փ��O�o��

        #endregion // private���\�b�h

    }
}

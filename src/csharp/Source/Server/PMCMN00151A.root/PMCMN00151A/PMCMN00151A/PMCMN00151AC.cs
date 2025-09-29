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
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �e���������ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �e�������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvCommn
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

        # region �� Constructor

        /// <summary>
        /// �e���������ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�������f�[�^�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvCommn()
        {
        }

        # endregion // �� Constructor

        #region �� Public Methods

        #region USER_AP���W�X�g���擾

        /// <summary>
        /// USER_AP���W�X�g���擾
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public RegistryKey GetRegistryKeyUserAP()
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
            catch(Exception ex)
            {
                // ��O
                registryKey = null;
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetRegistryKeyUserAP Exception", ex.Message));
            }

            return registryKey;
        }

        #endregion // USER_AP���W�X�g���擾

        #region CLIENT���W�X�g���擾

        /// <summary>
        /// CLIENT���W�X�g���擾
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public RegistryKey GetRegistryKeyClient()
        {
            RegistryKey registryKey = null;

            try
            {
                // ���W�X�g�������CLIENT�̃L�[�����擾
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + REG_KEY_CLIENT);
                if (registryKey == null)
                {
                    // �擾�ł��Ȃ��ꍇ�A�O�̂���
                    registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + REG_KEY_CLIENT);
                }

            }
            catch(Exception ex)
            {
                // ��O
                registryKey = null;
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetRegistryKeyClient Exception", ex.Message));
            }

            return registryKey;
        }

        #endregion // CLIENT���W�X�g���擾

        #region CPU�g�p���擾

        /// <summary>
        /// CPU�g�p���擾
        /// </summary>
        /// <returns>CPU�g�p��</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public string GetCpuCounter()
        {

            PerformanceCounter cpuCounter = null;

            string cpuUsage = string.Empty;

            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                cpuUsage = (cpuCounter.NextValue()).ToString("0");

                Thread.Sleep(1000);

                // 2��ڂ̒l���擾����
                cpuUsage = (cpuCounter.NextValue()).ToString("0");

            }
            catch(Exception ex)
            {
                // ��O
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetCpuCounter Exception", ex.Message));
            }
            finally
            {
                // �擾�ł��Ȃ��ꍇ
                if (String.IsNullOrEmpty(cpuUsage))
                {
                    cpuUsage = "NA";
                }

                cpuCounter.Dispose();
            }

            return cpuUsage;
        }

        #endregion // CPU�g�p���擾

        #region �������g�p�ʎ擾

        /// <summary>
        /// �������g�p�ʎ擾
        /// </summary>
        /// <returns>�������g�p��</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public string GetAvaliableMemory()
        {

            ComputerInfo ci = null;

            string avaliableMemory = string.Empty;

            try
            {
                ci = new ComputerInfo();

                avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
            }
            catch(Exception ex)
            {
                // ��O
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetAvaliableMemory Exception", ex.Message));
            }
            finally
            {
                // �擾�ł��Ȃ��ꍇ
                if (String.IsNullOrEmpty(avaliableMemory))
                {
                    avaliableMemory = "NA";
                }
            }

            return avaliableMemory;
        }

        #endregion // �������g�p�ʎ擾

        #region �������e�ʎ擾

        /// <summary>
        /// �������e�ʎ擾
        /// </summary>
        /// <returns>�������e��</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public string GetTotalMemory()
        {

            ComputerInfo ci = null;

            string totalMemory = string.Empty;

            try
            {
                ci = new ComputerInfo();

                totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();
            }
            catch(Exception ex)
            {
                // ��O
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetTotalMemory Exception", ex.Message));
            }
            finally
            {
                // �擾�ł��Ȃ��ꍇ
                if (String.IsNullOrEmpty(totalMemory))
                {
                    totalMemory = "NA";
                }
            }

            return totalMemory;
        }
        #endregion // �������e�ʎ擾

        #region �f�B�X�N�g�p��/�e�ʎ擾
        /// <summary>
        /// �f�B�X�N�g�p��/�e�ʎ擾
        /// </summary>
        /// <returns>�f�B�X�N�g�p��/�e��</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public string GetAvaliableCapDisk()
        {

            DriveInfo[] driveList = null;

            string avaliableCapDisk = string.Empty;
            string defaultDir = string.Empty;

            try
            {

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
            }
            catch(Exception ex)
            {
                // �G���[���o��
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetAvaliableCapDisk Exception", ex.Message));
            }
            finally
            {
                // �擾�ł��Ȃ��ꍇ
                if (String.IsNullOrEmpty(avaliableCapDisk))
                {
                    avaliableCapDisk = "NA";
                }
            }

            return avaliableCapDisk;
        }
        #endregion // �f�B�X�N�g�p��/�e�ʎ擾

        #region CLC���O�o��
        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        public void ClcLogOutput(string message)
        {
            DateTime now = DateTime.Now;

            string logFileName = string.Empty;

            KICLC00001C.LogHeader log = null;

            try
            {
                // ���O�t�@�C�����̍쐬
                // "PMCMN00150U_"+DateTime��Ticks+Guid������
                logFileName = string.Format("PMCMN00150U_{0}_{1}.log", now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData���փ��O�o��
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00150U", logFileName, message);

            }
            catch
            {
                // ��O �Ăяo�����ɖ߂�
                throw;
            }
            finally
            {
            }
        }
        #endregion // CLC���O�o��

        #endregion // �� Public Methods
    }
}

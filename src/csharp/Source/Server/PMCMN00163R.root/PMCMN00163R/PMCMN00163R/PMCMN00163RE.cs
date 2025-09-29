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

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Threading;
using System.Net;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�vConvObjCLCLogDB
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�vConvObjCLCLogDB</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkCLCLogDB
    {
        #region �萔

        /// <summary>
        /// ��ƃR�[�h�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_ENTERPRISECODE = "ENTERPRISECODE={0},";

        /// <summary>
        /// PC�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// IP�A�h���X
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

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
        /// ���擾���s �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// ���擾��O �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// �����ς݃}�X�^�����i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_BACKUP_MST = "BK_MST={0},";

        /// <summary>
        /// ���O�o�͓��e�i�V�X�e�����j
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} SYSINFO:{1}";

        #endregion // �萔

        #region �v���C�x�[�g�ϐ�

        /// <summary>
        /// ��ƃR�[�h�i���O�o�́j
        /// </summary>
        private string _enterpriseCode;

        /// <summary>
        /// �����ς݃}�X�^�����i���O�o�́j
        /// </summary>
        private int _bkMstCnt;

        #endregion �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        /// <summary>
        /// ��ƃR�[�h�i���O�o�́j
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// �����ς݃}�X�^�����i���O�o�́j
        /// </summary>
        public int BkMstCnt
        {
            get { return _bkMstCnt; }
            set { _bkMstCnt = value; }
        }

        #endregion // �v���p�e�B

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
        public ConvObjSingleBkCLCLogDB()
        {
            _bkMstCnt = 0;
        }

        #endregion //�R���X�g���N�^

        #region �� Public Methods

        #region CLC���O�o��
        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="message">���O���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
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
                // �o�͓��e�ɃV�X�e������t������B
                string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, GetSysInfo());

                // 

                // ���b�Z�[�W���̉��s�R�[�h���X�y�[�X�ɕϊ�
                logoutput = logoutput.Replace("\r", "").Replace("\n", " ").TrimEnd();

                // ���O�t�@�C�����̍쐬
                // "PMCMN00163R_"+DateTime��Ticks+Guid������
                logFileName = string.Format("PMCMN00163R_{0}_{1}.log", now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData���փ��O�o��
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00163R", logFileName, logoutput);

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

        #region �� Private Methods

        #region �V�X�e�����擾
        /// <summary>
        /// �V�X�e�����擾
        /// </summary>
        /// <returns>�V�X�e����񕶎���</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string GetSysInfo()
        {
            StringBuilder sysInfo = new StringBuilder();

            #region ��ƃR�[�h�擾
            sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, _enterpriseCode));
            #endregion ��ƃR�[�h�擾

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
            #endregion IP�A�h���X�擾

            #region CPU�g�p���擾

            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                string cpuUsage = (cpuCounter.NextValue()).ToString("0");

                Thread.Sleep(1000);

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

                    Thread.Sleep(1000);

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

            #region �}�X�^�����t��

            // ���O�o�͓��e�i�[
            sysInfo.Append(string.Format(LOGOUTPUT_BACKUP_MST, _bkMstCnt));

            #endregion �}�X�^�����t��

            return sysInfo.ToString();
        }
        #endregion // �V�X�e�����擾

        #endregion // �� Private Methods

    }
}

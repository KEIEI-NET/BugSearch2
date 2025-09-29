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
using System;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using System.IO;
using System.Net;

namespace Broadleaf.Application.Common
{
    public class LogInfoAllCls : RemoteDB
    {
        #region �萔��`

        /// <summary>
        /// �@�\��
        /// </summary>
        private const string ApplicationName = "�R���o�[�g�Ώێ����o�b�N�A�b�v";

        /// <summary>
        /// CLC���O�t�@�C����
        /// </summary>
        private const string CLCLogFileName = "PMCMN00160U_{0}_{1}.log";

        /// <summary>
        /// �I�y���[�V�����R�[�h�f�t�H���g
        /// </summary>
        private const int OperationCodeDefault = 0;

        /// <summary>
        ///  �I�y���[�V�����X�e�[�^�X�f�t�H���g
        /// </summary>
        private const int OperationStatusDefault = 0;

        /// <summary>
        /// ENTERPRISECODE�i���O�o�́j
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
        private const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0}";

        /// <summary>
        /// ���擾���s �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// ���擾��O �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ���O�o�͓��e
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} SYSINFO:{1}";

        #endregion //�萔��`

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �A�Z���u��ID
        /// </summary>
        private string AssemblyId = string.Empty;

        /// <summary>
        /// �R���o�[�g�Ώێ����o�b�N�A�b�v�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
        /// </summary>
        private IConvObjSingleBkDB IConvertObjectDB = null;

        /// <summary>
        /// �p�����[�^
        /// </summary>
        private static ConvObjBkParam codbp = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public LogInfoAllCls()
        {
            // �A�Z���u�������t���p�X�Ŏ擾
            string fullAssemblyName = this.GetType().Assembly.Location;
            // �A�Z���u�����݂̂��擾
            this.AssemblyId = System.IO.Path.GetFileName(fullAssemblyName);
            // �p�����[�^
            codbp = new ConvObjBkParam();
        }

        #endregion //�R���X�g���N�^

        #region ���O�o��
        /// <summary>
        /// �T�[�o���O�o��
        /// </summary>
        /// <param name="ex">��O</param>
        /// <param name="errorText">�G���[���b�Z�[�W</param>
        /// <param name="status">�����X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �T�[�o���O�Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public void WriteErrorServerLog(Exception ex, string errorText, int status)
        {
            WriteErrorServerLogProc(ex, errorText, status);
        }

        /// <summary>
        /// �T�[�o���O�o��
        /// </summary>
        /// <param name="ex">��O</param>
        /// <param name="errorText">�G���[���b�Z�[�W</param>
        /// <param name="status">�����X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �T�[�o���O�Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorServerLogProc(Exception ex, string errorText, int status)
        {
            try
            {
                base.WriteErrorLog(ex, errorText, status);
            }
            catch
            {
                // ��O
            }
        }

        /// <summary>
        /// �I�y���[�V�������O�o��
        /// </summary>
        /// <param name="processName">��������</param>
        /// <param name="stepName">�����敪</param>
        /// <param name="data">�X�V���e</param>
        /// <remarks>
        /// <br>Note       : �����̓��e�ŃI�y���[�V�������O�ɑ��샍�O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public void WriteOperationLog(string processName, string stepName, string data)
        {
            WriteOperationLogProc(processName, stepName, data);
        }

        /// <summary>
        /// �I�y���[�V�������O�o��
        /// </summary>
        /// <param name="processName">��������</param>
        /// <param name="stepName">�����敪</param>
        /// <param name="data">�X�V���e</param>
        /// <remarks>
        /// <br>Note       : �����̓��e�ŃI�y���[�V�������O�ɑ��샍�O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteOperationLogProc(string processName, string stepName, string data)
        {
            const int LogDataMassageMaxLength = 500;
            const int LogOperationDataMaxLength = 80;

            try
            {
                OprtnHisLogWork writeParam = new OprtnHisLogWork();
                writeParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                writeParam.LogDataObjClassID = this.AssemblyId;
                writeParam.LogDataCreateDateTime = DateTime.Now;
                writeParam.LogDataKindCd = (int)LogDataKind.SystemLog;
                writeParam.LogDataObjAssemblyID = this.AssemblyId;
                writeParam.LogDataObjAssemblyNm = LogInfoAllCls.ApplicationName;
                writeParam.LogDataObjProcNm = processName;
                writeParam.LogOperationStatus = LogInfoAllCls.OperationStatusDefault;
                writeParam.LogDataMassage = stepName;
                if (!string.IsNullOrEmpty(stepName) && stepName.Length > LogDataMassageMaxLength)
                {
                    writeParam.LogDataMassage = stepName.Substring(0, LogDataMassageMaxLength);
                }
                writeParam.LogOperationData = data;
                if (!string.IsNullOrEmpty(data) && data.Length > LogOperationDataMaxLength)
                {
                    writeParam.LogDataMassage = data.Substring(0, LogOperationDataMaxLength);
                }

                // �R���o�[�g�Ώێ����o�b�N�A�b�v�����[�g�I�u�W�F�N�g�̎擾

                if (this.IConvertObjectDB == null)
                {
                    this.IConvertObjectDB = (IConvObjSingleBkDB)MediationConvObjSingleBkDB.GetConvObjSingleBkDB();
                }
                this.IConvertObjectDB.WriteOprtnHisLog(writeParam);
            }
            catch
            {
                // ��O
            }
        }
        #endregion

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
            ClcLogOutputProc(message);
        }

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
        private void ClcLogOutputProc(string message)
        {
            DateTime now = DateTime.Now;

            string logFileName = string.Empty;

            KICLC00001C.LogHeader log = null;

            try
            {
                // �o�͓��e�ɃV�X�e������t������B
                string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, GetSysInfo());

                // ���b�Z�[�W���̉��s�R�[�h���X�y�[�X�ɕϊ�
                logoutput = logoutput.Replace("\r", "").Replace("\n", " ");

                // ���O�t�@�C�����̍쐬
                // "PMCMN00160U_"+DateTime��Ticks+Guid������
                logFileName = string.Format(CLCLogFileName, now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData���փ��O�o��
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00160U", logFileName, logoutput);

            }
            catch
            {
            }
            finally
            {
            }
        }

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
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, LoginInfoAcquisition.EnterpriseCode));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, LOGOUTPUT_EXNA));
            }
            #endregion PC���擾

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
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ���O�o�͓��e�i�[
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
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
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, avaliableCapDisk));
                }
                else
                {
                    // ���O�o�͓��e�i�[
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ���O�o�͓��e�i�[
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_EXNA));
            }
            #endregion �f�B�X�N�g�p�ʎ擾

            return sysInfo.ToString();
        }
        #endregion // �V�X�e�����擾

        #endregion // CLC���O�o��

    }
}

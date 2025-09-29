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
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �e�������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �e�������̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvAcs
    {
        #region �� Private Members

        #endregion �� Private Members

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        // �p�����[�^
        /// </summary>
        private static EnvSurvAcsParam esap = null;

        /// <summary>
        // ����
        /// </summary>
        private static EnvSurvCommn esc = null;

        /// <summary>
        // �f�[�^�N���X
        /// </summary>
        private static EnvSurvDataParam esdp = null;

        /// <summary>
        /// �����������[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
        /// </summary>
        private static IEnvSurvObjDB iesod = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        # region �� Constructor

        /// <summary>
        /// �e�������A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�������A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvAcs()
        {
            try
            {
                // �p�����[�^
                esap = new EnvSurvAcsParam();

                // ���ʃN���X
                esc = new EnvSurvCommn();

                // �f�[�^�p�����[�^
                esdp = new EnvSurvDataParam();

                // �R���o�[�g�Ώێ����X�V�����[�g�I�u�W�F�N�g
                iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
            }
        }

        #endregion �� Constructor

        #region �� Public Methods

        #region �e���������O�o��

        /// <summary>
        /// �e���������O�o��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public int GetEnvSurvInfoLogOutput()
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            string logOutputMsg = string.Empty;

            try
            {
                // PC�����擾
                if (GetMachineNameInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // �V�X�e���`�Ԃ��擾
                if (GetSystemFormInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // CPU�g�p�����擾
                if (GetCpuUsageInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // �������g�p��/�e�ʂ��擾
                if (GetMemUsageCapInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // �f�B�X�N�g�p��/�e�ʂ��擾
                if (GetDiskUsageCapInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // �S�̃o�b�N�A�b�v�����擾
                if (GetFullBackupInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // ���i�}�X�^�̌������擾
                if (GetMstCountInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }
                
                // CLC�T�[�o�փ��O�o��
                if (ClcLogOutput(esdp.LogOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {

                }

                status = (int)EnvSurvAcsParam.StatusCode.Normal;
            }
            catch
            {
                status = (int)EnvSurvAcsParam.StatusCode.ExError;
            }

            return status;
        }

        #endregion // �e���������O�o��

        #endregion // �� Public Methods

        #region �� Private Methods

        #region PC�����擾����

        /// <summary>
        /// PC�����擾����B
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PC�����擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMachineNameInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string pcmn = string.Empty;

            int retryCnt = 0;

            // �擾����
            if (esap.MachineNameInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // PC���擾
                        pcmn = Environment.MachineName;

                        if (!String.IsNullOrEmpty(pcmn))
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, pcmn);
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetMachineNameExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMachineNameInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // PC�����擾����

        #region �V�X�e���`�Ԃ��擾����

        /// <summary>
        /// �X�^���h�A�����AC/S�𔻒�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �V�X�e���`�Ԃ��擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetSystemFormInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            RegistryKey registryKey = null;

            int retryCnt = 0;

            // �擾����
            if (esap.SystemFormInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // �N���C�A���g���W�X�g���擾
                        registryKey = esc.GetRegistryKeyClient();
                        if (registryKey != null)
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_SA);
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_CS);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetSystemFormExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetSystemFormInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal || status == (int)EnvSurvAcsParam.StatusCode.NotFound)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }
            
            return status;
        }

        #endregion // �V�X�e���`�Ԃ��擾����

        #region CPU�g�p�����擾����

        /// <summary>
        /// CPU�g�p�����擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : CPU�g�p�����擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetCpuUsageInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string cpuUsage = string.Empty;

            int retryCnt = 0;

            // �擾����
            if (esap.CpuUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // CPU�g�p���擾
                        cpuUsage = esc.GetCpuCounter();
                        if (!String.IsNullOrEmpty(cpuUsage))
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, cpuUsage);
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetCpuUsageExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetCpuUsageInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // CPU�g�p�����擾����

        #region �������g�p��/�e�ʂ��擾����

        /// <summary>
        /// �������g�p��/�e�ʂ��擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������g�p��/�e�ʂ��擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMemUsageCapInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string memUsageCap = string.Empty;

            int retryCnt = 0;

            // �擾����
            if (esap.MemUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // �������g�p��/�e��
                        memUsageCap = string.Format("{0}/{1}", esc.GetAvaliableMemory(), esc.GetTotalMemory());
                        if (!String.IsNullOrEmpty(memUsageCap))
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, memUsageCap);
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetMemUsageCapExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMemUsageCapInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // �������g�p��/�e�ʂ��擾����

        #region �f�B�X�N�g�p��/�e�ʂ��擾����

        /// <summary>
        /// �f�B�X�N�g�p��/�e�ʂ��擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �f�B�X�N�g�p��/�e�ʂ��擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDiskUsageCapInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string diskUsageCap = string.Empty;

            int retryCnt = 0;

            // �擾����
            if (esap.DiskUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // �f�B�X�N�g�p��/�e��
                        diskUsageCap = esc.GetAvaliableCapDisk();
                        if (!String.IsNullOrEmpty(diskUsageCap))
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, diskUsageCap);
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetDiskUsageCapExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetDiskUsageCapInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // �f�B�X�N�g�p��/�e�ʂ��擾����

        #region �S�̃o�b�N�A�b�v�����擾����

        /// <summary>
        /// �S�̃o�b�N�A�b�v�����擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�̃o�b�N�A�b�v�����擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetFullBackupInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            object envFullBackupInfObj;

            int retryCnt = 0;

            // �擾����
            if (esap.FullBackupInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        if (iesod == null)
                        {
                            // �R���o�[�g�Ώێ����X�V�����[�g�I�u�W�F�N�g
                            iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();
                        }

                        // 
                        status = iesod.EnvFullBackupInfSearch(out envFullBackupInfObj);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {

                            foreach (EnvFullBackupInfWork envFullBackupInfWork in (ArrayList)envFullBackupInfObj)
                            {
                                // ���O�o�͓��e�i�[
                                logOutputMsg = string.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP
                                    ,envFullBackupInfWork.DatabaseName
                                    ,envFullBackupInfWork.PhysicalDeviceName
                                    ,envFullBackupInfWork.BackupStartDate
                                    ,envFullBackupInfWork.BackupFinishDate
                                    ,envFullBackupInfWork.BackupSize
                                    ,envFullBackupInfWork.BackupType
                                    ,envFullBackupInfWork.MachineName
                                    ,envFullBackupInfWork.ServerName
                                    );
                            }
                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // 0���̏ꍇ������
                            // ���͂Ȃ����߁uNA�v�Ƃ���
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR, EnvSurvAcsParam.LOGOUTPUT_NA);
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR ,EnvSurvAcsParam.LOGOUTPUT_NA);
                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.Error;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR ,EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetFullBackupExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetFullBackupInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal || status == (int)EnvSurvAcsParam.StatusCode.NotFound)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // �S�̃o�b�N�A�b�v�����擾����

        #region �}�X�^�������擾����

        /// <summary>
        /// �}�X�^�������擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�������擾���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMstCountInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string mstCountInfo = string.Empty;
            int mstCount = 0;

            int retryCnt = 0;

            // �擾����
            if (esap.TableCntInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        if (iesod == null)
                        {
                            // �R���o�[�g�Ώێ����X�V�����[�g�I�u�W�F�N�g
                            iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();
                        }

                        // 
                        status = iesod.PriceMstInfCntSearch(out mstCount);
                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, mstCount.ToString());

                            // ����
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ���O�o�͓��e�i�[
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, EnvSurvAcsParam.LOGOUTPUT_NA);

                            // �擾�ł��Ȃ�
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ���O�o�͓��e�i�[
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, EnvSurvAcsParam.LOGOUTPUT_EXNA);

                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.GetMstCountExError;
                        // �G���[���O�o��
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMstCountInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �擾���Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // �}�X�^�������擾����

        #region CLC�T�[�o�փ��O�o�͂���

        /// <summary>
        /// CLC�T�[�o�փ��O�o�͂���
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : CLC�T�[�o�փ��O�o�͂���B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int ClcLogOutput(string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            string message = string.Empty;

            int retryCnt = 0;

            // �擾����
            if (esap.ClcLogOutputInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= esap.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        esc.ClcLogOutput(logOutputMsg);
                        // ����
                        status = (int)EnvSurvAcsParam.StatusCode.Normal;
                    }
                    catch
                    {
                        // ��O�G���[
                        status = (int)EnvSurvAcsParam.StatusCode.ClcLogOutputExError;
                    }
                    finally
                    {
                        // ������
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // �ݒ肵�Ȃ�
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // CLC�T�[�o�փ��O�o�͂���

        #endregion �� Private Methods
    }
}

using System;

using NUnit.Framework;

using System.Configuration;

using Broadleaf.Library.Resources;
using Broadleaf.ServiceProcess;

using System.ServiceProcess;

namespace System.ServiceProcess.ServiceBase
{

    [TestFixture]
    public class SFCMN01001SANUTEST : Tbs001ServerService
    {

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        /// <summary>
        /// �����FStartServicePMTaskScheduler �G���[�n�m�F
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_ERROR,
        /// 01 ���W�X�g���iSOFTWARE\Broadleaf\Service\Partsman\USER_AP�j�폜�ŁuPartsman.NS Task Scheduler�v�T�[�r�X�N�����Ȃ��@�E�E�E�@�T�[�r�X�N�����Ȃ��A�G���[�I��
        /// </summary>
        [Test(Description = "StartServicePMTaskScheduler �G���[�n�m�F")]
        public void StartServicePMTaskScheduler_ERROR()
        {
            try
            {
                StartServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FStartServicePMTaskScheduler ����n�m�F
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// 01 �T�[�r�X�Ȃ��A���W�X�g�������A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 02 �T�[�r�X�Ȃ��A���W�X�g���L��A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 03 �T�[�r�X����A���W�X�g�������A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 04 �T�[�r�X����A���W�X�g�������A�T�[�r�X�N���@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 05 �T�[�r�X����A���W�X�g���L��A�T�[�r�X��~�@�E�E�E�@�T�[�r�X�N������A����I��
        /// 06 �T�[�r�X����A���W�X�g���L��A�T�[�r�X�N���@�E�E�E�@�T�[�r�X�N���̂܂܁A����I��
        /// </summary>
        [Test(Description = "StartServicePMTaskScheduler ����n�m�F")]
        public void StartServicePMTaskScheduler_NORMAL()
        {
            try
            {
                StartServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FStopServicePMTaskScheduler �G���[�n�m�F
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_ERROR,
        /// 01 OnStop�C�x���g���ɗ�O����������
        /// </summary>
        [Test(Description = "StopServicePMTaskScheduler �G���[�n�m�F")]
        public void StopServicePMTaskScheduler_ERROR()
        {
            try
            {
                StopServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FStopServicePMTaskScheduler ����n�m�F
        /// ���ʁFstatus = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// 01 �T�[�r�X�Ȃ��A���W�X�g�������A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 02 �T�[�r�X�Ȃ��A���W�X�g���L��A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 03 �T�[�r�X����A���W�X�g�������A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 04 �T�[�r�X����A���W�X�g�������A�T�[�r�X�N���@�E�E�E�@�T�[�r�X�N���̂܂܁A����I��
        /// 05 �T�[�r�X����A���W�X�g���L��A�T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂܁A����I��
        /// 06 �T�[�r�X����A���W�X�g���L��A�T�[�r�X�N���@�E�E�E�@�T�[�r�X��~����A����I��
        /// </summary>
        [Test(Description = "StopServicePMTaskScheduler ����n�m�F")]
        public void StopServicePMTaskScheduler_NORMAL()
        {
            try
            {
                StopServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FChkServiceStartMode �G���[�n�m�F
        /// ���ʁFstatus = false
        /// 01 ���W�X�g�������@�E�E�E�@�T�[�r�X�N���s�ifalse�j
        /// 02 ���W�X�g���L��A������Ȃ��@�E�E�E�@�T�[�r�X�N���s�ifalse�j
        /// 03 ���W�X�g���L��A�����񂠂�A�X�^�[�g�A�b�v�̎�ށF�����@�E�E�E�@�T�[�r�X�N���s�ifalse�j
        /// </summary>
        [Test(Description = "ChkServiceStartMode �G���[�n�m�F")]
        public void ChkServiceStartMode_ERROR()
        {
            try
            {
                Boolean status = ChkServiceStartMode("Partsman.NS Task Scheduler");

                Assert.AreEqual(status, false);
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FChkServiceStartMode ����n�m�F
        /// ���ʁFstatus = true
        /// 01 ���W�X�g������A�����񂠂�A�X�^�[�g�A�b�v�̎�ށF�蓮�@�E�E�E�@�T�[�r�X�N���\�itrue�j
        /// 02 ���W�X�g������A�����񂠂�A�X�^�[�g�A�b�v�̎�ށF�����@�E�E�E�@�T�[�r�X�N���\�itrue�j
        /// </summary>
        [Test(Description = "ChkServiceStartMode ����n�m�F")]
        public void ChkServiceStartMode_NORMAL()
        {
            try
            {
                Boolean status = ChkServiceStartMode("Partsman.NS Task Scheduler");

                Assert.AreEqual(status, true);
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FOnStart �N���m�F
        /// ���ʁFtrue
        /// 01 �T�[�r�X�N���@�E�E�E�@�T�[�r�X�N���̂܂�
        /// 02 �T�[�r�X��~�@�E�E�E�@�T�[�r�X�N������
        /// </summary>
        [Test(Description = "OnStart �N���m�F")]
        public void OnStart_EXEC()
        {
            try
            {
                OnStart(null);
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FOnStop �N���m�F
        /// ���ʁFtrue
        /// 01 �T�[�r�X�N���@�E�E�E�@�T�[�r�X��~����
        /// 02 �T�[�r�X��~�@�E�E�E�@�T�[�r�X��~�̂܂�
        /// </summary>
        [Test(Description = "OnStop �N���m�F")]
        public void OnStop_EXEC()
        {
            try
            {
                OnStop();
            }
            finally
            {
            }
        }

        /// <summary>
        /// �����FReadLsmCheckFile ����n�m�F
        /// �f�t�H���g�l�FLsmCheckInterval(�Ď��Ԋu)=5���ALsmStartTime(����N������)="21:00"
        /// 01 SFCMN01001S_LsmCheckInfo.XML�Ȃ���OK
        /// 02 SFCMN01001S_LsmCheckInfo.XML����A�ݒ�l���f�t�H���g�l��OK
        /// 02 SFCMN01001S_LsmCheckInfo.XML����A�ݒ�l���f�t�H���g�l��NG
        /// </summary>
        [Test(Description = "ReadLsmCheckFile ����n�m�F")]
        public void ReadLsmCheckFile_NORMAL()
        {
            try
            {
                LsmServiceCheckInfo lsmServiceCheckInfo = new LsmServiceCheckInfo();
                ReadLsmCheckFile(ref lsmServiceCheckInfo);

                Assert.AreEqual(5,lsmServiceCheckInfo.LsmCheckInterval);
                Assert.AreEqual(21, lsmServiceCheckInfo.LsmStartTime_HH);
                Assert.AreEqual(00, lsmServiceCheckInfo.LsmStartTime_mm);
            }
            finally
            {
            }
        }

    }
}

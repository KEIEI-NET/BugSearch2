//****************************************************************************//
// �V�X�e��         : NS�ҋ@����
// �v���O��������   : NS�ҋ@�����R���t�B�O
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
//#define _USING_TEST_SENDER_ // �e�X�g�p���M�����A�v�����g�p����t���O�i���ʏ�͖����Ƃ��邱�Ɓj

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// NS�ҋ@�����̃R���t�B�O�N���X
    /// </summary>
    public sealed class SCMSendingDataWatcherConfig
    {
        #region SCM�S�̐ݒ�

        /// <summary>SCM�S�̐ݒ�</summary>
        private SCMTtlSt _scmTotalSetting;
        /// <summary>SCM�S�̐ݒ���擾���܂��B</summary>
        private SCMTtlSt SCMTotalSetting
        {
            get
            {
                if (_scmTotalSetting == null)
                {
                    SCMTotalSettingAgent scmTotalSettingDB = new SCMTotalSettingAgent();
                    {
                        SCMTtlSt scmTtlSt = scmTotalSettingDB.Find(
                            LoginInfoAcquisition.EnterpriseCode,
                            LoginInfoAcquisition.Employee.BelongSectionCode
                        );
                        if (
                            scmTtlSt != null
                                && !string.IsNullOrEmpty(scmTtlSt.EnterpriseCode.Trim())
                                && !string.IsNullOrEmpty(scmTtlSt.SectionCode.Trim())
                                && scmTtlSt.LogicalDeleteCode.Equals(0)
                        )
                        {
                            _scmTotalSetting = scmTtlSt;
                        }
                    }
                }
                return _scmTotalSetting;
            }
        }

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        public string EnterpriseCode
        {
            get { return SCMTotalSetting.EnterpriseCode; }
        }

        /// <summary>
        /// ���_�R�[�h���擾���܂��B
        /// </summary>
        public string SectionCode
        {
            get { return SCMTotalSetting.SectionCode; }
        }

        #endregion // SCM�S�̐ݒ�

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMSendingDataWatcherConfig() { }

        #endregion // Constructor

        /// <summary>
        /// �Ď��ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// SCM�S�̐ݒ�}�X�^.���V�X�e���A�g�敪 == �u1:����v
        /// AND
        /// SCM�S�̐ݒ�}�X�^.���V�X�e���A�g�t�H���_ != ""
        /// </returns>
        public bool CanWatch()
        {
            // SCM�S�̐ݒ�}�X�^����p�X�̐ݒ���s��
            if (SCMTotalSetting != null)
            {
                // ���V�X�e���A�g�敪���u1:����(PM7SP)�v ��0:���Ȃ�(PM.NS)
                if (
                    SCMTotalSetting.OldSysCooperatDiv.Equals(1)
                        &&
                    !string.IsNullOrEmpty(SCMTotalSetting.OldSysCoopFolder.Trim())
                )
                {
                    return Directory.Exists(SCMTotalSetting.OldSysCoopFolder);
                }
            }
            return false;
        }

        /// <summary>
        /// ���M�f�[�^�t�H���_�p�X���擾���܂��B
        /// </summary>
        /// <returns>
        /// SCM�S�̐ݒ�}�X�^.���V�X�e���A�g�p�t�H���_ + "Send"
        /// (��SCM�S�̐ݒ�}�X�^.���V�X�e���A�g�敪���u0:���Ȃ��v�ꍇ�A<c>string.Empty</c>��Ԃ��܂�)
        /// </returns>
        public string GetSendingDataFolderPath()
        {
            // SCM�S�̐ݒ�}�X�^����p�X�̐ݒ���s��
            if (SCMTotalSetting != null)
            {
                // ���V�X�e���A�g�敪���u1:����(PM7SP)�v ��0:���Ȃ�(PM.NS)
                if (SCMTotalSetting.OldSysCooperatDiv.Equals(1))
                {
                    return SCMConfig.GetSCMSendingDataPath(SCMTotalSetting);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// �Ď����閼�̂̃t�B���^���擾���܂��B
        /// </summary>
        public string WatchingNameFilter
        {
            get
            {
                return "ScmSdRvDt00.xml";   // ��PM7�ł́ASCM�󒍃f�[�^���Ō�ɏo�͂��Ă���
            }
        }

        /// <summary>
        /// ���M�������s���A�v���P�[�V���������擾���܂��B
        /// </summary>
        public string SendingAppName
        {
            get
            {
            #if _USING_TEST_SENDER_
                return "SCMSenderProxy.exe";
            #else
                return "PMSCM01100U.exe";
            #endif
            }
        }

        /// <summary>
        /// �R�}���h���C���������擾���܂��B
        /// </summary>
        /// <returns>"/B " + ���M�f�[�^�t�H���_�p�X</returns>
        public string GetCommandLineArg()
        {
            return "/B " + GetSendingDataFolderPath();
        }
    }
}

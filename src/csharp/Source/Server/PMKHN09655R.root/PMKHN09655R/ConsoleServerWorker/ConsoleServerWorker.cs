//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    static class ConsoleServerWorker
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            CampaignTargetUDB _campaignTargetUDB = new CampaignTargetUDB();

            Console.ReadLine();
        }
    }
}
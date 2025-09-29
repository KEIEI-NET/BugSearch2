//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^
// �v���O�����T�v   : ���R�����^���}�X�^��DB���삵�܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    /// <summary>
    /// ���R�����^���}�X�^DB���쏈��
    /// </summary>
    /// <remarks>
    /// Note       : ���R�����^���}�X�^DB���쏈���ł��B</br>
    /// Programmer : �я���</br>
    /// Date       : 2010/04/30</br>
    /// </remarks>
    class Program
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "�T�[�o�[���O�C���^�������̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B", null, -8);
            }

            IFreeSearchModelDB freeSearchModelDB = new FreeSearchModelDB();
            Console.ReadLine();
        }
    }
}

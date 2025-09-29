//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^
// �v���O�����T�v   : ���R�������i�}�X�^���������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
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
    /// ���R�������i�}�X�^��������
    /// </summary>
    /// <remarks>
    /// Note       : ���R�������i�}�X�^���������ł��B<br />
    /// Programmer : ���`<br />
    /// Date       : 2010/04/30<br />
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
                // WriteErrorLog(this.ServiceName, "OnStart", "�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B", null, -8);
            }

            IFreeSearchPartsDB freeSearchPartsDB = new FreeSearchPartsDB();
            Console.ReadLine();
        }
    }
}

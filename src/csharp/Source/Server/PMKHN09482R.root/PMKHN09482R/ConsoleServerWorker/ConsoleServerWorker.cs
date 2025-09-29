using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServerWorker
{
    /// <summary>
    /// Class1 �̊T�v�̐����ł��B
    /// </summary>
    class Class1
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            Console.WriteLine("�|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j - Debug");
#else
            Console.WriteLine("�|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j  - Release");
#endif

            RateProtyMngPatternDB _rateProtyMngPatternDB = new RateProtyMngPatternDB();
			Console.ReadLine();
        }
    }
}

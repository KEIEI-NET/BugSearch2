using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    /// <summary>
    /// ConsoleServerWorker �̊T�v�̐����ł��B
    /// </summary>
    public class ConsoleServerWorker
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            Console.WriteLine("�݌ɗ������݌ɐ��ݒ� - Debug");
#else
            Console.WriteLine("�݌ɗ������݌ɐ��ݒ� - Release");
#endif

            StockHistoryUpdateDB stockHistoryUpdateDB = new StockHistoryUpdateDB();
            Console.ReadLine();
        }
    }
}

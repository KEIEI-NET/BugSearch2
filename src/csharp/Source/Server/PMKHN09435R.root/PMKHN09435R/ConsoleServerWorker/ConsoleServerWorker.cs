using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

            SaleRateDB _saleRateDB = new SaleRateDB();

            Console.ReadLine();
        }
    }
}
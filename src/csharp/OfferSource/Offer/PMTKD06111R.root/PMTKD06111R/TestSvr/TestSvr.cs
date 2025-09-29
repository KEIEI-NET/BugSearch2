using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace ConsoleServer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //�T�[�o�[���O�C�����i����
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP))
            {
                Console.WriteLine("�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B");
            }

            //CarModelSearchDB _CarModelSearch = new CarModelSearchDB();
            Console.ReadLine();
        }
    }
}

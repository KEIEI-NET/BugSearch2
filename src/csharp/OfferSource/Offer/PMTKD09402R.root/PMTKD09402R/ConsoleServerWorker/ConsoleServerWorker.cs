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
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //�T�[�o�[���O�C�����i����
            Console.WriteLine( "ServerLoginInfoAcquisition calling" );
            if (!ServerLoginInfoAcquisition.Initialize( ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP ))
            {
                Console.WriteLine( "ServerLoginInfoAcquisition.Initialize �G���[" );
            }

            OfferPrmPartsBrcdInfoDB offerPrmPartsBrcdDB = new OfferPrmPartsBrcdInfoDB();
            Console.ReadLine();
        }
    }
}

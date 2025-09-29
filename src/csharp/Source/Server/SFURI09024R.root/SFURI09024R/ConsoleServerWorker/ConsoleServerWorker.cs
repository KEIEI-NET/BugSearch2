using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;

//2006.12.06 added by T-Kidate
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

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
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile , false);

            /* 2006.12.06 added by T-Kidate
             * �y�K�{�z
             * ConsoleServerWorker �ɕK�v�ȋL�q */
            Console.WriteLine("ServerLoginInfoAcquisition calling");
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                Console.WriteLine("ServerLoginInfoAcquisition.Initialize �G���[");
            }

			SlipPrtSetDB slipprtsetDB = new SlipPrtSetDB();
			Console.ReadLine();
		}
	}
}

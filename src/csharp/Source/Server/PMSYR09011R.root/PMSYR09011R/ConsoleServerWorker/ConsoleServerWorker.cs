using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using Broadleaf.Application.Remoting;
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
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            Console.WriteLine("�ԗ��Ǘ��}�X�^ - Debug");
#else
            Console.WriteLine("�ԗ��Ǘ��}�X�^ - Release");
#endif

            CarManagementDB carmanagementDB = new CarManagementDB();
			Console.ReadLine();
		}
	}
}

using System;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsoleServer
{
	class Program
	{
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
			FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
			//�T�[�o�[���O�C�����i����
			if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
			{
				Console.WriteLine("�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B");
			}
# if DEBUG
            Console.WriteLine( "���R���[�󎚈ʒu�ݒ� DEBUG" );
# endif
			Console.ReadLine();
		}
	}
}

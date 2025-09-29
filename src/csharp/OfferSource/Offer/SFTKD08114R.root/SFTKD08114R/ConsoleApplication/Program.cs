using System;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
			PrtItemSetDB prtItemSetDB = new PrtItemSetDB();
			//�T�[�o�[���O�C�����i����
			if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP))
			{
				Console.WriteLine("�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B");
			}

			Console.ReadLine();
		}
	}
}

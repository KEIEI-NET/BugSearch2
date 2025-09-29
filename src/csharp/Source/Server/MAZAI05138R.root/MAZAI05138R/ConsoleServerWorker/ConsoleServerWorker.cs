using System;
using System.Runtime.Remoting;
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
            InventoryDataUpdateDB inventoryDataUpdateDB = new InventoryDataUpdateDB();
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B", null, -8);
            }
            Console.ReadLine();
		}
	}
}

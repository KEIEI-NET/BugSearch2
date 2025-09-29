using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace AddressInfoServer
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
            RemotingConfiguration.Configure( AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false );


            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP);

			//�����[�g�I�u�W�F�N�g�쐬
			OfferAddressInfoDB oaid = new OfferAddressInfoDB();
			Console.ReadLine();
		}
	}
}

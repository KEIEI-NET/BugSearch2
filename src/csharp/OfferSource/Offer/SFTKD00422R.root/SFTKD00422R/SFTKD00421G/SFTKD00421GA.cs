using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// �����[�g�I�u�W�F�N�g����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferAddressInfo
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MediationOfferAddressInfo()
		{
		}
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�擾
		/// </summary>
		/// <returns></returns>
		public static IOfferAddressInfo GetOfferAddressInfo()
		{
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
			//�񋟃f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾

            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IOfferAddressInfo)Activator.GetObject(typeof(IOfferAddressInfo),string.Format("{0}/OfferAddressInfo",wkStr));
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}
		
	}
}

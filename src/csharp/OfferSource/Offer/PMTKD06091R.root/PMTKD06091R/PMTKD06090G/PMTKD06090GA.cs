using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���i���擾�R���g���[���擾DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IClgPrmPartsInfoSearchDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationClgPrmPartsInfoSearchDB
	{
		/// <summary>
		/// IClgPrmPartsInfoSearchDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 99033�@��{�@�E</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MediationClgPrmPartsInfoSearchDB()
		{
		}
		
		/// <summary>
		/// IClgPrmPartsInfoSearchDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IOfferWorkInfo�I�u�W�F�N�g</returns>
		public static IClgPrmPartsInfoSearchDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			return (IClgPrmPartsInfoSearchDB)Activator.GetObject(typeof(IClgPrmPartsInfoSearchDB),
				string.Format("{0}/MyAppClgPrmPartsInfoSearch", wkStr));
		}
	}
}

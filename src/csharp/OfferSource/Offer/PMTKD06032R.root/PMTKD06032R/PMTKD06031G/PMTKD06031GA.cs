using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �D��BL�R�[�h�������R���g���[���擾DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IOfferPrimeBlSearchDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferPrimeBlSearchDB
	{
		/// <summary>
        /// �D��BL�R�[�h�������R���g���[���擾DB����N���X�R���X�g���N�^
		/// </summary>
		public MediationOfferPrimeBlSearchDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfo�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IOfferWorkInfo�I�u�W�F�N�g</returns>
		public static IOfferPrimeBlSearchDB GetOfferPrimeBlSearchDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif

            return (IOfferPrimeBlSearchDB)Activator.GetObject(typeof(IOfferPrimeBlSearchDB), string.Format("{0}/MyAppOfferPrimeBlSearch", wkStr));
		}
	}
}

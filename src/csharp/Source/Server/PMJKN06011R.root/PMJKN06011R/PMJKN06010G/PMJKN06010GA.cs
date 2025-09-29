using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �������i���擾DB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFreeSearchPartsSearchDB
	{
		/// <summary>
		/// CompanyInfDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// </remarks>
        public MediationFreeSearchPartsSearchDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfo�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IOfferPartsInfo�I�u�W�F�N�g</returns>
        public static IFreeSearchPartsSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9011";
#endif
            return (IFreeSearchPartsSearchDB)Activator.GetObject( typeof( IFreeSearchPartsSearchDB ), string.Format( "{0}/MyAppFreeSearchPartsSearch", wkStr ) );
        }

	}
}

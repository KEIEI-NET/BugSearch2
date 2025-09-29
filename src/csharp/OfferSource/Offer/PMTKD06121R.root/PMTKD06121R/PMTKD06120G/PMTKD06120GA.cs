using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyInfDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IOfferPrimePartsInfDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 96186�@���ԁ@�T��</br>
	/// <br>Date       : 2005.04.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationColTrmEquInfDB
	{
		/// <summary>
		/// CompanyInfDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 99033�@��{�@�E</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MediationColTrmEquInfDB()
		{
			
		}
		
		/// <summary>
		/// IOfferWorkInfo�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IOfferWorkInfo�I�u�W�F�N�g</returns>
		public static IColTrmEquInfDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";// LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#endif

			return (IColTrmEquInfDB)Activator.GetObject(typeof(IColTrmEquInfDB), string.Format("{0}/MyAppColTrmEquInf", wkStr));
		}
	}
}

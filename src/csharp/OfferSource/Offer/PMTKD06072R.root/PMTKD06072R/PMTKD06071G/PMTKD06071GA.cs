using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �ԗ���񌋍����R���g���[���擾DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ITBOSearchInfDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationTBOSearchInfDB
	{
		/// <summary>
        /// �ԗ���񌋍����R���g���[���擾DB����N���X�R���X�g���N�^
		/// </summary>
		public MediationTBOSearchInfDB()
		{
			
		}
		
		/// <summary>
        /// ITBOSearchInfDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ITBOSearchInfDB�I�u�W�F�N�g</returns>
        public static ITBOSearchInfDB GetTBOSearchInf()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            return (ITBOSearchInfDB)Activator.GetObject(typeof(ITBOSearchInfDB), string.Format("{0}/MyAppTBOSearchInf", wkStr));
		}
	}
}

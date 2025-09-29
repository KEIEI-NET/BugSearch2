using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���[�U�[�}�[�W����DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IOfferMerge�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferMergeDB
	{
		/// <summary>
        /// ���[�U�[�}�[�W����DB����N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.08</br>
		/// </remarks>
        public MediationOfferMergeDB()
		{
		}
		
		/// <summary>
        /// ISyncInfo�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ISyncInfo�I�u�W�F�N�g</returns>
        public static IOfferMerge GetRemoteObject()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "HTTP://10.30.20.73:9001";
            //wkStr = "HTTP://10.30.20.202:9001";
            wkStr = "http://localhost:9010";
#endif

            return (IOfferMerge)Activator.GetObject(typeof(IOfferMerge), string.Format("{0}/MyAppOfferMerge", wkStr));
		}
	}
}

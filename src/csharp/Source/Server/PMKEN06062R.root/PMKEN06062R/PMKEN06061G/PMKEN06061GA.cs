using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UsrJoinPartsSearchDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IUsrJoinPartsSearchDB�N���X�I�u�W�F�N�g��߂��܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUsrJoinPartsSearchDB
	{
		/// <summary>
		/// UsrJoinPartsSearchDB����N���X�R���X�g���N�^
		/// </summary>
		public MediationUsrJoinPartsSearchDB()
		{
			
		}
		
		/// <summary>
		/// IUsrJoinPartsSearchDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IUsrJoinPartsSearchDB�I�u�W�F�N�g</returns>
		public static IUsrJoinPartsSearchDB GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9011";
#endif
			return (IUsrJoinPartsSearchDB)Activator.GetObject(typeof(IUsrJoinPartsSearchDB), string.Format("{0}/MyAppUsrJoinPartsSearch", wkStr));
		}
	}
}

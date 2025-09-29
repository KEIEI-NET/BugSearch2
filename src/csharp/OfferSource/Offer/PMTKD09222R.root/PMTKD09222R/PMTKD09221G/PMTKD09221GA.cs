using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �񋟃}�[�W�Ώی���DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IMergeDataGet�N���X�I�u�W�F�N�g��߂��܂��B</br>
	/// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMergeDataGetDB
	{
		/// <summary>
        ///�񋟃}�[�W�Ώی���DB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.08.15</br>
		/// </remarks>
        public MediationMergeDataGetDB()
		{
			
		}
		
		/// <summary>
        /// IMergeDataGet�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IMergeDataGet�I�u�W�F�N�g</returns>
        public static IMergeDataGet GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            //wkStr = "HTTP://10.30.20.202:9002";
            //wkStr = "HTTP://10.30.30.119:9002";
            wkStr = "http://localhost:9002";
#endif

            return (IMergeDataGet)Activator.GetObject(typeof(IMergeDataGet), string.Format("{0}/MyAppMergeDataGet", wkStr));
		}
	}
}

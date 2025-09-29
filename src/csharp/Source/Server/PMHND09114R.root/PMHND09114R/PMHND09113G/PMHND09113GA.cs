using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// InspectTtlStDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IInspectTtlStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���InspectTtlStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 3H �k�P�N</br>
    /// <br>Date       : K2017/06/02</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationInspectTtlStDB
	{
		/// <summary>
		/// InspectTtlStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
		public MediationInspectTtlStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IInspectTtlStDB GetInspectTtlStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            //wkStr = "http://localhost:9001";  // dbg
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IInspectTtlStDB)Activator.GetObject(typeof(IInspectTtlStDB),string.Format("{0}/MyAppInspectTtlSt",wkStr));
		}
	}
}

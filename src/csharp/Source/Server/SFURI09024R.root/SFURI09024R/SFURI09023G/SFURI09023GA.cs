using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// SlipPrtSetDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ISlipPrtSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SlipPrtSetDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2005.07.21</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSlipPrtSetDB
	{
		/// <summary>
		/// SlipPrtSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public MediationSlipPrtSetDB()
		{
		}
		/// <summary>
		/// ISlipPrtSetDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>ISlipPrtSetDB�I�u�W�F�N�g</returns>
		public static ISlipPrtSetDB GetSlipPrtSetDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (ISlipPrtSetDB)Activator.GetObject(typeof(ISlipPrtSetDB),string.Format("{0}/MyAppSlipPrtSet",wkStr));
		}
	}
}

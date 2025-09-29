using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UserGdBdDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IUserGdBdDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UserGdBdDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUserGdBdDB
	{
		/// <summary>
		/// UserGdBdDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationUserGdBdDB()
		{
		}
		/// <summary>
		/// IUserGdBdDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IUserGdBdDB�I�u�W�F�N�g</returns>
		/// <br>Note       : IUserGdBdDB�C���^�[�t�F�[�X���擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public static IUserGdBdDB GetUserGdBdDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IUserGdBdDB)Activator.GetObject(typeof(IUserGdBdDB),string.Format("{0}/MyAppUserGdBd",wkStr));
		}
	}
}

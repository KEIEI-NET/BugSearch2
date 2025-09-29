using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// UserGdBdUDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IUserGdBdUDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UserGdBdUDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationUserGdBdUDB
	{
		/// <summary>
		/// UserGdBdUDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationUserGdBdUDB()
		{
		}
		/// <summary>
		/// IUserGdBdUDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IUserGdBdUDB�I�u�W�F�N�g</returns>
		/// <br>Note       : IUserGdBdUDB�C���^�[�t�F�[�X���擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public static IUserGdBdUDB GetUserGdBdUDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IUserGdBdUDB)Activator.GetObject(typeof(IUserGdBdUDB),string.Format("{0}/MyAppUserGdBdU",wkStr));
		}
	}
}

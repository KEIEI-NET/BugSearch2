using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// MoneyKindDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IMoneyKindDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MoneyKindDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.04.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMoneyKindDB
	{
		/// <summary>
		/// MoneyKindDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.06</br>
		/// </remarks>
		public MediationMoneyKindDB()
		{
		}
		/// <summary>
		/// IMoneyKindDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IMoneyKindDB�I�u�W�F�N�g</returns>
		public static IMoneyKindDB GetMoneyKindDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IMoneyKindDB)Activator.GetObject(typeof(IMoneyKindDB),string.Format("{0}/MyAppMoneyKind",wkStr));
		}
	}
}

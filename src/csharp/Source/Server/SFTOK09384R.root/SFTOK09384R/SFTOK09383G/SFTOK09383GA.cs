using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// EmployeeDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IEmployeeDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���EmployeeDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 96137�@�R�c�@�\</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationEmployeeDB
	{
		/// <summary>
		/// EmployeeDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 96137�@�R�c�@�\</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public MediationEmployeeDB()
		{
		}
		/// <summary>
		/// IEmployeeDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IEmployeeDB�I�u�W�F�N�g</returns>
		public static IEmployeeDB GetEmployeeDB()
		{
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IEmployeeDB)Activator.GetObject(typeof(IEmployeeDB),string.Format("{0}/MyAppEmployee",wkStr));
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}
	}
}

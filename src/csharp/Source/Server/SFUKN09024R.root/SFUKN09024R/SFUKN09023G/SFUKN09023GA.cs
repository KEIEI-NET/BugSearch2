using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyNmDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ICompanyNmDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CompanyNmDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2005.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCompanyNmDB
	{
		/// <summary>
		/// CompanyNmDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public MediationCompanyNmDB()
		{
		}
		/// <summary>
		/// ICompanyNmDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>ICompanyNmDB�I�u�W�F�N�g</returns>
		public static ICompanyNmDB GetCompanyNmDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (ICompanyNmDB)Activator.GetObject(typeof(ICompanyNmDB),string.Format("{0}/MyAppCompanyNm",wkStr));
		}
	}
}

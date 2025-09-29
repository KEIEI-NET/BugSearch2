using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// BillPrtStDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IBillPrtStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���BillPrtStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.07.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationBillPrtStDB
	{
		/// <summary>
		/// BillPrtStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		/// </remarks>
		public MediationBillPrtStDB()
		{
		}
		/// <summary>
		/// IBillPrtStDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IBillPrtStDB�I�u�W�F�N�g</returns>
		public static IBillPrtStDB GetBillPrtStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IBillPrtStDB)Activator.GetObject(typeof(IBillPrtStDB),string.Format("{0}/MyAppBillPrtSt",wkStr));
		}
	}
}

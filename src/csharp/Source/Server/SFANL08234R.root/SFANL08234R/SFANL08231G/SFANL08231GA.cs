using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ� DB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IUpdateCustAccDmdRec�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���UpdateCustAccDmdRec��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22011�@�����@���l</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePrtPSetDLDB
	{
		/// <summary>
		/// UpdateCustAccDmdRec DB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22011�@�����@���l</br>
		/// <br>Date       : 2007.09.30</br>
		/// </remarks>
		public MediationFrePrtPSetDLDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IFrePrtPSetDLDB GetFrePrtPSetDLDB()
		{
//            string wkStr = "HTTP://localhost:8008";

			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:9001";
# endif 

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IFrePrtPSetDLDB)Activator.GetObject(typeof(IFrePrtPSetDLDB),string.Format("{0}/MyAppFrePrtPSetDL",wkStr));
		}
	}
}

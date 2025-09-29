using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// AutoAnsItemStDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IAutoAnsItemStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���AutoAnsItemStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 30745�@�g���@�F��</br>
	/// <br>Date       : 2012/10/25</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationAutoAnsItemStDB
	{
		/// <summary>
        /// AutoAnsItemStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// </remarks>
        public MediationAutoAnsItemStDB()
		{
		}
		/// <summary>
        /// IAutoAnsItemStDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IAutoAnsItemStDB�I�u�W�F�N�g</returns>
        public static IAutoAnsItemStDB GetAutoAnsItemStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IAutoAnsItemStDB)Activator.GetObject(typeof(IAutoAnsItemStDB), string.Format("{0}/MyAppAutoAnsItemSt", wkStr));
		}
	}
}

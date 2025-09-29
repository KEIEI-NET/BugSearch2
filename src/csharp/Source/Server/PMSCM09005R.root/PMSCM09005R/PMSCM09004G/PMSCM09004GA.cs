using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SCMPrtSettingDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ISCMPrtSettingDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SCMPrtSettingDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.04.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSCMPrtSettingDB
	{
		/// <summary>
        /// SCMPrtSettingDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 30350�@�N��@����</br>
		/// <br>Date       : 2009.04.27</br>
		/// </remarks>
        public MediationSCMPrtSettingDB()
		{
		}
		/// <summary>
        /// ISCMPrtSettingDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ISCMPrtSettingDB�I�u�W�F�N�g</returns>
        public static ISCMPrtSettingDB GetSCMPrtSettingDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISCMPrtSettingDB)Activator.GetObject(typeof(ISCMPrtSettingDB), string.Format("{0}/MyAppSCMPrtSetting", wkStr));
		}
	}
}

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// CreditMngListWorkDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ICreditMngListWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CreditMngListWorkDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2007.11.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationCreditMngListWorkDB
	{
		/// <summary>
        /// CreditMngListWorkDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
		/// </remarks>
        public MediationCreditMngListWorkDB()
		{
		}
		/// <summary>
        /// ICreditMngListWorkDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ICreditMngListWorkDB�I�u�W�F�N�g</returns>
        public static ICreditMngListWorkDB GetCreditMngListWorkDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICreditMngListWorkDB)Activator.GetObject(typeof(ICreditMngListWorkDB), string.Format("{0}/MyAppCreditMngListWork", wkStr));
		}
	}
}

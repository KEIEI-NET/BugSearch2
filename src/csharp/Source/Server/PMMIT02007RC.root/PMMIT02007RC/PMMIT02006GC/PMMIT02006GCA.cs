//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ʌ��Ϗ��E�I���\ 
// �v���O�����T�v   : ���Ӑ�ʌ��Ϗ��E�I���\ DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970531-00  �쐬�S�� : songg
// �� �� ��  K2013/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// TakekawaQuotaInventWorkDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ITakekawaQuotaInventWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TakekawaQuotaInventWorkDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : songg</br>
	/// <br>Date       : K2013/12/03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationTakekawaQuotaInventWorkDB
	{
		/// <summary>
        /// PaymentBalanceLedgerDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
		/// </remarks>
        public MediationTakekawaQuotaInventWorkDB()
		{
		}
		/// <summary>
        /// ITakekawaQuotaInventWorkDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ITakekawaQuotaInventWorkDB�I�u�W�F�N�g</returns>
        public static ITakekawaQuotaInventWorkDB GetTakekawaQuotaInventWorkDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITakekawaQuotaInventWorkDB)Activator.GetObject(typeof(ITakekawaQuotaInventWorkDB), string.Format("{0}/MyAppTakekawaQuotaInventWork", wkStr));
		}
	}
}

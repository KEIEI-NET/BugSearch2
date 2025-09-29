//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����b�Z�[�W�ݒ菈��
// �v���O�����T�v   : ���[�����b�Z�[�W�ݒ菈��DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PccMailDtDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPccMailDtDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PccMailDtDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccMailDtDB
    {
        /// <summary>
        /// PccMailDtDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public MediationPccMailDtDB()
        {
        }

		/// <summary>
        /// IPccMailDtDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPccMailDtDB�I�u�W�F�N�g</returns>
        public static IPccMailDtDB GetPccMailDtDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9006";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPccMailDtDB)Activator.GetObject(typeof(IPccMailDtDB), string.Format("{0}/MyAppPccMailDt", wkStr));
        }
    }
}

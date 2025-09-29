//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�i�ڃO���[�v�}�X�^�����e
// �v���O�����T�v   : PCC�i�ڃO���[�v�}�X�^�����eDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.07.20  �C�����e : �V�K�쐬
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
    /// PccItemGrpDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPccItemGrpDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PccItemGrpDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccItemGrpDB
    {
        /// <summary>
        /// PccItemGrpDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public MediationPccItemGrpDB()
        {
        }

		/// <summary>
        /// IPccItemGrpDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPccItemGrpDB�I�u�W�F�N�g</returns>
        public static IPccItemGrpDB GetPccItemGrpDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPccItemGrpDB)Activator.GetObject(typeof(IPccItemGrpDB), string.Format("{0}/MyAppPccItemGrp", wkStr));
        }
    }
}

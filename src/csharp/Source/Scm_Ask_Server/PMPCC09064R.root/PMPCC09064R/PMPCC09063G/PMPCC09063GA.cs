//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�L�����y�[���ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�L�����y�[���ݒ�}�X�^�����eDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.11  �C�����e : �V�K�쐬
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
    /// PccCpMsgStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPccCpMsgStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PccCpMsgStDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccCpMsgStDB
    {
        /// <summary>
        /// PccCpMsgStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public MediationPccCpMsgStDB()
        {
        }

		/// <summary>
        /// IPccCpMsgStDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPccCpMsgStDB�I�u�W�F�N�g</returns>
        public static IPccCpMsgStDB GetPccCpMsgStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
            //dbg start
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //dbg end
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPccCpMsgStDB)Activator.GetObject(typeof(IPccCpMsgStDB), string.Format("{0}/MyAppPccCpMsgSt", wkStr));
        }
    }
}

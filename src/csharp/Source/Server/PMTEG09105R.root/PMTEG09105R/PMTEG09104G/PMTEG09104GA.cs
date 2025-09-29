//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�f�[�^�����e�i���X
// �v���O�����T�v   : ��`�f�[�^�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ����`�f�[�^�}�X�^DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISecMngSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRcvDraftDataDB
    {
        /// <summary>
        /// ����`�f�[�^�}�X�^DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public MediationRcvDraftDataDB()
        {

        }

        /// <summary>
        /// IRcvDraftDataDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IRcvDraftDataDB�I�u�W�F�N�g</returns>
        public static IRcvDraftDataDB GetRcvDraftDataDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IRcvDraftDataDB)Activator.GetObject(typeof(IRcvDraftDataDB), string.Format("{0}/MyAppRcvDraftData", wkStr));
        }
    }

    /// <summary>
    /// �x����`�f�[�^�}�X�^DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISecMngSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br> 
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPayDraftDataDB
    {
        /// <summary>
        /// �x����`�f�[�^�}�X�^DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public MediationPayDraftDataDB()
        {

        }

        /// <summary>
        /// IPayDraftDataDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPayDraftDataDB�I�u�W�F�N�g</returns>
        public static IPayDraftDataDB GetPayDraftDataDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPayDraftDataDB)Activator.GetObject(typeof(IPayDraftDataDB), string.Format("{0}/MyAppPayDraftData", wkStr));
        }
    }
}

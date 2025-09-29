//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : �L�����y�[���}�X�^��� DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �L�����y�[���}�X�^��� DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICampaignMasterWorkDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CampaignMasterWorkDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignMasterWorkDB
    {
        /// <summary>
        /// �L�����y�[���}�X�^��� DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public MediationCampaignMasterWorkDB()
        {
        }

        /// <summary>
        /// ICampaignMasterWorkDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICampaignMasterWorkDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ICampaignMasterWorkDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public static ICampaignMasterWorkDB GetCampaignMasterWorkDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICampaignMasterWorkDB)Activator.GetObject(typeof(ICampaignMasterWorkDB), string.Format("{0}/MyAppCampaignMasterWork", wkStr));
        }
    }
}

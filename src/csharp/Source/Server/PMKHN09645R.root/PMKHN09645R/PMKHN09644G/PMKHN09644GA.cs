//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͎�M�f�[�^DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignGoodsStDB
    {
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public MediationCampaignGoodsStDB()
        {

        }

        /// <summary>
        /// ICampaignGoodsStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICampaignGoodsStDB�I�u�W�F�N�g</returns>
        public static ICampaignGoodsStDB GetCampaignGoodsStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICampaignGoodsStDB)Activator.GetObject(typeof(ICampaignGoodsStDB), string.Format("{0}/MyAppCampaignGoodsSt", wkStr));
        }
    }
}

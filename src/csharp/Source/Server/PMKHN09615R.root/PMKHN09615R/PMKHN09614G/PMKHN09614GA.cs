//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�������D��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[�������D��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
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
    /// CampaignPrcPrStDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICampaignPrcPrStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CampaignPrcPrStDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignPrcPrStDB 
    {
        /// <summary>
        /// ICampaignPrcPrStDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public MediationCampaignPrcPrStDB()
        {
        }
        /// <summary>
        /// ICampaignPrcPrStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISlipPrtSetDB�I�u�W�F�N�g</returns>
        public static ICampaignPrcPrStDB GetCampaignPrcPrStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICampaignPrcPrStDB)Activator.GetObject(typeof(ICampaignPrcPrStDB), string.Format("{0}/MyAppCampaignPrcPrSt", wkStr));
        }
    }
}

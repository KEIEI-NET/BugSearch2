//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CampaignRsltListResultDB ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ICampaignRsltListResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CampaignRsltListResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/05/19</br>
    /// <br></br>
    /// </remarks>
    public class MediationCampaignRsltListResultDB
    {
        /// <summary>
        /// CampaignRsltListResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2011/07/01 杍^</br>
        /// <br>           : PMKHN02056G�ɋL�ڃ~�X�̑Ή�</br>
        /// </remarks>
        public MediationCampaignRsltListResultDB()
        {
        }
        /// <summary>
        /// ICampaignRsltListResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ICampaignRsltListResultDB�I�u�W�F�N�g</returns>
        public static ICampaignRsltListResultDB GetCampaignRsltListResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            //return (ICampaignRsltListResultDB)Activator.GetObject(typeof(ICampaignRsltListResultDB), string.Format("{0}/MyAppCampaignstRsltListResultWork", wkStr));  // DEL 2011/07/01
            return (ICampaignRsltListResultDB)Activator.GetObject(typeof(ICampaignRsltListResultDB), string.Format("{0}/MyAppCampaignRsltListResult", wkStr));  // ADD 2011/07/01
        }
    }
}

//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �D��q�Ƀ}�X�^
// �v���O�����T�v   : �D��q�ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : huangt
// �� �� ��  K2013/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �D��q�Ƀ}�X�^�@DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IProtyWarehouseDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ProtyWarehouseDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationIProtyWarehouseDB
    {
        /// <summary>
        /// ProtyWarehouseDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public MediationIProtyWarehouseDB()
        {

        }

        /// <summary>
        /// IProtyWarehouseDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IProtyWarehouseDB�I�u�W�F�N�g</returns>
        public static IProtyWarehouseDB GetProtyWarehouseDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IProtyWarehouseDB)Activator.GetObject(typeof(IProtyWarehouseDB), string.Format("{0}/MyAppProtyWarehouse", wkStr));
        }
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����e
// �v���O�����T�v   : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����eDB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F�� 30745
// �� �� ��  2012/08/01  �C�����e : �V�K�쐬
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
    /// BLGoodsCdChgUDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IBLGoodsCdChgUDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���BLGoodsCdChgUDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �g�� �F�� 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBLGoodsCdChgUDB
    {
        /// <summary>
        /// BLGoodsCdChgUDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public MediationBLGoodsCdChgUDB()
        {
        }

        /// <summary>
        /// IBLGoodsCdChgUDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IBLGoodsCdChgUDB�I�u�W�F�N�g</returns>
        public static IBLGoodsCdChgUDB GetBLGoodsCdChgUDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IBLGoodsCdChgUDB)Activator.GetObject(typeof(IBLGoodsCdChgUDB), string.Format("{0}/MyAppBLGoodsCdChgU", wkStr));
        }
    }
}

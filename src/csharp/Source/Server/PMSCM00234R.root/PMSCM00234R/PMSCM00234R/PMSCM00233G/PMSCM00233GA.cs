//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�v�V�����Ǘ��}�X�^DB����N���X
// �v���O�����T�v   : �I�v�V�����Ǘ��}�X�^DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PMOptMngDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IIPMOptMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���IPMOptMngDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPMOptMngDB
    {
        /// <summary>
        /// PMOptMngDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        public MediationPMOptMngDB()
        {

        }

        /// <summary>
        /// IPMOptMngDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPMOptMngDB�I�u�W�F�N�g</returns>
        public static IPMOptMngDB GetPMOptMngDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPMOptMngDB)Activator.GetObject(typeof(IPMOptMngDB), string.Format("{0}/MyAppPMOptMng", wkStr));
        }
    }
}

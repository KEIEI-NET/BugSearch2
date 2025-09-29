//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMDBID�Ǘ��}�X�^DB����N���X
// �v���O�����T�v   : PMDBID�Ǘ��}�X�^DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IPmDbIdMngDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPmDbIdMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PmDbIdMngDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmDbIdMngDB
    {
        /// <summary>
        /// PmDbIdMngDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// </remarks>
        public MediationPmDbIdMngDB()
        {

        }

        /// <summary>
        /// IPmDbIdMngDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPmDbIdMngDB�I�u�W�F�N�g</returns>
        public static IPmDbIdMngDB GetPmDbIdMngDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9004";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPmDbIdMngDB)Activator.GetObject(typeof(IPmDbIdMngDB), string.Format("{0}/MyAppPmDbIdMng", wkStr));
        }
    }
}
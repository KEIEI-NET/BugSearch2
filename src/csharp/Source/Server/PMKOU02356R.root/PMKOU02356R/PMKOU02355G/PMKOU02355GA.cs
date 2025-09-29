//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\DB����N���X
// �v���O�����T�v   : IArrGoodsDiffResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ���׍��ٕ\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IArrGoodsDiffResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MediationArrGoodsDiffResultDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class MediationArrGoodsDiffResultDB
    {
        /// <summary>
        /// MediationArrGoodsDiffResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public MediationArrGoodsDiffResultDB()
        {
        }
        /// <summary>
        /// IArrGoodsDiffResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IArrGoodsDiffResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IArrGoodsDiffResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public static IArrGoodsDiffResultDB GetArrGoodsDiffResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9011";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IArrGoodsDiffResultDB)Activator.GetObject(typeof(IArrGoodsDiffResultDB), string.Format("{0}/MyAppArrGoodsDiffResult", wkStr));
        }
    }
}

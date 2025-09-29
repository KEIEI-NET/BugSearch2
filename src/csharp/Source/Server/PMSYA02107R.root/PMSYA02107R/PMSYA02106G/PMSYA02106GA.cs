//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�\DB����N���X
// �v���O�����T�v   : IMonthCarInspectListResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
    /// �����Ԍ��ԗ��ꗗ�\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IMonthCarInspectListResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MonthCarInspectListResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �L�Q</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class MediationMonthCarInspectListResultDB
    {
        /// <summary>
        /// MediationMonthCarInspectListResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MediationMonthCarInspectListResultDB()
        {
        }
        /// <summary>
        /// IMonthCarInspectListResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IMonthCarInspectListResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IMonthCarInspectListResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public static IMonthCarInspectListResultDB GetMonthCarInspectListResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IMonthCarInspectListResultDB)Activator.GetObject(typeof(IMonthCarInspectListResultDB), string.Format("{0}/MyAppMonthCarInspectListResult", wkStr));
        }
    }
}

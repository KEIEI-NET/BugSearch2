//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�����ʕ\DB����N���X
// �v���O�����T�v   : ITegataTorihikisakiListReportResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/4/21  �C�����e : �V�K�쐬
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
    /// ��`�����ʕ\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITegataTorihikisakiListReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TegataTorihikisakiListReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class MediationTegataTorihikisakiListReportResultDB
    {
        /// <summary>
        /// TegataTorihikisakiListReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MediationTegataTorihikisakiListReportResultDB()
        {
        }
        /// <summary>
        /// ITegataTorihikisakiListReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITegataTorihikisakiListReportResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ITegataTorihikisakiListReportResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public static ITegataTorihikisakiListReportResultDB GetTegataTorihikisakiListReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITegataTorihikisakiListReportResultDB)Activator.GetObject(typeof(ITegataTorihikisakiListReportResultDB), string.Format("{0}/MyAppTegataTorihikisakiListReportResult", wkStr));
        }
    }
}

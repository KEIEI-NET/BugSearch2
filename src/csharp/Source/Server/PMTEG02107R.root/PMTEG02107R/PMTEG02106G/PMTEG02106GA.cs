//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ו\DB����N���X
// �v���O�����T�v   : ITegataMeisaiListReportResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/4/28  �C�����e : �V�K�쐬
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
    /// ��`���ו\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITegataMeisaiListReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TegataMeisaiListReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    public class MediationTegataMeisaiListReportResultDB
    {
        /// <summary>
        /// TegataMeisaiListReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public MediationTegataMeisaiListReportResultDB()
        {
        }
        /// <summary>
        /// ITegataMeisaiListReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITegataMeisaiListReportResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ITegataMeisaiListReportResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public static ITegataMeisaiListReportResultDB GetTegataMeisaiListReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITegataMeisaiListReportResultDB)Activator.GetObject(typeof(ITegataMeisaiListReportResultDB), string.Format("{0}/MyAppTegataMeisaiListReportResult", wkStr));
        }
    }
}

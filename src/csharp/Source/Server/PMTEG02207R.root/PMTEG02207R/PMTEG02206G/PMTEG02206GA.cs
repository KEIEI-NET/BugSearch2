//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ו\DB����N���X
// �v���O�����T�v   : ITegataKessaiReportResultDB�I�u�W�F�N�g���擾���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/5/05  �C�����e : �V�K�쐬
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
    /// ��`���ψꗗ�\ �����[�g�I�u�W�F�N�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ITegataKessaiReportResultDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TegataKessaiReportResultDB��</br>
    /// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class MediationTegataKessaiReportResultDB
    {
        /// <summary>
        /// TegataKessaiReportResultDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public MediationTegataKessaiReportResultDB()
        {
        }
        /// <summary>
        /// ITegataKessaiReportResultDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ITegataKessaiReportResultDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ITegataKessaiReportResultDB�C���^�[�t�F�[�X���擾����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public static ITegataKessaiReportResultDB GetTegataKessaiReportResultDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITegataKessaiReportResultDB)Activator.GetObject(typeof(ITegataKessaiReportResultDB), string.Format("{0}/MyAppTegataKessaiReportResult", wkStr));
        }
    }
}

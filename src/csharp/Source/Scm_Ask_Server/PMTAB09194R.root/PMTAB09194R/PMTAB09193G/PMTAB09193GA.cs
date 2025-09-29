//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB����N���X
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
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
    /// IPmtDefEmpDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPmtDefEmpDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PmtDefEmpDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmtDefEmpDB
    {
        /// <summary>
        /// PmtDefEmpDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// </remarks>
        public MediationPmtDefEmpDB()
        {

        }

        /// <summary>
        /// IPmtDefEmpDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IPmtDefEmpDB�I�u�W�F�N�g</returns>
        public static IPmtDefEmpDB GetPmtDefEmpDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9004";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPmtDefEmpDB)Activator.GetObject(typeof(IPmtDefEmpDB), string.Format("{0}/MyAppPmtDefEmp", wkStr));
        }
    }
}
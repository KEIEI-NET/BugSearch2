//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�t�@�C����ۑ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �����N���T�[�r�XDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͎�M�f�[�^DB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationServiceFilesDB
    {
        /// <summary>
        /// �����N���T�[�r�X����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public MediationServiceFilesDB()
        {

        }

        /// <summary>
        /// ISupplierDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISupplierDB�I�u�W�F�N�g</returns>
        public static IServiceFilesDB GetServiceFilesDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:20020";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IServiceFilesDB)Activator.GetObject(typeof(IServiceFilesDB), string.Format("{0}/MyAppServiceFiles", wkStr));
        }
    }
}

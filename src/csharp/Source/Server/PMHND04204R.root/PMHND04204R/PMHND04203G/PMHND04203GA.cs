//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i�����i�Ɖ�DB����N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i�����i�Ɖ�DB����N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ���i�Ɖ�DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IHandyInspectRefDataDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���HandyInspectRefDataDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyInspectRefDataDB
    {
        /// <summary>
        /// HandyInspectDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public MediationHandyInspectRefDataDB()
        {
        }

        /// <summary>
        /// IHandyInspectRefDataDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IHandyInspectRefDataDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IHandyInspectRefDataDB�C���^�[�t�F�[�X���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public static IHandyInspectRefDataDB GetHandyInspectRefDataDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string WkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            WkStr = "http://localhost:8008";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IHandyInspectRefDataDB)Activator.GetObject(typeof(IHandyInspectRefDataDB), string.Format("{0}/MyAppHandyInspectRefData", WkStr));
        }
    }
}

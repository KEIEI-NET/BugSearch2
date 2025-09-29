//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�Ώێ擾DB����N���X
// �v���O�����T�v   : ���i�Ώێ擾DB����N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ���i�Ώێ擾DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IHandyInspectDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���HandyInspectDB��</br>
    /// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyInspectDB
    {
        /// <summary>
        /// HandyInspectDB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public MediationHandyInspectDB()
        {
        }

        /// <summary>
        /// IHandyInspectDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IHandyInspectDB�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : IHandyInspectDB�C���^�[�t�F�[�X���擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public static IHandyInspectDB GetHandyInspectDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IHandyInspectDB)Activator.GetObject(typeof(IHandyInspectDB), string.Format("{0}/MyAppHandyInspect", wkStr));
        }
    }
}

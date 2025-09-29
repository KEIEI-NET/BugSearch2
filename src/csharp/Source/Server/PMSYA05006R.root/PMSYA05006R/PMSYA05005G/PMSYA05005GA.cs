//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�VDB����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �Ԍ������X�VDB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�͎Ԍ������X�VDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    public class MediationInspectDateUpdDB
    {
        /// <summary>
        /// �Ԍ������X�V����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public MediationInspectDateUpdDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>ISupplierChangeProcDB�I�u�W�F�N�g</returns>
        public static IInspectDateUpdDB GetInspectDateUpdDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IInspectDateUpdDB)Activator.GetObject(typeof(IInspectDateUpdDB), string.Format("{0}/MyAppInspectDateUpd", wkStr));
        }
    }
}

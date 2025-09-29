//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �����_�ݒ�}�X�^DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��ISecMngSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>             ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SupplierDB��</br>
    /// <br>             �C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.08</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOrderPointStDB
    {
        /// <summary>
        /// �����_�ݒ�}�X�^DB����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public MediationOrderPointStDB()
        {

        }

        /// <summary>
        /// IOrderPointStDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IOrderPointStDB�I�u�W�F�N�g</returns>
        public static IOrderPointStDB GetOrderPointStDB()
        {
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOrderPointStDB)Activator.GetObject(typeof(IOrderPointStDB), string.Format("{0}/MyAppOrderPointSt", wkStr));
        }
    }
}
